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
        [HttpPost]
        public IActionResult Create(DiaryEntry obj)//obj goes as the model to the view Create
        {
            if (obj != null && obj.Title.Length <3) {
                ModelState.AddModelError("Title", "Title too short brudda");// Server Side Validation
            }
            if (ModelState.IsValid)
            {
                _db.DiaryEntries.Add(obj);//Adds the obj to the database
                _db.SaveChanges();// Save the changes to the database
                return RedirectToAction("Index", "DiaryEntries");//After the Post Action it will send you back to the Index Page
            }

            return View(obj);
        }
        [HttpGet]
        public IActionResult Edit(int? id) 
        {
            if(id == null || id ==0)
            {
                return NotFound();
            }

            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);

            if (diaryEntry == null)
            {
                return NotFound();
            }

            return View(diaryEntry);
        }

        [HttpPost]
        public IActionResult Edit(DiaryEntry obj)//obj goes as the model to the view Edit
        {
            if (obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title too short brudda");// Server Side Validation
            }
            if (ModelState.IsValid)
            {
                _db.DiaryEntries.Update(obj);//Updates the Diary Entry in the Database
                _db.SaveChanges();// Save the changes to the database
                return RedirectToAction("Index");//After the Post Action it will send you back to the Index Page
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);

            if (diaryEntry == null)
            {
                return NotFound();
            }

            return View(diaryEntry);
        }

        [HttpPost]
        public IActionResult Delete(DiaryEntry obj)//obj goes as the model to the view Edit
        {
            if (obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title too short brudda");// Server Side Validation
            }
            if (ModelState.IsValid)
            {
                _db.DiaryEntries.Remove(obj);//Removes the Diary Entry in the Database
                _db.SaveChanges();// Save the changes to the database
                return RedirectToAction("Index");//After the Post Action it will send you back to the Index Page
            }

            return View(obj);
        }
    }
}
