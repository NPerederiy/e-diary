using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDiary.API.Models.Entities
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; } // Id (Primary key)
        [ForeignKey("UserProfile")]
        public int UserProfileId { get; set; } // UserProfileId
        public string PasswordHash { get; set; } // PasswordHash (length: 2147483647)
        public string Username { get; set; } // Username (length: 2147483647)

        // Foreign keys

        /// <summary>
        /// Parent UserProfile pointed by [AppUsers].([UserProlifeId]) (FK__AppUsers__UserPr__6E01572D)
        /// </summary>
        public virtual UserProfile UserProfile { get; set; } // FK__AppUsers__UserPr__6E01572D
    }
}
