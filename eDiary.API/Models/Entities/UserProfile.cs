using System.ComponentModel.DataAnnotations;

namespace eDiary.API.Models.Entities
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; } // Id (Primary key)
        public string FirstName { get; set; } // FirstName (length: 2147483647)
        public string LastName { get; set; } // LastName (length: 2147483647)
        public string Email { get; set; } // Email

        // Reverse navigation

        /// <summary>
        /// Child AppUsers where [AppUsers].[UserProlifeId] point to this entity (FK__AppUsers__UserPr__6E01572D)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<AppUser> AppUsers { get; set; } // AppUsers.FK__AppUsers__UserPr__6E01572D
        /// <summary>
        /// Child Projects where [Projects].[UserId] point to this entity (FK__Projects__UserId__46E78A0C)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Project> Projects { get; set; } // Projects.FK__Projects__UserId__46E78A0C
        /// <summary>
        /// Child ProjectCategories where [ProjectCategories].[UserId] point to this entity (FK__ProjectCa__UserI__4316F928)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<ProjectCategory> ProjectCategories { get; set; } // ProjectCategories.FK__ProjectCa__UserI__4316F928
        /// <summary>
        /// Child UserSettings where [UserSettings].[UserId] point to this entity (FK__UserSetti__UserI__72C60C4A)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<UserSettings> UserSettings { get; set; } // UserSettings.FK__UserSetti__UserI__72C60C4A

        public UserProfile()
        {
            AppUsers = new System.Collections.Generic.List<AppUser>();
            ProjectCategories = new System.Collections.Generic.List<ProjectCategory>();
            Projects = new System.Collections.Generic.List<Project>();
            UserSettings = new System.Collections.Generic.List<UserSettings>();
        }
    }
}
