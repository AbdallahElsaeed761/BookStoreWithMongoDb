using BookStoreInMongo.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Create() => View();
       
        [HttpPost]
        public ActionResult Create(Book book)
        {
            var database = client.GetDatabase("BookStoreInventory");
            var table = database.GetCollection<Book>("books");
          //  book._id = Guid.NewGuid().ToString();
            table.InsertOne(book);
           // ViewBag.save = "created New Book Successfully";
            return RedirectToAction("Index");
        }
    }
}