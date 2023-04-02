using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;


namespace Factory.Controllers
{
  public class HomeController : Controller
  {
      private readonly FactoryContext _db;
      public HomeController(FactoryContext db)
      {
        _db = db;
      }


    [HttpGet("/")]
    public ActionResult Index()
    {
        Engineer[] engies = _db.Engineers.ToArray();
        Machine[] mechs = _db.Machines.ToArray();
        Dictionary<string,object[]> model = new Dictionary<string,object[]>();
        model.Add("engineers", engies);
        model.Add("machines", mechs);
        return View(model);
    }
  }
}