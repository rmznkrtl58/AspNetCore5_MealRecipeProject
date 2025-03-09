using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        [StringLength(50)]
        public string MainHeader { get; set; }
        [StringLength(5)]
        public string Price { get; set; }
        [StringLength(150)]
        public string SubDescription { get; set; }
        [StringLength(200)]
        public string Item1 { get; set; }
        [StringLength(200)]
        public string Item2 { get; set; }
        [StringLength(200)]
        public string Item3 { get; set; }
        [StringLength(200)]
        public string Image { get; set; }
        public bool DeleteStatus { get; set; }
        public DateTime EventDate { get; set; }
    }
}
