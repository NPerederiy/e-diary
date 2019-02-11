using eDiary.API.Models.Entities;

namespace eDiary.API.Models.EF.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<AppUser> AppUserRepository { get; }
        IRepository<AttachedFile> AttachedFilesRepository { get; }
        IRepository<AttachedLink> AttachedLinkRepository { get; }
        IRepository<CardStatus> CardStatusRepository { get; }
        IRepository<Comment> CommentRepository { get; }
        IRepository<Difficulty> DifficultyRepository { get; }
        IRepository<Folder> FolderRepository { get; }
        IRepository<Language> LanguageRepository { get; }
        IRepository<Note> NoteRepository { get; }
        IRepository<Priority> PriorityRepository { get; }
        IRepository<Project> ProjectRepository { get; }
        IRepository<ProjectCategory> ProjectCategoryRepository { get; }
        IRepository<Section> SectionRepository { get; }
        IRepository<Status> StatusRepository { get; }
        IRepository<Subtask> SubtaskRepository { get; }
        IRepository<Tag> TagRepository { get; }
        IRepository<TagReference> TagReferenceRepository { get; }
        IRepository<Task> TaskRepository { get; }
        IRepository<UserProfile> UserProfileRepository { get; }
        IRepository<UserSettings> UserSettingsRepository { get; }
    }
}
