using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Models.Entities;
using System.Data.Entity;

namespace eDiary.API.Models.EF
{
    public class UnitOfWork<T> : IUnitOfWork where T : DbContext
    {
        public UnitOfWork(T dbContext) => db = dbContext;

        private readonly DbContext db;

        public IRepository<AppUser> AppUserRepository => new Repository<AppUser>(db);
        public IRepository<AttachedFile> AttachedFilesRepository => new Repository<AttachedFile>(db);
        public IRepository<AttachedLink> AttachedLinkRepository => new Repository<AttachedLink>(db);
        public IRepository<CardStatus> CardStatusRepository => new Repository<CardStatus>(db);
        public IRepository<Comment> CommentRepository => new Repository<Comment>(db);
        public IRepository<Difficulty> DifficultyRepository => new Repository<Difficulty>(db);
        public IRepository<Folder> FolderRepository => new Repository<Folder>(db);
        public IRepository<Language> LanguageRepository => new Repository<Language>(db);
        public IRepository<Note> NoteRepository => new Repository<Note>(db);
        public IRepository<Priority> PriorityRepository => new Repository<Priority>(db);
        public IRepository<Project> ProjectRepository => new Repository<Project>(db);
        public IRepository<ProjectCategory> ProjectCategoryRepository => new Repository<ProjectCategory>(db);
        public IRepository<Section> SectionRepository => new Repository<Section>(db);
        public IRepository<Status> StatusRepository => new Repository<Status>(db);
        public IRepository<Subtask> SubtaskRepository => new Repository<Subtask>(db);
        public IRepository<Tag> TagRepository => new Repository<Tag>(db);
        public IRepository<TagReference> TagReferenceRepository => new Repository<TagReference>(db);
        public IRepository<Task> TaskRepository => new Repository<Task>(db);
        public IRepository<UserProfile> UserProfileRepository => new Repository<UserProfile>(db);
        public IRepository<UserSettings> UserSettingsRepository => new Repository<UserSettings>(db);
    }
}
