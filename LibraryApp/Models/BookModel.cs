using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class BookModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="שם הספר")]
        public string name { get; set; }


        [Display(Name ="גובה")]
        public string hight { get; set; }


        [Display(Name ="מדף")]
        public string shelf { get; set; }



        [Display(Name = "רוחב ספר")]
        public int width { get; set; }

    }
}
