using Microsoft.AspNetCore.Mvc;
using Tutorial4.Database;
using Tutorial4.Models;

namespace Tutorial4.Controllers;

[ApiController]
[Route("/visits")]
public class VisitsController : ControllerBase
{

    [HttpGet("{animalId}")]
    public IActionResult GetVisits(int animalId)
    {
        var visits = StaticData.Visits.Where(v => v.Animal.Id == animalId).ToList();
        return Ok(visits);
    }

    [HttpPost]
    public IActionResult AddVisit(Visit visit)
    {
        StaticData.Visits.Add(visit);
        return CreatedAtAction(nameof(GetVisits), new { animalId = visit.Animal.Id }, visit);
    }
}