using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class WhyUs
    {
        [Key]
        public int WhyUsId { get; set; }
        [StringLength(50)]
        public string MainHeader { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
    }
}
