using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace YungChingRealtyPreview.App_Start
{
	public class AutofacConfig
	{
		public static void Bootstrapper()
		{
			ContainerBuilder builder = new ContainerBuilder();

			//builder.RegisterControllers(Assembly.GetExecutingAssembly());
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			//Service
			var services = Assembly.Load("YungChingRealtyPreview.Service");
			builder.RegisterAssemblyTypes(services)
				.Where(x => x.Name.EndsWith("Service"))
				.AsImplementedInterfaces();

			//Repository
			var repositories = Assembly.Load("YungChingRealtyPreview.Repository");
			builder.RegisterAssemblyTypes(repositories)
				.Where(x => x.Name.EndsWith("Repository"))
				.AsImplementedInterfaces();

			IContainer container = builder.Build();

			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

			var config = GlobalConfiguration.Configuration;
			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

		}
	}
}