using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Team
    {
        [Key] 
        public int TeamId { get; set; }
        [StringLength(50)]
        public string NameSurname { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        [StringLength(200)]
        public string Image { get; set; }
        [StringLength(250)]
        public string LinkedinUrl { get; set; }
        [StringLength(250)]
        public string InstagramUrl { get; set; }
        [StringLength(250)]
        public string TwitterUrl { get; set; }
        public bool DeleteStatus { get; set; }
    }
}
