using System;
using System.Linq;
using System.Web.Mvc;
using TeknolivaProje.Core.Infrastructure;

namespace TeknolivaProje.Web.Controllers
{
  public class HomeController : Controller

  {


    private readonly IStationRepository _stationRepository;

    #region Ctor
    public HomeController(IStationRepository stationRepository)
    {
      _stationRepository = stationRepository;
    }
    #endregion

    #region index
    public ActionResult Index()
    {

      return View();
    }


    #endregion


    #region Liste
    public ActionResult Liste()
    {


      var data = Convert.ToInt32(Request.QueryString["sira"]) == 1 ? _stationRepository.GetAll().OrderBy(m => m.CREATE_DATE).ToList() : _stationRepository.GetAll().OrderByDescending(m => m.CREATE_DATE).ToList();



      return View(data);
    }

    #endregion

    #region Detay

    

    public ActionResult Detay(int id)
    {
      return View(_stationRepository.GetById(id));

    }
    #endregion

  }
}