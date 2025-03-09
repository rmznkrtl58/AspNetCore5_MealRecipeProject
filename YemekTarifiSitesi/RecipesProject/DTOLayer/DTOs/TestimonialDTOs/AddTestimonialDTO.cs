using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.TestimonialDTOs
{
    public class AddTestimonialDTO
    {
        public string NameSurname { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }
        public string Message { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
