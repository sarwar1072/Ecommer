using Autofac;
using Membership.BusinessObj;
using Membership.Services;

namespace Membership
{
    public class MembershipModule : Module
    {
		protected override void Load(ContainerBuilder builder)
		{
			//builder.RegisterType<UrlService>().As<IUrlService>()
			//	.InstancePerLifetimeScope();
			//builder.RegisterType<HtmlEmailService>().As<IQueuedEmailService>()
			//	.InstancePerLifetimeScope();
			builder.RegisterType<SignInManagerAdapter>().As<ISignInManagerAdapter<ApplicationUser>>()
				.InstancePerLifetimeScope();

			builder.RegisterType<UserManagerAdapter>().As<IUserManagerAdapter<ApplicationUser>>()
				.InstancePerLifetimeScope();

			//builder.RegisterType<MembershipMailSenderService>().As<IMembershipMailSenderService>()
			//	.InstancePerLifetimeScope();
			base.Load(builder);
		}
	}
}
