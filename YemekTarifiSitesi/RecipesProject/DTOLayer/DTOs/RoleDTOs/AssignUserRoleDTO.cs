using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.RoleDTOs
{
    public class AssignUserRoleDTO
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool RoleExist { get; set; }//bu kullanıcı bu rolu içeriyormu 
        //bu rol bu kullanıcıda varmı?
    }
}
