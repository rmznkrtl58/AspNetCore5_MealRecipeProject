using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.UserDTOs
{
    public class RegisterUserDTO
    {
        //aynı eskisi gibi Identity kayıt ve giriş yapma işlemlerinde
        //modeller oluşturuyordum buraya oluşturuyorum artık
        public string profileImage { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string username{ get; set; }
        public string mail{ get; set; }
        public string password{ get; set; }
        public string confirmPassword{ get; set; }
        public IFormFile picture{ get; set; }
    }
}
