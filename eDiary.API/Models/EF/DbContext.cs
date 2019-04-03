using eDiary.API.Models.Entities;

namespace eDiary.API.Models.EF
{
    public class BasicDiaryDbContext : System.Data.Entity.DbContext
    {
        public System.Data.Entity.DbSet<AppUser> AppUsers { get; set; }
        public System.Data.Entity.DbSet<AttachedFile> AttachedFiles { get; set; }
        public System.Data.Entity.DbSet<AttachedLink> AttachedLinks { get; set; }
        public System.Data.Entity.DbSet<CardStatus> CardStatus { get; set; }
        public System.Data.Entity.DbSet<Comment> Comments { get; set; } 
        public System.Data.Entity.DbSet<Difficulty> Difficulties { get; set; }
        public System.Data.Entity.DbSet<Folder> Folders { get; set; }
        public System.Data.Entity.DbSet<Language> Languages { get; set; }
        public System.Data.Entity.DbSet<Note> Notes { get; set; }
        public System.Data.Entity.DbSet<Priority> Priorities { get; set; }
        public System.Data.Entity.DbSet<Project> Projects { get; set; }
        public System.Data.Entity.DbSet<ProjectCategory> ProjectCategories { get; set; }
        public System.Data.Entity.DbSet<Section> Sections { get; set; }
        public System.Data.Entity.DbSet<Status> Status { get; set; }
        public System.Data.Entity.DbSet<Subtask> Subtasks { get; set; }
        public System.Data.Entity.DbSet<Tag> Tags { get; set; }
        public System.Data.Entity.DbSet<TagReference> TagReferences { get; set; }
        public System.Data.Entity.DbSet<Task> Tasks { get; set; }
        public System.Data.Entity.DbSet<UserProfile> UserProfiles { get; set; }
        public System.Data.Entity.DbSet<UserSettings> UserSettings { get; set; }
        public System.Data.Entity.DbSet<Session> Sessions { get; set; }

        static BasicDiaryDbContext()
        {
            System.Data.Entity.Database.SetInitializer<BasicDiaryDbContext>(null);
        }

        public BasicDiaryDbContext()
            : base("Name=DefaultConnection")
        {
        }

        public BasicDiaryDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public BasicDiaryDbContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(connectionString, model)
        {
        }

        public BasicDiaryDbContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        public BasicDiaryDbContext(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }

        public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == System.DBNull.Value);
        }
    }
}
