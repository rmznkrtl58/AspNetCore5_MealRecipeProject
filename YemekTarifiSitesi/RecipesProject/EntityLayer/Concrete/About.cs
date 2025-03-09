using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AboutId { get; set; }
        [StringLength(50)]
        public string TopHeader { get; set; }
        [StringLength(150)]
        public string SubHeader { get; set; }
        [StringLength(150)]
        public string Item1 { get; set; }
        [StringLength(150)]
        public string Item2 { get; set; }
        [StringLength(150)]
        public string Item3 { get; set; }
        [StringLength(600)]
        public string Description { get; set; }
        [StringLength(250)]
        public string Image { get; set; }
    }
}
