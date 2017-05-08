using System.ComponentModel.DataAnnotations;

namespace TeknolivaProje.Web.ViewModels
{
  public class CityViewModel
  {

    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Şehir adı gereklidir")]
    [StringLength(50, ErrorMessage = "{0} karakterden fazla bir şehir ismi olamaz")]
    public string CityName { get; set; }

  }
}