using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.VisitorApiDTOs
{
    public class GetListVisitorDTO
    {
        public int VisitorId { get; set; }
        public string NameSurname { get; set; }
        public string Mail { get; set; }

    }
}
