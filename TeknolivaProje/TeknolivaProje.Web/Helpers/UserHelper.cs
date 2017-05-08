using TeknolivaProje.Core.Infrastructure;
using TeknolivaProje.Core.Repository;
using TeknolivaProje.Data.Models;

namespace TeknolivaProje.Web.Helpers
{
  public static class UserHelper
  {

    private static readonly ISysAdmUserRepository SysAdmUserRepository = new SysAdmUserRepository();
    
    public static SYSADM_USER GetUser(string id)
    {

      return SysAdmUserRepository.Get(m => m.SYSADM_UID == id);


    }

  }

  public enum VehicleType
  {
    Minibüs=1,
    Dolmuş=2,
    Otobüs=3
  }
}