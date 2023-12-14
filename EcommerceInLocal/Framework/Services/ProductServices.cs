using AutoMapper;
using Framework.Exceptions;
using Framework.UnitOfWorkForApp;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductBO = Framework.BusinessObj.Product;
using ProductEO = Framework.Entity.Product;
using CoverEO = Framework.Entity.Cover;
using CoverBO = Framework.BusinessObj.Cover;
using CategoryBO = Framework.BusinessObj.Category;
using CategoryEO = Framework.Entity.Category;

namespace Framework.Services
{
    public class ProductServices : IProductServices
    {
        private IEcommerceUnitOfWork _ecommerceUnitOf;
        private IMapper _mapper;
        public ProductServices(IEcommerceUnitOfWork unitOfWork,IMapper mapper)
        {
                _ecommerceUnitOf = unitOfWork;  
                 _mapper = mapper;
        }
        public void AddProduct(ProductBO productBO)
        {
            var entity=_ecommerceUnitOf.ProductRepository.GetCount(x=>x.Title==productBO.Title);
            if(entity> 0)
            {
                throw new DuplicationException("same product exist",nameof(productBO.Title)); 
            }
            var mapEntity=_mapper.Map<ProductEO>(productBO); 
            _ecommerceUnitOf.ProductRepository.Add(mapEntity);
            _ecommerceUnitOf.Save();
        }
        public (IList<ProductBO> products, int total, int totalDisplay) GetProduct(int pageindex, int pagesize,
                                                                             string searchText, string orderBy)
        {
            (IList<ProductEO> data, int total, int totalDisplay) result = (null, 0, 0);
            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _ecommerceUnitOf.ProductRepository.GetDynamic(null, orderBy, "Category", pageindex, pagesize, true);
            }
            else
            {
                result = _ecommerceUnitOf.ProductRepository.GetDynamic(x => x.Title == searchText, orderBy, "Category", pageindex, pagesize, true);
            }
            var listOfEntity = new List<ProductBO>();
            foreach (var product in result.data)
            {
              // var obj= AssignProductBO(product);
                listOfEntity.Add(_mapper.Map<ProductBO>(product));
            }
            return (listOfEntity, result.total, result.totalDisplay);
        }
        private ProductBO AssignProductBO(ProductEO productEO)
        {
            var newObj = new ProductBO();
            //var catObj=new CategoryBO();
            //newObj.Category = catObj;
            newObj.Title= productEO.Title;  
            newObj.Description= productEO.Description;
            newObj.ISBN= productEO.ISBN;    
            newObj.Author= productEO.Author;    
            newObj.Price= productEO.Price;
            newObj.Category.Name = productEO.Category.Name;
            return newObj;  
        }
        public IList<ProductBO> GetProductDetails()
        {           
            IList<ProductEO> listofProduct = _ecommerceUnitOf.ProductRepository.GetAll(null,null, "Category,CoverType");
            var listofProductBO = new List<ProductBO>();
            foreach (var item in listofProduct)
            {
                listofProductBO.Add(_mapper.Map<ProductBO>(item));
            }
            return listofProductBO;

        }
        public ProductBO GetOneProductDetails(int id)
        {
            var product = _ecommerceUnitOf.ProductRepository.GetFirstOrDefault(x => x.Id == id, "Category,CoverType");
            var productBO = _mapper.Map<ProductBO>(product);
            return productBO;
        }
        public IList<CategoryBO> GetCategories()
        {
            IList<CategoryEO> categoryEO= _ecommerceUnitOf.CategoryRepository.GetAll();
           var categoryBO=new List<CategoryBO>();
            foreach (var item in categoryEO)
            {
                categoryBO.Add(_mapper.Map<CategoryBO>(item));
            }
            return categoryBO;
        }
        public IList<CoverBO> GetCoverTypes()
        {
            IList<CoverEO> coverEO = _ecommerceUnitOf.CoverRepository.GetAll();
            var coverBO = new List<CoverBO>();
            foreach (var item in coverEO)
            {
                coverBO.Add(_mapper.Map<CoverBO>(item));
            }
            return coverBO;
        }
        public void Dispose()
        {
            _ecommerceUnitOf.Dispose();
        }
    }
}
