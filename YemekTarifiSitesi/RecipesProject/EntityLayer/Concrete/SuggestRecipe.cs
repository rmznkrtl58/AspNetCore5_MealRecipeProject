using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class SuggestRecipe
    {
        [Key] 
        public int RecipeId { get; set; }
        [StringLength(50)]
        public string Sender { get; set; }
        [StringLength(50)]
        public string SenderMail { get; set; }
        [StringLength(50)]
        public string SenderPhone { get; set; }
        public DateTime Date { get; set; }
        [StringLength(400)]
        public string Recipe { get; set; }
    }
}
