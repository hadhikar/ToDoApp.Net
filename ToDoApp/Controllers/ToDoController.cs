using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Data;
using ToDoApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.Controllers;

public class ToDoController : Controller
{
    private readonly ApplicationDdContext _db;

    public ToDoController(ApplicationDdContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Index()
    {
        //var objToDoList = _db.ToDos.ToList();
        //return View();

        IEnumerable<ToDo> objToDoList = _db.ToDos;
        return View(objToDoList);
    }

    //create 
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ToDo obj)
    {
        if (obj.Name == "")
        {
            ModelState.AddModelError("name", "The Name field is required");
        }
        if (ModelState.IsValid)
        {
            //add to db
            _db.ToDos.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", "ToDo");
        }
        return View(obj);

    }

    //Edit
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var todoFromDb = _db.ToDos.Find(id);
        if (todoFromDb == null)
        {
            return NotFound();
        }
        return View(todoFromDb);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(ToDo obj)
    {
        if (obj.Name == "")
        {
            ModelState.AddModelError("name", "The Name field is required");
        }
        if (ModelState.IsValid)
        {
            //add to db
            _db.ToDos.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", "ToDo");
        }
        return View(obj);

    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        // Get the Todo item from the database.
        var todoItem = await _db.ToDos.FindAsync(id);
        if (todoItem != null)
        {
            // Delete the Todo item from the database.
            _db.ToDos.Remove(todoItem);

            // Save the changes to the database.
            _db.SaveChanges();
        }
        // Redirect the user back to the index page.
        //return RedirectToAction("Index", "ToDo");
        return RedirectToAction("Index", "ToDo");
    }

}

