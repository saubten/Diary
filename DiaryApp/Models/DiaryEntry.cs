using System.ComponentModel.DataAnnotations;

namespace DiaryApp.Models
{
    public class DiaryEntry
    {
        [Key] //DiaryEntryID and Id -> Don't need the [Key] Annotation
        public int Id { get; set; }


        [Required(ErrorMessage ="Bro you gotta enter Title")]
        //Required - Makes it Non Nullable Field
        //Error Message Takes care of the Validation of the Non Nullable Field
        [StringLength(100,MinimumLength =3,ErrorMessage ="Bro Title must be between 3 and 100 length!!")]
        //StringLength - Max Min length along with the Error Message is setup
        public string Title { get; set; } = string.Empty;

        //To handle a field which is set as Non Nullable 
        //public string Title { get; set; } = string.Empty; 
        //public required string Title { get; set; }  

        [Required(ErrorMessage = "Bro you forgot to enter Content")]//Makes it Non Nullable Field
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Bro Title must be between 3 and 100 length!!")]
        public string Content { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lazy bastard just enter the Date")]//Makes it Non Nullable Field    
        public DateTime Created { get; set; } = DateTime.Now;

    }
}
