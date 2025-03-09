using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.WhyUsDTOs
{
    public class WhyUsListDTO
    {
        public int WhyUsId { get; set; }
        public string MainHeader { get; set; }
        public string Description { get; set; }
    }
}
