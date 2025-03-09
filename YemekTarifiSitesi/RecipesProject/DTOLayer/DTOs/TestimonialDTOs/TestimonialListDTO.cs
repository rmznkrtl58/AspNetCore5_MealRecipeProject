using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.TestimonialDTOs
{
    public class TestimonialListDto
    {
        public int TestimonialId { get; set; }
        public string NameSurname { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }
        public string Message { get; set; }
    }
}
