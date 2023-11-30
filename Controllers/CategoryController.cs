using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)    
        {
            _db = db; //this is to get db connection and apply opartions you do'nt need to write the sql Commnads 
        }


        public IActionResult Index() //URL Routing : IS Category/Index
        {            //then you  will need to pass this object to the view 
            List<Category> objCategoryList = _db.Categories.ToList();  //asing the _db object to the Category Model
            return View(objCategoryList); //to pass it to the View
        }

        //this is Get Action Mehod 
        public IActionResult Create() 
        
        {

            return View();
        }
        //This is a post action Method
        [HttpPost]
        public IActionResult Create(Category obj) //this is in the index forecah loop
        {
            if (obj.Name == obj.DisplayOrder.ToString()) //check the inputs 
            {
                ModelState.AddModelError("name","the name and dispaly order can't be match");
            }
            if (ModelState.IsValid) //this is will check with data annotaiton with the model
            {
                _db.Categories.Add(obj); // to add to DB
                _db.SaveChanges(); // to save changes 
                TempData["success"] = "Catgory create successfully"; //this is temp data
                return RedirectToAction("Index");// to go to the orginal page using Rediract 
            }
            return View(obj); //rerutn to View
        }

        public IActionResult Edit(int? id)

        {
            if(id == null || id == 0)
            {
                return NotFound();// you will need an error page for this 
            }
            //to get the id:

            Category? categoryFromDb = _db.Categories.Find(id);  //to find id From category thare is three ways same as create validations
            
            

            if (categoryFromDb == null)
            {
                return NotFound();

            }//Else
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj) 
        {
            if (ModelState.IsValid) 
            {
                _db.Categories.Update(obj); 
                _db.SaveChanges();
                TempData["success"] = "Catgory Update successfully";
                return RedirectToAction("Index");
            }
            return View(obj); 
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound(); // You will need an error page for this 
            }
            Category? categoryFromDb = _db.Categories.Find(id); // Find category by ID
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges(); // Save changes after removal
            TempData["success"] = "Catgory Delete successfully";
            return RedirectToAction("Index");
        }
    }
}
