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
  public class DurakController : Controller
  {
    private readonly IStationRepository _stationRepository;
    private readonly IRouteRepository _routeRepository;


    #region Ctor
    public DurakController(IStationRepository stationRepository, IRouteRepository routeRepository)
    {
      _stationRepository = stationRepository;
      _routeRepository = routeRepository;
    }
    #endregion

    #region Durak Ekle

    public ActionResult Index()
    {
      GuzergahListe();
      return View();
    }



    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Index(StationViewModel model)
    {
      if (!ModelState.IsValid)
      {
        TempData["Hata"] = "Veriler doğrulanamadı!";
        return View();
      }
      var data = new STATION
      {
        ARRIVAL_TIME = model.ArrivalTime,
        CREATE_DATE = DateTime.Now,
        CREATE_UID = Session["Yonetici"].ToString(),
        DEPARTURE_TIME = model.DepartureTime,
        LASTUPD_DATE = DateTime.Now,
        LASTUPD_UID = Session["Yonetici"].ToString(),
        ROUTE_ID = model.RouteViewModelId,
        STATION_NAME = model.StationName,
        STATION_NO = model.StationNo

      };
      _stationRepository.Insert(data);
      _stationRepository.Save();
      return RedirectToAction("Index");

    }
    public ActionResult Ekle()
    {
      return RedirectToAction("Index");
    }
    #endregion

    #region Viewbag Güzergah Listesi

    public void GuzergahListe()
    {
      ViewBag.GuzergahList = _routeRepository.GetAll().OrderByDescending(m => m.CREATE_DATE);
    }

    #endregion

    #region Durak Liste

    public PartialViewResult DurakListe()
    {
      return PartialView(_stationRepository.GetAll().OrderByDescending(m => m.CREATE_DATE));
    }

    #endregion

    #region Durak Sil

    public bool Sil(int id)
    {
      var kontrol = _stationRepository.GetById(id);
      
      if (kontrol == null) return false;
      _stationRepository.Delete(id);
      
      _stationRepository.Save();
      return true;
    }


    #endregion

    #region Durak Düzenle

    public ActionResult Duzenle(int id)
    {
      GuzergahListe();
      var data = _stationRepository.GetById(id);
      if (data == null)
        return Redirect("/Home");
      var model = new StationViewModel
      {
        StationNo = data.STATION_NO,
        ArrivalTime = data.ARRIVAL_TIME,
        DepartureTime = data.DEPARTURE_TIME,
        RouteViewModelId = data.ROUTE_ID,
        StationName = data.STATION_NAME,
        Id = data.STATION_ID

      };
      return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Duzenle(StationViewModel model)
    {
      var data = _stationRepository.GetById(model.Id);
      if (!ModelState.IsValid)
      {
        TempData["Hata"] = "Veriler doğrulanmadı";
        return View();
      }


      data.ARRIVAL_TIME = model.ArrivalTime;
      data.DEPARTURE_TIME = model.DepartureTime;
      data.LASTUPD_DATE = DateTime.Now;
      data.ROUTE_ID = model.RouteViewModelId;
      data.STATION_ID = model.Id;
      data.STATION_NO = model.StationNo;
      data.STATION_NAME = model.StationName;

      _stationRepository.Update(data);
      _stationRepository.Save();
      return RedirectToAction("Index");
    }



    #endregion
  }
}