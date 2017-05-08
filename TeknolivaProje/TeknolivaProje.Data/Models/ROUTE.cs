using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeknolivaProje.Data.Models
{
  [Table("ROUTE")]
  public class ROUTE
  {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public ROUTE()
    {
      STATION = new HashSet<STATION>();
    }

    [Key]

    public int ROUTE_ID { get; set; }

    [Required]
    [StringLength(100)]
    public string ROUTE_NAME { get; set; }

    public int CITY_ID { get; set; }

    public int ROUTE_TYPE_ID { get; set; }

    [Range(0, 999)]
    public int TOT_DURATION { get; set; }
    [Range(0, 99)]
    public int PERON_NO { get; set; }
    [Range(0, 4)]
    public int VEHICLE_TYPE { get; set; }

    [Required]
    public string VEHICLE_PLATE { get; set; }

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

    public virtual CITY CITY { get; set; }

    public virtual ROUTE_TYPE ROUTE_TYPE { get; set; }

    public virtual SYSADM_USER SYSADM_USER { get; set; }

    public virtual SYSADM_USER SYSADM_USER1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<STATION> STATION { get; set; }
  }
}
