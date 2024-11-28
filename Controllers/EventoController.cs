using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backendPruebaNexti.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace backendPruebaNexti.Controllers
{
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository repoEvento;
        private readonly ILogger<EventoController> logger;

        public EventoController( IEventoRepository repository )
        {
            repoEvento = repository;
        }

        [HttpGet]
        [Route("/getAllEvento")]
        public async Task<IActionResult> GetAllEvento(
            [FromQuery] int page = 1, 
            [FromQuery] int limit = 5
        )
        {
            try
            {
                var eventos = await repoEvento.GetAllEventos(
                    page,
                    limit
                );
                if( eventos == null || !eventos.Any() )
                {
                    return NotFound( new {
                        ok = false,
                        msg = "No se encontraron eventos"
                    } );
                }
                
                return Ok( new {
                    ok = true,
                    data = eventos,
                    msg = "Consulta realizada con éxito",
                    page,
                    limit
                } );
                
            }
            catch ( Exception e )
            {
                return StatusCode(500, new { 
                    ok = false, 
                    msg = "Ocurrió un error inesperado.",
                    e.Message
                });
            }
        }

    }
}