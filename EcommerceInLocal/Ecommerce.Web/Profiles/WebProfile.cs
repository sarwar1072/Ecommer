using AutoMapper;
using Ecommerce.Web.Models;
using Ecommerce.Web.Models.CategoryModelFolder;
using Membership.BusinessObj;
using Membership.DTOS;
using CategoryBO = Framework.BusinessObj.Category;
namespace Ecommerce.Web.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<CreateCategory, CategoryBO>().ReverseMap();
            CreateMap<RegisterModel, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser, UserBasicInfo>().ReverseMap();
            //CreateMap<ApplicationUser, UserBasicInfo>().ReverseMap();
            //CreateMap<Question, QuestionCreateModel>().ReverseMap();
            //CreateMap<Question, QuestionEditModel>().ReverseMap();

        }
    }
}
