using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeknolivaProje.Data.Models
{
  public  class SYSADM_USER
  {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public SYSADM_USER()
    {
      CITY = new HashSet<CITY>();
      CITY1 = new HashSet<CITY>();
      ROUTE = new HashSet<ROUTE>();
      ROUTE1 = new HashSet<ROUTE>();
      ROUTE_TYPE = new HashSet<ROUTE_TYPE>();
      ROUTE_TYPE1 = new HashSet<ROUTE_TYPE>();
      STATION = new HashSet<STATION>();
      STATION1 = new HashSet<STATION>();
    }

    [Key]
    [StringLength(20)]
    public string SYSADM_UID { get; set; }

    [Required]
    [StringLength(30)]
    public string FIRST_NAME { get; set; }

    [Required]
    [StringLength(30)]
    public string LAST_NAME { get; set; }

    [Required]
    [StringLength(30)]
    public string USERNAME { get; set; }

    [Required]
    [StringLength(30)]
    public string PASSWORD { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<CITY> CITY { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<CITY> CITY1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<ROUTE> ROUTE { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<ROUTE> ROUTE1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<ROUTE_TYPE> ROUTE_TYPE { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<ROUTE_TYPE> ROUTE_TYPE1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<STATION> STATION { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<STATION> STATION1 { get; set; }
  }
}
