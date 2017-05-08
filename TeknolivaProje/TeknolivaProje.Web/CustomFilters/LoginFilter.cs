using System.Web.Mvc;

namespace TeknolivaProje.Web.CustomFilters
{
  public class LoginFilter : FilterAttribute , IActionFilter
  {
    public void OnActionExecuted(ActionExecutedContext filterContext)
    {
      if (filterContext.HttpContext.Session == null) return;
      var control = filterContext.HttpContext.Session["Yonetici"];
      if (control == null)
        filterContext.Result = new RedirectResult("/Hesap/Giris");
    }

    public void OnActionExecuting(ActionExecutingContext filterContext)
    {
      
     
    }
  }
}