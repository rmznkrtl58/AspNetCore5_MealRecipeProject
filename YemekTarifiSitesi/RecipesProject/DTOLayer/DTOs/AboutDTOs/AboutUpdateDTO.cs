using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AboutDTOs
{
    public class AboutUpdateDTO
    {
        public int AboutId { get; set; }
        public string TopHeader { get; set; }
        public string SubHeader { get; set; }
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public string Item3 { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
