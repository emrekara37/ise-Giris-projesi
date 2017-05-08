using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using TeknolivaProje.Core.Infrastructure;
using TeknolivaProje.Core.Repository;

namespace TeknolivaProje.Web
{
  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);

      // AutoFac Kayıtları
       var builder = new ContainerBuilder();
      builder.RegisterControllers(Assembly.GetExecutingAssembly());
      builder.RegisterType<SysAdmUserRepository>().As<ISysAdmUserRepository>();
      builder.RegisterType<CityRepository>().As<ICityRepository>();
      builder.RegisterType<RouteTypeRepository>().As<IRouteTypeRepository>();
      builder.RegisterType<RouteRepository>().As<IRouteRepository>();
      builder.RegisterType<StationRepository>().As<IStationRepository>();
      var container = builder.Build();
      DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
      // Autofac Kayıt Sonu
    }
  }
}
