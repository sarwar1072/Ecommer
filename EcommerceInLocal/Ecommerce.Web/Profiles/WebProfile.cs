using AutoMapper;
using Ecommerce.Web.Models.CategoryModelFolder;
//using ProblemAndSolution.Infrastructure.BusinessObj;
//using ProblemAndSolution.Membership.BusinessObj;
//using ProblemAndSolution.Membership.DTOS;
//using ProblemAndSolution.Web.Areas.ForPost.Models;
//using ProblemAndSolution.Web.Models;
using CategoryBO = Framework.BusinessObj.Category;
namespace Ecommerce.Web.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<CreateCategory, CategoryBO>().ReverseMap();
            //CreateMap<ApplicationUser, UserBasicInfo>().ReverseMap();
            //CreateMap<Question, QuestionCreateModel>().ReverseMap();
            //CreateMap<Question, QuestionEditModel>().ReverseMap();

        }
    }
}
