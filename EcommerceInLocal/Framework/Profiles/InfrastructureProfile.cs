using AutoMapper;
using CategoryBO=Framework.BusinessObj.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryEO = Framework.Entity.Category;
using CoverBO = Framework.BusinessObj.Cover;
using CoverEO = Framework.Entity.Cover;
namespace Framework.Profiles
{
    public class InfrastructureProfile:Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<CategoryBO, CategoryEO>().ReverseMap();
            CreateMap<CoverBO, CoverEO>().ReverseMap();

        }
    }
}
