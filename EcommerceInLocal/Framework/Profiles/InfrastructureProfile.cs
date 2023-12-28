using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryBO = Framework.BusinessObj.Category;
using CategoryEO = Framework.Entity.Category;
using CoverBO = Framework.BusinessObj.Cover;
using CoverEO = Framework.Entity.Cover;
using ProductBO = Framework.BusinessObj.Product;
using ProductEO = Framework.Entity.Product;
using ShoppingCartEO = Framework.Entity.ShoppingCart;
using ShoppingCartBO = Framework.BusinessObj.ShoppingCart;
namespace Framework.Profiles
{
    public class InfrastructureProfile:Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<CategoryBO, CategoryEO>().ReverseMap();
            CreateMap<CoverBO, CoverEO>().ReverseMap();
            CreateMap<ProductBO, ProductEO>().ReverseMap();
            CreateMap<ShoppingCartBO, ShoppingCartEO>().ReverseMap();

        }
    }
}
