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
  public class GuzergahController : Controller
  {
    private readonly IRouteRepository _routeRepository;
    private readonly IRouteTypeRepository _routeTypeRepository;
    private readonly ICityRepository _cityRepository;

    #region Ctor

    public GuzergahController(IRouteRepository routeRepository,IRouteTypeRepository routeTypeRepository,ICityRepository cityRepository)
    {
      _cityRepository = cityRepository;
      _routeTypeRepository = routeTypeRepository;
      _routeRepository = routeRepository;
    }

    #endregion

    #region Güzergah Ekle
    public ActionResult Index()
    {
      ViewBag.SehirList = _cityRepository.GetAll().OrderByDescending(m => m.CREATE_DATE);
      ViewBag.GuzergahTipList = _routeTypeRepository.GetAll().OrderByDescending(m => m.CREATE_DATE);
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Index(RouteViewModel model)
    {

      if (!ModelState.IsValid)
      {
        TempData["Hata"] = "Veriler doğrulanamadı!";
        return View();
      }
      var routeModel = new ROUTE
      {
        LASTUPD_DATE = DateTime.Now,
        CREATE_DATE = DateTime.Now,
        CREATE_UID = Session["Yonetici"].ToString(),
        LASTUPD_UID = Session["Yonetici"].ToString(),
        ROUTE_TYPE_ID = model.RouteTypeId,
        CITY_ID = model.CityId,
        TOT_DURATION = model.TotalDuration,
        ROUTE_NAME = model.RouteName,
        VEHICLE_TYPE = model.VehicleType,
        PERON_NO = model.PeronNo,
        VEHICLE_PLATE = model.VehiclePlate
      };
      _routeRepository.Insert(routeModel);
      _routeRepository.Save();
      return RedirectToAction("Index");

    }

    public ActionResult Ekle()
    {
      return RedirectToAction("Index");
    }
    #endregion

    #region Güzergah Liste

    public PartialViewResult GuzergahListe()
    {
      return PartialView(_routeRepository.GetAll().OrderByDescending(m => m.CREATE_DATE));
    }
   

    #endregion

    #region Güzergah Düzenle

    public ActionResult Duzenle(int id)
    {
      ViewBag.SehirList = _cityRepository.GetAll().OrderByDescending(m => m.CREATE_DATE);
      ViewBag.GuzergahTipList = _routeTypeRepository.GetAll().OrderByDescending(m => m.CREATE_DATE);
      var data = _routeRepository.GetById(id);
      if (data == null)
        return Redirect("/Home");
      var model = new RouteViewModel
      {
        CityId = data.CITY_ID,
        Id = data.ROUTE_ID,
        PeronNo = data.PERON_NO,
        VehiclePlate = data.VEHICLE_PLATE,
        VehicleType = data.VEHICLE_TYPE,
        RouteName = data.ROUTE_NAME,
        RouteTypeId = data.ROUTE_TYPE_ID,
        TotalDuration = data.TOT_DURATION,

      };
      return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Duzenle(RouteViewModel model)
    {
      var data = _routeRepository.GetById(model.Id);
      if (model.CityId != 0 || model.RouteTypeId != 0)
      {
        data.CITY_ID = model.CityId;
        data.ROUTE_TYPE_ID = model.RouteTypeId;
      }
      data.ROUTE_NAME = model.RouteName;
      data.TOT_DURATION = model.TotalDuration;
      data.PERON_NO = model.PeronNo;
      data.VEHICLE_TYPE = model.VehicleType;
      data.LASTUPD_DATE = DateTime.Now;
      data.VEHICLE_PLATE = model.VehiclePlate;
      _routeRepository.Update(data);
      _routeRepository.Save();
      return RedirectToAction("Index");
    }

    #endregion

    #region Güzergah Sil

    public bool Sil(int id)
    {
      var kontrol = _routeRepository.GetById(id);
      if (kontrol == null) return false;
      _routeRepository.Delete(id);
      _routeRepository.Save();
      return true;
    }


    #endregion
  }
}