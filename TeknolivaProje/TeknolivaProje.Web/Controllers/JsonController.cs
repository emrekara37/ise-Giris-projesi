using System;
using System.Linq;
using System.Web.Mvc;
using TeknolivaProje.Core.Infrastructure;
using TeknolivaProje.Web.Helpers;
using TeknolivaProje.Web.ViewModels;

namespace TeknolivaProje.Web.Controllers
{
  public class JsonController : Controller
  {

 
    private readonly IRouteRepository _routeRepository;
    private readonly IStationRepository _stationRepository;
    private readonly ICityRepository _cityRepository;
    private readonly IRouteTypeRepository _routeTypeRepository;

    #region Ctor




    public JsonController(
  

      IRouteRepository routeRepository,
      IStationRepository stationRepository,
      ICityRepository cityRepository,
      IRouteTypeRepository routeTypeRepository
      )
    {
      _routeTypeRepository = routeTypeRepository;
      _cityRepository = cityRepository;
      _stationRepository = stationRepository;
      _routeRepository = routeRepository;
  
    }
    #endregion

    #region  Json Listeler
    //Json Güzergah List
    public JsonResult JsonGuzergahList(int cityId, int routeTypeId)
    {
      var data = _routeRepository.GetMany(m => m.CITY_ID == cityId && m.ROUTE_TYPE_ID == routeTypeId).ToList();
      var jsonList = data.Select(route => new RouteViewModel
        {
        
          Id = route.ROUTE_ID,
        
          RouteName = route.ROUTE_NAME,
        
        })
        .ToList();
      return Json(jsonList, JsonRequestBehavior.AllowGet);
    }
    // Json Şehir List
    public JsonResult JsonSehirList()
    {
      var data = _cityRepository.GetAll().OrderByDescending(m => m.CREATE_DATE).ToList();
      var jsonList = data.Select(city => new CityViewModel
        {
          CityName= city.CITY_NAME,
          
          Id = city.CITY_ID,
          })
        .ToList();

      return Json(jsonList, JsonRequestBehavior.AllowGet);
    }

    //  Json Güzergah Tip List
    public JsonResult JsonGuzergahTipList()
    {
      var data = _routeTypeRepository.GetAll().OrderByDescending(m => m.CREATE_DATE).ToList();
      var jsonList = data.Select(routeType => new RouteTypeViewModel
      {
        Id=routeType.ROUTE_TYPE_ID,
        RouteTypeName = routeType.ROUTE_TYPE_NAME
      });
      return Json(jsonList, JsonRequestBehavior.AllowGet);
    }
    //Json Durak List
    public JsonResult JsonDurakList(int id)
    {
      var data = _stationRepository.GetMany(m => m.ROUTE_ID == id).ToList();
      var jsonList = data.Select(station => new StationViewModel
      {
       
        Id = station.STATION_ID,
     
        StationName = station.STATION_NAME
      }).ToList();
      return Json(jsonList, JsonRequestBehavior.AllowGet);

    }


    #endregion

    #region Json Durak Bilgiler

    public ActionResult JsonBilgi(int id)
    {
      var data = _stationRepository.GetById(id);
     
      var result = new
      {
        ArrivalTime=data.ARRIVAL_TIME ,
        DepartureTime= data.DEPARTURE_TIME,
        Id=data.STATION_ID,
        RouteViewModelId=data.ROUTE_ID,
        StationName= data.STATION_NAME,
        StationNo=data.STATION_NO,
        TotalDuration= data.ROUTE.TOT_DURATION,
        PeronNo=data.ROUTE.PERON_NO,
        VehiclePlate= data.ROUTE.VEHICLE_PLATE,
       
        VehicleType = Enum.GetName(typeof(VehicleType), data.ROUTE.VEHICLE_TYPE)

      };
      return Json(result, JsonRequestBehavior.AllowGet);
    }

    #endregion
  }
}