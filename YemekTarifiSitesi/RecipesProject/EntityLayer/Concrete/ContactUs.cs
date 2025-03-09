using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ContactUs
    {
        [Key]
        public int ContactUsId { get; set; }
        [StringLength(50)]
        public string NameSurname { get; set; }
        [StringLength(50)]
        public string Mail { get; set; }
        [StringLength(50)]
        public string Subject { get; set; }
        [StringLength(300)]
        public string Message{ get; set; }
    }
}
