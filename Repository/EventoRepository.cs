using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backendPruebaNexti.Data;
using backendPruebaNexti.Dto;
using backendPruebaNexti.Models;
using Microsoft.EntityFrameworkCore;

namespace backendPruebaNexti.Repository
{
    public interface IEventoRepository
    {
        Task<List<EventoDTO>> GetAllEventos( int page, int limit );
        //Task<EventoDTO> GetEventoById( int id );
        Task<EventoModel> CreateEventos( EventoModel model );
        Task<EventoModel> UpdateEvento( EventoModel model );
        Task<bool> DeleteEvento( int id );
    }


    public class EventoRepository : IEventoRepository
    {

        private readonly ApplicationDbContext contextEvento;
        public EventoRepository( ApplicationDbContext context )
        {
            contextEvento = context;
        }

        public async Task<List<EventoDTO>> GetAllEventos( int page, int limit )
        {
            var eventos = await contextEvento.evento
                .Skip((page - 1) * limit)
                .Take(limit)
                .Select(e => new EventoDTO
                {
                    IdEvento = e.IdEvento,
                    DescripcionEvento = e.DescripcionEvento,
                    LugarEvento = e.LugarEvento,
                    PrecioEvento = e.PrecioEvento,
                    FechaEvento = e.FechaEvento,
                })
                .ToListAsync();

            return eventos;
        }

        public async Task<EventoModel> CreateEventos ( 
            EventoModel model
         )
         {
            contextEvento.evento.Add( model );
            await contextEvento.SaveChangesAsync();
            return model;
         }

         public async Task<EventoModel> UpdateEvento(
            EventoModel model
           )
         {
            contextEvento.evento.Update(model);
            await contextEvento.SaveChangesAsync();
            return model;
         }

         public async Task<bool> DeleteEvento( int id )
         {
            var model = await contextEvento.evento.FindAsync(id);
            if( model == null )
            {
                return false;
            }
            model.Estado = false;
            contextEvento.evento.Update(model);
            await contextEvento.SaveChangesAsync();

            return true;

         }

        
    }
}