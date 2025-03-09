using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.EventDTOs
{
    public class InsertEventDTO
    {
        public string MainHeader { get; set; }
        public string Price { get; set; }
        public string SubDescription { get; set; }
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public string Item3 { get; set; }
        public string Image { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
