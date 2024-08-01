using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Models
{
    public class ShelfModel
    {
        
        
        [Key]
        public int Id { get; set; }


        [Display(Name ="גובה")]
        public string hight { get; set; }


        [Display(Name = "ז'אנר")]
        public string libary { get; set; }

        [Display(Name ="רוחב מדף")]
        public int width  { get; set; }
    }
}
