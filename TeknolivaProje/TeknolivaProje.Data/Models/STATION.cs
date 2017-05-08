using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeknolivaProje.Data.Models
{

  [Table("STATION")]
  public  class STATION
  {
    [Key]

    public int STATION_ID { get; set; }

    [Required]
    [StringLength(100)]
    public string STATION_NAME { get; set; }

    public int ROUTE_ID { get; set; }

    [Range(0,99)]
    public int STATION_NO { get; set; }

    [Required]
    [StringLength(5)]
    public string ARRIVAL_TIME { get; set; }

    [Required]
    [StringLength(5)]
    public string DEPARTURE_TIME { get; set; }

    [Required]
    [StringLength(20)]
    public string CREATE_UID { get; set; }

    [Column(TypeName = "date")]
    public DateTime CREATE_DATE { get; set; }

    [Required]
    [StringLength(20)]
    public string LASTUPD_UID { get; set; }

    [Column(TypeName = "date")]
    public DateTime LASTUPD_DATE { get; set; }

    public virtual ROUTE ROUTE { get; set; }

    public virtual SYSADM_USER SYSADM_USER { get; set; }

    public virtual SYSADM_USER SYSADM_USER1 { get; set; }
  }
}
