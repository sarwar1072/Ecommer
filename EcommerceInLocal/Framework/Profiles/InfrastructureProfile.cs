using AutoMapper;
using CategoryBO=Framework.BusinessObj.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryEO = Framework.Entity.Category;

namespace Framework.Profiles
{
    public class InfrastructureProfile:Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<CategoryBO, CategoryEO>().ReverseMap();
            //CreateMap<Answer, AnswerEO>().ReverseMap();
            //CreateMap<Comment, CommentEO>().ReverseMap();
        }
    }
}
