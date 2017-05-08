using System.Web.Mvc;
using TeknolivaProje.Core.Infrastructure;
using TeknolivaProje.Web.Helpers;
using TeknolivaProje.Web.ViewModels;

namespace TeknolivaProje.Web.Controllers
{
  public class HesapController : Controller
  {
    private readonly ISysAdmUserRepository _sysAdmUserRepository;

    #region Ctor




    public HesapController(ISysAdmUserRepository sysAdmUserRepository)
    {
      _sysAdmUserRepository = sysAdmUserRepository;
    }
    #endregion

    #region Giriş



    public ActionResult Index()
    {
      return RedirectToAction("Giris");
    }
    public ActionResult Giris()
    {
      return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Giris(LoginViewModel model)
    {
      if (ModelState.IsValid)
      {


        var md5Kontrol = model.Password.Md5Sifrele();
        var girisData = _sysAdmUserRepository.Get(m => m.USERNAME == model.UserName && m.PASSWORD == md5Kontrol);
        if (girisData != null)
        {
          Session["Yonetici"] = girisData.SYSADM_UID;
          return Redirect("/Home/Index");
        }


        TempData["Hata"] = "Sistem Yöneticisi değilsiniz. IS Kullanıcı Yardım Masasına başvurunuz. Tel:6666";
        return View();

      }

      TempData["Hata"] = "Veriler doğrulanmadı !";
      return View();





    }
    #endregion

    #region Çıkış Yap




    public ActionResult CikisYap()
    {
      Session.Remove("Yonetici");
      return Redirect("/Home");
    }
    #endregion
  }
}