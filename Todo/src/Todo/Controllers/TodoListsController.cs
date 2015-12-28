using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Todo.Models;
using Microsoft.AspNet.Authorization;

namespace Todo.Controllers
{
    public class TodoListsController : Controller
    {
        private ApplicationDbContext _context;

        public TodoListsController(ApplicationDbContext context)
        {
            _context = context;    
        }


        // GET: TodoLists
        [Authorize]
        public IActionResult Index()
        {
            return View(_context.TodoListItems.ToList());
        }

        // GET: TodoLists/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TodoListItems todoListItems = _context.TodoListItems.Single(m => m.Id == id);
            if (todoListItems == null)
            {
                return HttpNotFound();
            }

            return View(todoListItems);
        }

        // GET: TodoLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TodoLists/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TodoListItems todoListItems)
        {
            if (ModelState.IsValid)
            {
                _context.TodoListItems.Add(todoListItems);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todoListItems);
        }

        // GET: TodoLists/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TodoListItems todoListItems = _context.TodoListItems.Single(m => m.Id == id);
            if (todoListItems == null)
            {
                return HttpNotFound();
            }
            return View(todoListItems);
        }

        // POST: TodoLists/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TodoListItems todoListItems)
        {
            if (ModelState.IsValid)
            {
                _context.Update(todoListItems);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todoListItems);
        }

        // GET: TodoLists/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TodoListItems todoListItems = _context.TodoListItems.Single(m => m.Id == id);
            if (todoListItems == null)
            {
                return HttpNotFound();
            }

            return View(todoListItems);
        }

        // POST: TodoLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            TodoListItems todoListItems = _context.TodoListItems.Single(m => m.Id == id);
            _context.TodoListItems.Remove(todoListItems);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
