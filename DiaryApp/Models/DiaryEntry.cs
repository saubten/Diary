using System.ComponentModel.DataAnnotations;

namespace DiaryApp.Models
{
    public class DiaryEntry
    {
        [Key] //DiaryEntryID and Id -> Don't need the [Key] Annotation
        public int Id { get; set; }

        [Required] //Makes it Non Nullable Field
        public string Title { get; set; } = string.Empty;

        //To handle a field which is set as Non Nullable 
        //public string Title { get; set; } = string.Empty; 
        //public required string Title { get; set; }  

        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        public DateTime Created { get; set; } = DateTime.Now;

    }
}
