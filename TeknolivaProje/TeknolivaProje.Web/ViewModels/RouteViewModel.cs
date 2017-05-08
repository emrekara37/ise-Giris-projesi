using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeknolivaProje.Web.ViewModels
{
  public class RouteViewModel
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Güzergah ismi boş geçilemez")]
    [StringLength(100)]
    public string RouteName { get; set; }

    [Required(ErrorMessage = "Şehir boş geçilemez")]
    public int CityId { get; set; }

    [Required(ErrorMessage = "Güzergah tipi boş geçilemez")]
    public int RouteTypeId { get; set; }

    [Range(0, 999, ErrorMessage = "{0}-{1} aralığında bir değer giriniz")]
    [Required(ErrorMessage = "Toplam süre boş geçilemez")]
    public int TotalDuration { get; set; }
    [Range(0, 99, ErrorMessage = "{0}-{1} aralığında bir değer giriniz")]
    [Required(ErrorMessage = "Peron no boş geçilemez")]
    public int PeronNo { get; set; }
    [Range(1, 3,ErrorMessage = "{0}-{1} aralığında bir değer giriniz")]
    [Required(ErrorMessage = "Araç tipi boş geçilemez")]
    public int VehicleType { get; set; }

    [Required(ErrorMessage = "Araç plakasını giriniz")]

    public string VehiclePlate { get; set; }

    [ForeignKey("CityId")]
    public virtual CityViewModel CityViewModel { get; set; }

    [ForeignKey("RouteTypeId")]
    public virtual RouteTypeViewModel RouteTypeViewModel { get; set; }
  }
}