using Autofac;
using Ecommerce.Web.Models;
using Ecommerce.Web.Models.CategoryModelFolder;
using Ecommerce.Web.Models.CoverModelFolder;
using Ecommerce.Web.Models.ProductModelFolder;
using Framework.Services;

namespace Ecommerce.Web
{
    public class WebModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly string _webHostEnvironment;

        public WebModule(string connectionString, string migrationAssemblyName,string webHostEnvironment)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
            _webHostEnvironment = webHostEnvironment;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryVM>()
                .AsSelf();
                
            builder.RegisterType<CreateCategory>()
                .AsSelf();               

            builder.RegisterType<ResponseModel>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<DashboardModel>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<EditCategory>()
                .AsSelf();

            builder.RegisterType<LoginModel>()
               .AsSelf()
               .InstancePerLifetimeScope();

            builder.RegisterType<RegistrationConfirmationModel>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<RegisterModel>()
                .AsSelf()
                .InstancePerLifetimeScope();


            builder.RegisterType<CoverVM>().AsSelf();
            builder.RegisterType<CreateCover>().AsSelf();
            builder.RegisterType<EditCover>().AsSelf();

            builder.RegisterType<ProductModel>().AsSelf();
            builder.RegisterType<ProductBaseModel>().AsSelf();
            builder.RegisterType<CreateProduct>().AsSelf();
            builder.RegisterType<ProductDetailsModel>().AsSelf();
            builder.RegisterType<ShoppingCartModel>().AsSelf();
           // builder.RegisterType<ResponesModelTwo>().AsSelf();

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().InstancePerLifetimeScope();
            builder.RegisterType<FileHelper>().As<IFileHelper>().InstancePerLifetimeScope();
            //builder.RegisterType<BaseModel>()
            //    .AsSelf()
            //    .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
