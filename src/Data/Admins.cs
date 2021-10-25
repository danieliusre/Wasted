using System.Collections.Generic;
using System.Security.Claims;
namespace Wasted.Data
{
    public class Admins
    {

        public bool IsAdmin (IEnumerable<Claim> claimList)
        {
            foreach (var claim in claimList)
            {
               if(claim.Type == ClaimTypes.Role )
               return claim.Value == "admin" ? true : false; 
            }
            return false;
        }
        
    }
}