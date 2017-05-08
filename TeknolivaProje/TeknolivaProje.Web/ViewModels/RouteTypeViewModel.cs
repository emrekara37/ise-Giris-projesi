using System.ComponentModel.DataAnnotations;

namespace TeknolivaProje.Web.ViewModels
{
  public class RouteTypeViewModel
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Güzergah adı gereklidir")]
    [StringLength(50, ErrorMessage = "{0} karakterden fazla bir güzergah ismi olamaz")]
    public string RouteTypeName { get; set; }

  }
}