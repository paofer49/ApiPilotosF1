using Microsoft.AspNetCore.Mvc;
using ApiPilotosF1.Model;
using System.ComponentModel.DataAnnotations;

namespace ApiPilotosF1.Controllers
{
    [ApiController]
    [Route("api/pilotos")]
    public class ControllerPiloto : ControllerBase
    {
        private static List<Piloto> pilotos = new List<Piloto> {

            new Piloto {Id = 1, Name = "Max Verstappen", Number = 1 , Nationality = "Dutch", Team = "Red Bull Racing F1 Team"},
            new Piloto {Id = 2, Name = "Lewis Hamilton", Number = 44 , Nationality = "British", Team = "Scuderia Ferrari HP"},
            new Piloto {Id = 3, Name = "Charles Leclerc", Number = 16 , Nationality = "Monegasque", Team = "Scuderia Ferrari HP"},
            new Piloto {Id = 4, Name = "Lando Norris", Number = 4 , Nationality = "British", Team = "McLaren F1 Team"},
            new Piloto {Id = 5, Name = "Carlos Sainz", Number = 55 , Nationality = "Spanish", Team = "Atlassian Williams Racing"},
            new Piloto {Id = 6, Name = "George Russell", Number = 63 , Nationality = "British", Team = "Mercedes-AMG Petronas Formula One Team"},
            new Piloto {Id = 7, Name = "Fernando Alonso", Number = 14 , Nationality = "Spanish", Team = "Aston Martin Aramco Cognizant Formula One Team"},
            new Piloto {Id = 8, Name = "Oscar Piastri", Number = 81 , Nationality = "Australian", Team = "McLaren F1 Team"},
        };

        [HttpGet]
        public ActionResult<IEnumerable<Piloto>> GetAll() => Ok(pilotos);

        [HttpGet("{id}")]
        public ActionResult<Piloto> GetById(int id)
        {
            var piloto = pilotos.FirstOrDefault(p => p.Id == id);
            return piloto != null ? Ok(piloto) : NotFound();
        }

        [HttpPost]
        public ActionResult<Piloto> Create(Piloto piloto)
        {
            piloto.Id = pilotos.Any() ? pilotos.Max(p => p.Id) + 1 : 1;
            pilotos.Add(piloto);
            return CreatedAtAction(nameof(GetById), new { id = piloto.Id }, piloto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Piloto updatedPiloto)
        {
            var piloto = pilotos.FirstOrDefault(p => p.Id == id);
            if (piloto == null) 
            {
                return NotFound();
            }

            piloto.Name = updatedPiloto.Name;
            piloto.Number = updatedPiloto.Number;
            piloto.Team = updatedPiloto.Team;
            piloto.Nationality = updatedPiloto.Nationality;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var piloto = pilotos.FirstOrDefault(p => p.Id == id);
            if (piloto == null)
            {
                return NotFound();
            }

            pilotos.Remove(piloto);
            return NoContent();
        }
    }
}
