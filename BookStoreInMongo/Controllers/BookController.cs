using BookStoreInMongo.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookStoreInMongo.Controllers
{
    public class BookController : Controller
    {
        MongoClient client = new MongoClient("mongodb://127.0.0.1:27017/");
       // GET: List Of Book
        public ActionResult Index()
        {
            var database = client.GetDatabase("BookStoreInventory");
            var table = database.GetCollection<Book>("books");
            var books = table.Find(FilterDefinition<Book>.Empty).ToList();
            return View(books);
        }
        //get One Book 
        public ActionResult Details(string id)
        {
            var database = client.GetDatabase("BookStoreInventory");
            var table = database.GetCollection<Book>("books");
            var book = table.Find(b => b.Id == id).FirstOrDefault();
            return View(book);
        }
        //for create New [get by Default]
        public ActionResult Create() => View();
       
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            var database = client.GetDatabase("BookStoreInventory");
            var table = database.GetCollection<Book>("books");
            book.Id = Guid.NewGuid().ToString();
            table.InsertOne(book);
           // ViewBag.save = "created New Book Successfully";
            return RedirectToAction("Index");
        }
        public  ActionResult Edit(string id)
        {
            var database = client.GetDatabase("BookStoreInventory");
            var table = database.GetCollection<Book>("books");
            var bookEdit = table.Find(b => b.Id == id).FirstOrDefault();
            if (bookEdit==null)
            {
                return RedirectToAction("Index");
            }
            return View(bookEdit);
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (string.IsNullOrEmpty(book.Id))
            {
                ViewBag.msg = "please provide Id";
                return View(book);
            }
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            var database = client.GetDatabase("BookStoreInventory");
            var table = database.GetCollection<Book>("books");
            var oldBook = table.Find(b => b.Id == book.Id).FirstOrDefault();
            oldBook.Name = book.Name;
            oldBook.Price = book.Price;
            oldBook.Category = book.Category;
            oldBook.Author = book.Author;
            var newBook = table.ReplaceOne(a => a.Id == book.Id, oldBook);
            return RedirectToAction("index");
        }
      //delete One Book
        public ActionResult Delete(string id)
        {
            var database = client.GetDatabase("BookStoreInventory");
            var table = database.GetCollection<Book>("books");
            var book = table.Find(b => b.Id == id).FirstOrDefault();
            return View(book);
        }
        [HttpPost]
        public ActionResult Delete(Book book)
        {
            var database = client.GetDatabase("BookStoreInventory");
            var table = database.GetCollection<Book>("books");
            table.DeleteOne(c => c.Id == book.Id);
            return RedirectToAction("Index");
        }
    }
}