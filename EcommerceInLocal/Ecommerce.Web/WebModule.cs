using Autofac;
using Ecommerce.Web.Models;
using Ecommerce.Web.Models.CategoryModelFolder;

namespace Ecommerce.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryVM>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<CreateCategory>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<ResponseModel>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<DashboardModel>()
                .AsSelf()
                .InstancePerLifetimeScope();

            //builder.RegisterType<PostLayoutModel>()
            //    .AsSelf()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<QuestionCreateModel>()
            //    .AsSelf()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<QuestionEditModel>()
            //    .AsSelf()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<AnswerCreateModel>()
            //    .AsSelf()
            //    .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
