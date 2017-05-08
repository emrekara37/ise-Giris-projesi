using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeknolivaProje.Web.ViewModels
{
  public class StationViewModel
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Durak ismi boş geçilemez")]
    [StringLength(100,ErrorMessage = "{0} karakterden fazla bir giriş yapamazsınız")]
    public string StationName { get; set; }

    [Required(ErrorMessage = "Güzergah boş geçilemez")]
    public int RouteViewModelId { get; set; }
    [Required(ErrorMessage = "Durak no alanı boş geçilemez")]
    public int StationNo { get; set; }
    [Required(ErrorMessage = "Varış saati boş geçilemez")]
    public string ArrivalTime { get; set; }
    [Required(ErrorMessage = "Kalkış saati boş geçilemez")]
    public string DepartureTime { get; set; }

    [ForeignKey("RouteViewModelId")]
    public virtual RouteViewModel RouteViewModel { get; set; }

  }
}