using LibraryApp.DAL;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace LibraryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Libaries()
        {
            List<LibaryModdel> libaries = Data.Get.Libary.ToList();
            return View(libaries);
        }
        public IActionResult shelvs()
        {
            List<ShelfModel> shelfs = Data.Get.shelf.ToList();
            return View(shelfs);
        }
        public IActionResult books()
        {
            List<BookModel> books = Data.Get.Book.ToList();
            return View(books);
        }


        public IActionResult CreatLibary()
        {
            return View(new LibaryModdel());
        }


        public IActionResult CreatBook(int id)
        {
            return View(new BookModel());
        }


        public int bookList(string shelf)
        {
            int shelf_num = int.Parse(shelf);
            
            List<BookModel> b = Data.Get.Book.ToList();

            ShelfModel? s = Data.Get.shelf.FirstOrDefault(s => s.Id == shelf_num);

            int totalWidth = 0;
            foreach (BookModel boo in b)
            {
                int n = int.Parse(boo.shelf);
                if (n == shelf_num)
                {
                    totalWidth += boo.width;
                }
            }
            return totalWidth;
        }



        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CreateBook(BookModel book)
        {
            int shelf_id = int.Parse(book.shelf);
            int totalWidth = bookList(book.shelf);
            ShelfModel ? s = Data.Get.shelf.FirstOrDefault(s => s.Id == shelf_id);

            if (book == null)
            {
                return NotFound();
            }



            if (totalWidth > s.width )
            {
                return BadRequest("אין מקום במדף אנא חפש מדף אחד");
            }


            ShelfModel? shelf = Data.Get.shelf.FirstOrDefault(s => s.Id == shelf_id);
            if (shelf == null)
            {
                return NotFound();
            }
            int bookHight = int.Parse(book.hight);
            int shelfHight = int.Parse(shelf.hight);           
            if (bookHight > shelfHight)
            {
                return BadRequest("גבוה מדי  ");
            }


            if (bookHight < shelfHight)
            {
                Data.Get.Book.Add(book);
                Data.Get.SaveChanges();
                if (shelfHight - 10 > bookHight)
                {
                    return BadRequest("נותר יותר נ 10 סנטימטר");
                }
            }
            return RedirectToAction("books");
               
        }


        


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CreatLibary(LibaryModdel libaryModdel)
        {
            Data.Get.Libary.Add(libaryModdel);
            Data.Get.SaveChanges();
            return RedirectToAction("Libaries");
        }


        public IActionResult CreateShelf()
        {
            return View(new ShelfModel());
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CreateShelf1(ShelfModel newShelf)
        {
            if (newShelf == null)
            {
                return NotFound();
            }

            LibaryModdel? lib = Data.Get.Libary.FirstOrDefault(l => l.genre == newShelf.libary);
            if (lib == null)
            {
                return BadRequest();
            }
            Data.Get.shelf.Add(newShelf);
            Data.Get.SaveChanges();
            return RedirectToAction("shelvs");
        }






































        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
