using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiaryApp.Controllers
{
    public class DiaryEntriesController : Controller
    {

        private readonly ApplicationDBContext _db; // This is added so that we can read the SQL data through the Model option in the View

        public DiaryEntriesController(ApplicationDBContext db) 
        {
            // This is ddependancy injection, we are not creating any object of Application DB Context,
            // we are asking for it when the DiaryEntries Controller is being created.
            // This is possible cause we have added the Application DB Context in the Services which allows us to use it in any class/ controller that we wish to without crating an object of it every time.
            _db = db;
        }

        public IActionResult Index()
        {
            List<DiaryEntry> objDiaryEntryList = _db.DiaryEntries.ToList(); // Converts the SQL Table entries into a List object with Type Diary Entry

            return View(objDiaryEntryList); // objDiaryEntryList -> @model in the Index.csshtml of DiaryEntries
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
