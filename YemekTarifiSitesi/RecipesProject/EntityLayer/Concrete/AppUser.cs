using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        [StringLength(250)]
        public string ProfileImage { get; set; }
        [StringLength(25)]
        public string Name { get; set; }
        [StringLength(25)]
        public string Surname { get; set; }
        [StringLength(400)]
        public string About { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        [StringLength(100)]
        public string CityCounty { get; set; }
        [StringLength(200)]
        public string LinkedinUrl { get; set; }
        [StringLength(200)]
        public string InstagramUrl { get; set; }
        [StringLength(200)]
        public string TwitterUrl { get; set; }
        //çoka çok ilişki 
        //alıcı yazar ve gönderen yazar birden fazla mesaj yazabilir
        public ICollection<Message> SenderMessage { get; set; }
        public ICollection<Message> ReceiverMessage { get; set; }
        //bire çok ilişki
        public List<Meal> Meals { get; set; }

    }
}
