using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; }
        //bir kategoride birden fazla yemek bulunabilir
        public List<Meal>Meals { get; set; }
        public bool DeleteStatus { get; set; }
    }
}
