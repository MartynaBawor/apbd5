using Microsoft.AspNetCore.Mvc;
using Tutorial4.Database;
using Tutorial4.Models;

namespace Tutorial4.Controllers;

[ApiController]
[Route("/animals-controller")]
public class AnimalsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(StaticData.Animals);
    }

    [HttpGet("{id}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = StaticData.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult AddAnimal(Animal animal)
    {
        StaticData.Animals.Add(animal);
        return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var existingAnimal = StaticData.Animals.FirstOrDefault(a => a.Id == id);
        if (existingAnimal == null)
        {
            return NotFound();
        }
        existingAnimal.Id = animal.Id;
        existingAnimal.Name = animal.Name;
        existingAnimal.Category = animal.Category;
        existingAnimal.Weight = animal.Weight;
        existingAnimal.FurColor = animal.FurColor;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = StaticData.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }
        StaticData.Animals.Remove(animal);
        return NoContent();
    }
}