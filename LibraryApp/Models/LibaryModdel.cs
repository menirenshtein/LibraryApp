using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class LibaryModdel
    {
        [Key]
        public int Id { get; set; }


        [Display(Name ="ז'אנר")]
        public string genre {get; set; }
    }
}
