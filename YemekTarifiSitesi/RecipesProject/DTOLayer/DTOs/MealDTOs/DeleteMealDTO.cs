using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.MealDTOs
{
    public class DeleteMealDTO
    {
        public int MealId { get; set; }
        public bool DeleteStatus { get; set; }
    }
}
