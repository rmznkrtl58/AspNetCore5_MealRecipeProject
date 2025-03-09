using System;

namespace DTOLayer.DTOs.EventDTOs
{
    public class EventListDTO
    {
        public int EventId { get; set; }
        public string MainHeader { get; set; }
        public string Price { get; set; }
        public string SubDescription { get; set; }
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public string Item3 { get; set; }
        public string Image { get; set; }
        public bool DeleteStatus { get; set; }
        public DateTime EventDate { get; set; }
    }
}
