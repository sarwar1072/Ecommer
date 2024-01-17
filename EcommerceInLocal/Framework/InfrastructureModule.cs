using Autofac;
using Framework.ContextClass;
using Framework.Repositories;
using Framework.Services;
using Framework.UnitOfWorkForApp;

namespace Framework
{
    public class InfrastructureModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly string _webHostEnvironment;
        public InfrastructureModule(string connectionString, string migrationAssemblyName,
            string webHostEnvironment)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
            _webHostEnvironment = webHostEnvironment;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<EcommerceUnitOfWork>().As<IEcommerceUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ShoppingCartRepository>().As<IShoppingCartRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CoverRepository>().As<ICoverRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();

            builder.RegisterType<ShoppingCartServices>().As<IShoppingCartServices>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CoverService>().As<ICoverService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductServices>().As<IProductServices>().InstancePerLifetimeScope();
            builder.RegisterType<OrderServices>().As<IOrderServices>().InstancePerLifetimeScope();  
            builder.RegisterType<OrderDetailsRepository>().As<IOrderDetailsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<OrderHeaderRepository>().As<IOrderHeaderRepository>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
