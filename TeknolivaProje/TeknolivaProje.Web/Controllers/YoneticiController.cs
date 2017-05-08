using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeknolivaProje.Core.Infrastructure;
using TeknolivaProje.Web.CustomFilters;
using TeknolivaProje.Web.Helpers;

namespace TeknolivaProje.Web.Controllers
{

  [LoginFilter]
  public class YoneticiController : Controller
  {
    private readonly ICityRepository _cityRepository;
    private readonly IRouteTypeRepository _routeTypeRepository;
    private readonly IRouteRepository _routeRepository;
    private readonly IStationRepository _stationRepository;

    #region Ctor
    public YoneticiController(
      IRouteRepository routeRepository,
        ICityRepository cityRepository,
        IRouteTypeRepository routeTypeRepository,
        IStationRepository stationRepository
      )
    {
      _stationRepository = stationRepository;
      _routeRepository = routeRepository;
      _routeTypeRepository = routeTypeRepository;
      _cityRepository = cityRepository;
    }

    #endregion

    #region index

    public ActionResult Index()
    {
      return Redirect("/Home");
    }

    #endregion

    #region Excel

    

    public ActionResult Excel()
    {
      return View();
    }

    #endregion

    #region Excel İşlemleri

    public void ExceleAktar(int id)
    {
      var _dosyaAdi = "";
      switch (id)
      {
        case 0:

          var cityNameList = _cityRepository.GetAll().Select(m => new { SehirAdi = m.CITY_NAME });
          _dosyaAdi = "Şehirler";
          ExcelOlusturucu(_dosyaAdi, cityNameList);
          break;
        case 1:
          var routeTypeList = _routeTypeRepository.GetAll().Select(m => new { GuzergahTip = m.ROUTE_TYPE_NAME });
          _dosyaAdi = "GüzergahTipler";
          ExcelOlusturucu(_dosyaAdi, routeTypeList);
          break;
        case 2:

          var routeList = _routeRepository.GetAll()
            .Select(m => new
            {
              Sehir = m.CITY.CITY_NAME,
              GuzergahTip = m.ROUTE_TYPE.ROUTE_TYPE_NAME,
              Guzergah = m.ROUTE_NAME,
              ToplamSure = m.TOT_DURATION + " dk",
              PeronNo = m.PERON_NO,
              ServisAraci = Enum.GetName(typeof(VehicleType), m.VEHICLE_TYPE),
              ServisPlaka = m.VEHICLE_PLATE
            });
          _dosyaAdi = "Güzergahlar";
          ExcelOlusturucu(_dosyaAdi, routeList);
          break;

        case 3:
          var stationList = _stationRepository.GetAll()
            .Select(m => new
            {
              Sehir = m.ROUTE.CITY.CITY_NAME,
              GuzergahTip = m.ROUTE.ROUTE_TYPE.ROUTE_TYPE_NAME,
              Guzergah = m.ROUTE.ROUTE_NAME,
              DurakAdi = m.STATION_NAME,
              DurakNo = m.STATION_NO,
              VarisSaati = m.ARRIVAL_TIME,
              KalkisSaati = m.DEPARTURE_TIME

            });
          _dosyaAdi = "Duraklar";
          ExcelOlusturucu(_dosyaAdi, stationList);
          break;
        case 4:
          var generalList = _stationRepository.GetAll()
            .Select(m => new
            {
              Sehir = m.ROUTE.CITY.CITY_NAME,
              GuzergahTip = m.ROUTE.ROUTE_TYPE.ROUTE_TYPE_NAME,
              Guzergah = m.ROUTE.ROUTE_NAME,
              ToplamSure = m.ROUTE.TOT_DURATION + " dk",
              PeronNo = m.ROUTE.PERON_NO,
              ServisAraci = Enum.GetName(typeof(VehicleType), m.ROUTE.VEHICLE_TYPE),
              ServisPlaka = m.ROUTE.VEHICLE_PLATE,
              DurakAdi = m.STATION_NAME,
              DurakNo = m.ROUTE.PERON_NO,
              VarisSaati = m.ARRIVAL_TIME,
              KalkisSaati = m.DEPARTURE_TIME

            });
          _dosyaAdi = "Genel";
          ExcelOlusturucu(_dosyaAdi, generalList);
          break;
      }

      void ExcelOlusturucu(string dosyaAdi, object data)
      {
        var grid = new GridView();
        grid.DataSource = data;
        grid.DataBind();
        Response.ClearContent();
        
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1254");
        Response.Charset = "windows-1254";
        Response.AddHeader("content-disposition", "attachment;filename=" + dosyaAdi + ".xls");
        Response.ContentType = "application/vnd.ms-excel";
        var sw = new StringWriter();
        var s = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\n<head>\n<title></title>\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1254\" />\n<style>\n</style>\n</head>\n<body>\n";
        var htw = new HtmlTextWriter(sw);
        grid.RenderControl(htw);
        Response.Write(s+sw.ToString());
        Response.End();


      }
    }



    #endregion


  }
}