using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDiary.API.Models.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public string Token { get; set; }
        public string CreatedAt { get; set; }
        
        public virtual AppUser AppUser { get; set; }
    }
}
