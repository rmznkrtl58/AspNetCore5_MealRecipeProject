using System.ComponentModel.DataAnnotations;

namespace MealRecipeApi.EntityLayer
{
    public class Visitor
    {
        [Key]
        public int VisitorId { get; set; }
        [StringLength(50)]
        public string NameSurname { get; set; }
        [StringLength(50)]
        public string Mail { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string City { get; set; }
    }
}
