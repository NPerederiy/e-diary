using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Models.Entities;
using System.Data.Entity;

namespace eDiary.API.Models.EF
{
    public class UnitOfWork<T> : IUnitOfWork where T : DbContext
    {
        public UnitOfWork(T dbContext) => db = dbContext;

        private readonly DbContext db;

        private readonly IRepository<AppUser> appUserRepository;
        private readonly IRepository<AttachedFile> attachedFilesRepository;
        private readonly IRepository<AttachedLink> attachedLinkRepository;
        private readonly IRepository<CardStatus> cardStatusRepository;
        private readonly IRepository<Comment> commentRepository;
        private readonly IRepository<Difficulty> difficultyRepository;
        private readonly IRepository<Folder> folderRepository;
        private readonly IRepository<Language> languageRepository;
        private readonly IRepository<Note> noteRepository;
        private readonly IRepository<Priority> priorityRepository;
        private readonly IRepository<Project> projectRepository;
        private readonly IRepository<ProjectCategory> projectCategoryRepository;
        private readonly IRepository<Section> sectionRepository;
        private readonly IRepository<Status> statusRepository;
        private readonly IRepository<Subtask> subtaskRepository;
        private readonly IRepository<Tag> tagRepository;
        private readonly IRepository<TagReference> tagReferenceRepository;
        private readonly IRepository<Task> taskRepository;
        private readonly IRepository<UserProfile> userProfileRepository;
        private readonly IRepository<UserSettings> userSettingsRepository;

        public IRepository<AppUser> AppUserRepository => appUserRepository ?? new Repository<AppUser>(db);
        public IRepository<AttachedFile> AttachedFilesRepository => attachedFilesRepository ?? new Repository<AttachedFile>(db);
        public IRepository<AttachedLink> AttachedLinkRepository => attachedLinkRepository ?? new Repository<AttachedLink>(db);
        public IRepository<CardStatus> CardStatusRepository => cardStatusRepository ?? new Repository<CardStatus>(db);
        public IRepository<Comment> CommentRepository => commentRepository ?? new Repository<Comment>(db);
        public IRepository<Difficulty> DifficultyRepository => difficultyRepository ?? new Repository<Difficulty>(db);
        public IRepository<Folder> FolderRepository => folderRepository ?? new Repository<Folder>(db);
        public IRepository<Language> LanguageRepository => languageRepository ?? new Repository<Language>(db);
        public IRepository<Note> NoteRepository => noteRepository ?? new Repository<Note>(db);
        public IRepository<Priority> PriorityRepository => priorityRepository ?? new Repository<Priority>(db);
        public IRepository<Project> ProjectRepository => projectRepository ?? new Repository<Project>(db);
        public IRepository<ProjectCategory> ProjectCategoryRepository => projectCategoryRepository ?? new Repository<ProjectCategory>(db);
        public IRepository<Section> SectionRepository => sectionRepository ?? new Repository<Section>(db);
        public IRepository<Status> StatusRepository => statusRepository ?? new Repository<Status>(db);
        public IRepository<Subtask> SubtaskRepository => subtaskRepository ?? new Repository<Subtask>(db);
        public IRepository<Tag> TagRepository => tagRepository ?? new Repository<Tag>(db);
        public IRepository<TagReference> TagReferenceRepository => tagReferenceRepository ?? new Repository<TagReference>(db);
        public IRepository<Task> TaskRepository => taskRepository ?? new Repository<Task>(db);
        public IRepository<UserProfile> UserProfileRepository => userProfileRepository ?? new Repository<UserProfile>(db);
        public IRepository<UserSettings> UserSettingsRepository => userSettingsRepository ?? new Repository<UserSettings>(db);
    }
}
