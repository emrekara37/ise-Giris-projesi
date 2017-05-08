using System.ComponentModel.DataAnnotations;

namespace TeknolivaProje.Web.ViewModels
{
  public class LoginViewModel
  {
    [Required(ErrorMessage = "Kullanıcı adı alanı boş geçilemez")]
    [StringLength(30, ErrorMessage = "30 harften fazla bir giriş yaptınız")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "Şifre alanı boş geçilemez")]
    [StringLength(30, ErrorMessage = "30 harften fazla bir giriş yaptınız")]
    public string Password { get; set; }

  }
}