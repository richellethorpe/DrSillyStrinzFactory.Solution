using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq; 
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class MachineController : Controller
  {
    private readonly FactoryContext _db;

    public MachineController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
       List<Machine> model = _db.Machines.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]

    public ActionResult Create(Machine machine)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Machine thisMachine = _db.Machines    
                              .Include(machine => machine.EngineerMachineJoins)
                              .ThenInclude(engineerMachineJoin => engineerMachineJoin.Engineer)
                              .FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);                        
                              
    }

    public ActionResult AddEngineer(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "LastName");
      return View(thisMachine);
    }
     
    [HttpPost]
    public ActionResult AddEngineer(Machine machine, int engineerId)
    {
    #nullable enable
    EngineerMachineJoin? engineerMachineJoin = _db.EngineerMachineJoins.FirstOrDefault(EngineerMachineJoin => (EngineerMachineJoin.EngineerId == engineerId && EngineerMachineJoin.MachineId == machine.MachineId));
    #nullable disable
    if(engineerMachineJoin == null && engineerId !=0)
    {
    _db.EngineerMachineJoins.Add(new EngineerMachineJoin() {EngineerId = engineerId, MachineId = machine.MachineId});
    _db.SaveChanges();
    }
    return RedirectToAction("Details", new { id = machine.MachineId});
    }

    public ActionResult Delete(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");

    }

  }
}