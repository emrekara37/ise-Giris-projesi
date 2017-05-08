using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeknolivaProje.Data.Models
{
  [Table("CITY")]
  public  class CITY
  {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public CITY()
    {
      ROUTE = new HashSet<ROUTE>();
    }

    [Key]
   
    public int CITY_ID { get; set; }

    [Required]
    [StringLength(50)]
    public string CITY_NAME { get; set; }

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

    public virtual SYSADM_USER SYSADM_USER { get; set; }

    public virtual SYSADM_USER SYSADM_USER1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<ROUTE> ROUTE { get; set; }
  }
}
