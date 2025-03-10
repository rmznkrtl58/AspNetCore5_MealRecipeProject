﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        [StringLength(50)]
        public string  Subject { get; set; }
        [StringLength(600)]
        public string  Content { get; set; }
        public DateTime MessageDate { get; set; }
        public bool DeleteStatus { get; set; }
        //Çoka Çok ilişki kullandım
        public AppUser SenderUser { get; set; }
        public AppUser ReceiverUser { get; set; }
    }
}
