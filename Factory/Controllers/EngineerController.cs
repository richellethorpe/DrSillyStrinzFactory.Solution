using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq; 
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Factory.Controllers
{
  public class EngineerController : Controller
  {
    private readonly FactoryContext _db;

    public EngineerController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
       List<Engineer> model = _db.Engineers.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]

    public ActionResult Create(Engineer engineer)
    {
      if (!ModelState.IsValid)
      {
        return View(engineer);
      }
      else
      {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)
    {
      Engineer thisEngineer = _db.Engineers
                              .Include(engineers => engineers.EngineerMachineJoins)
                              .ThenInclude(join => join.Machine)
                              .FirstOrDefault(Engineer => Engineer.EngineerId == id);
      return View(thisEngineer);
    }

    public ActionResult AddMachine(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult AddMachine(Engineer engineer, int machineId)
    {
      #nullable enable
      EngineerMachineJoin? engineerMachineJoin = _db.EngineerMachineJoins.FirstOrDefault(EngineerMachineJoin => (EngineerMachineJoin.MachineId == machineId && EngineerMachineJoin.EngineerId == engineer.EngineerId));
      #nullable disable
      if(engineerMachineJoin == null && machineId != 0)
      {
        _db.EngineerMachineJoins.Add(new EngineerMachineJoin() {EngineerId = engineer.EngineerId, MachineId = machineId});
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new {id = engineer.EngineerId});
    }

    public ActionResult Edit (int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineers =>engineers.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer)
    {
      _db.Engineers.Update(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineers =>engineers.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineers =>engineers.EngineerId == id);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");

    }
  }
}