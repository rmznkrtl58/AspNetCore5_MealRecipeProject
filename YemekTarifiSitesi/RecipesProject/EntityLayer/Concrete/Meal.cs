using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Meal
    {
        [Key]
        public int MealId { get; set; }
        [StringLength(50)]
        public string MealName { get; set; }
        [StringLength(200)]
        public string MainHeader { get; set; }
        [StringLength(300)]
        public string ShortDescription { get; set; }
        [StringLength(700)]
        public string LongDescription { get; set; }
        [StringLength(200)]
        public string MealImage { get; set; }
        //Bir yemek sadece bir kategoriye bağlıdır
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public bool DeleteStatus { get; set; }
        //ilişki
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public bool RecipeStatus { get; set; }
    }
}
