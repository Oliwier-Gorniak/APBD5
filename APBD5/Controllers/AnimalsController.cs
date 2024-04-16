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

    [HttpGet("{animalId}")]
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

    [HttpPut("{animalId}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var current = StaticData.Animals.FirstOrDefault(a => a.Id == id);
        if (current == null)
        {
            return NotFound();
        }
        current.Id = animal.Id;
        current.Name = animal.Name;
        current.Category = animal.Category;
        current.Weight = animal.Weight;
        current.FurColor = animal.FurColor;
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