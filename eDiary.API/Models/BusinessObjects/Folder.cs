namespace eDiary.API.Models.BusinessObjects
{
    public class Folder
    {
        public string Name { get; set; }
        public NoteCard[] Notes { get; set; }
        public Folder[] Folders { get; set; }
    }
}
