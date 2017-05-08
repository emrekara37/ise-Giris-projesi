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
  public class SehirController : Controller
  {
    private readonly ICityRepository _cityRepository;
   

    #region Ctor

    public SehirController(ICityRepository cityRepository)
    {
    
      _cityRepository = cityRepository;
    }

    #endregion

    #region Şehir Ekle
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Index(CityViewModel model)
    {
      if (!ModelState.IsValid)
      {
        TempData["Hata"] = "Veriler doğrulanamadı!";
        return View();
      }
      var cityModel = new CITY
      {
        LASTUPD_UID = Session["Yonetici"].ToString(),
        CREATE_UID = Session["Yonetici"].ToString(),
        CREATE_DATE = DateTime.Now,
        LASTUPD_DATE = DateTime.Now,
        CITY_NAME = model.CityName
      };
      _cityRepository.Insert(cityModel);
      _cityRepository.Save();
      return RedirectToAction("Index");
    }

    public ActionResult Ekle()
    {
      return RedirectToAction("Index");
    }


    #endregion

    #region Şehir Liste

    public PartialViewResult SehirListe()
    {
      return PartialView(_cityRepository.GetAll().OrderByDescending(m => m.CITY_ID));
    }
    //Json Şehir Listesi
    public JsonResult JsonSehirList()
    {
      var sehirList = _cityRepository.GetAll().OrderByDescending(m => m.CREATE_DATE);
      var jsonList = sehirList.Select(sehir => new CityViewModel
        {
          Id = sehir.CITY_ID,
          CityName = sehir.CITY_NAME,
        })
        .ToList();
      return Json(jsonList, JsonRequestBehavior.AllowGet);
    }
     
    #endregion

    #region Şehir Sil

    public bool Sil(int id)
    {
      var kontrol = _cityRepository.GetById(id);
      if (kontrol == null)
        return false;
      
      _cityRepository.Delete(id);
      _cityRepository.Save();
      return true;
    }



    #endregion

    #region Şehir Düzenle


    [HttpPost]
    public int Duzenle(string cityName, int id)
    {
      var kontrol = _cityRepository.GetById(id);
      if (kontrol == null)
        return 0;

      kontrol.LASTUPD_DATE = DateTime.Now;
      kontrol.CITY_NAME = cityName;

      _cityRepository.Update(kontrol);
      _cityRepository.Save();
      return 1;


    }

    #endregion


  }
}