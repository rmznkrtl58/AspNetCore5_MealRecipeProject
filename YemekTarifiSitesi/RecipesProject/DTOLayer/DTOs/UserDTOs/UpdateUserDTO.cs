using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.UserDTOs
{
	public class UpdateUserDTO
	{
        public string name { get; set; }
        public string surname { get; set; }
        public string userName { get; set; }
        public string phoneNumber { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        [Compare("password",ErrorMessage ="Şifreler Eşleşmiyor")]
        public string confirmPassword { get; set; }
        public string imageUrl { get; set; }
        public IFormFile picture { get; set; }
        public string city { get; set; }
        public string about { get; set; }
        public string status { get; set; }
        public string Linkedin { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
    }
}
