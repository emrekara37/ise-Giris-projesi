using System;
using System.Linq;
using System.Web.Mvc;
using TeknolivaProje.Core.Infrastructure;
using TeknolivaProje.Data.Models;
using TeknolivaProje.Web.CustomFilters;
using TeknolivaProje.Web.ViewModels;

namespace TeknolivaProje.Web.Controllers
{
  [LoginFilter]
  public class GuzergahTipController : Controller
  {

    private readonly IRouteTypeRepository _routeTypeRepository;

    #region Ctor
    public GuzergahTipController(IRouteTypeRepository routeTypeRepository)
    {
      _routeTypeRepository = routeTypeRepository;

    }
    #endregion

    #region Güzergah Tip Ekle

    public ActionResult Index()
    {
     
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Index(RouteTypeViewModel model)
    {
      if (!ModelState.IsValid)
      {
        TempData["Hata"] = "Veriler doğrulanamadı!";
        return View();
      }
      var routeTypeModel = new ROUTE_TYPE
      {
        LASTUPD_DATE = DateTime.Now,
        CREATE_DATE = DateTime.Now,
        CREATE_UID = Session["Yonetici"].ToString(),
        LASTUPD_UID = Session["Yonetici"].ToString(),
        ROUTE_TYPE_NAME = model.RouteTypeName
      };
      _routeTypeRepository.Insert(routeTypeModel);
      _routeTypeRepository.Save();
      return RedirectToAction("Index");

    }

    public ActionResult Ekle()
    {
      return RedirectToAction("Index");
    }


    #endregion

    #region Güzergah Tip Liste
    public PartialViewResult GuzergahTipListe()
    {
      return PartialView(_routeTypeRepository.GetAll().OrderByDescending(m => m.ROUTE_TYPE_ID));
    }

    // Json Güzergah Liste
    public JsonResult JsonGuzergahTipList()
    {
      var routeTypeList = _routeTypeRepository.GetAll().OrderByDescending(m => m.CREATE_DATE);
      var jsonList = routeTypeList.Select(routeType => new RouteTypeViewModel
        {
          Id = routeType.ROUTE_TYPE_ID,
          RouteTypeName = routeType.ROUTE_TYPE_NAME,
        })
        .ToList();


      return Json(jsonList, JsonRequestBehavior.AllowGet);
    }




    #endregion

    #region Güzergah Tip Sil
    public bool Sil(int id)
    {
      var kontrol = _routeTypeRepository.GetById(id);
      if (kontrol == null) return false;
      _routeTypeRepository.Delete(id);
      _routeTypeRepository.Save();
      return true;
    }


    #endregion

    #region Güzergah Tip Düzenle

    public int TipDuzenle(string routeTypeName, int id)
    {
      var kontrol = _routeTypeRepository.GetById(id);
      if (kontrol == null)
        return 0;

      kontrol.LASTUPD_DATE = DateTime.Now;
      kontrol.ROUTE_TYPE_NAME = routeTypeName;

      _routeTypeRepository.Update(kontrol);
      _routeTypeRepository.Save();
      return 1;

    }

    #endregion

  }
}