using System.Linq.Expressions;
using ApiApplication.Domain.Entities;
using ApiApplication.Domain.Interfaces.Repositories;
using ApiApplication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiApplication.Infrastructure.Repository.Repositories
{
    public class ShowTimesRepository : IShowtimesRepository
    {
        private readonly CinemaContext _context;

        public ShowTimesRepository(CinemaContext context)
        {
            _context = context;
        }

        public  Task<ShowtimeEntity> GetWithMoviesByIdAsync(int id, CancellationToken cancel)
        {
            return  _context.ShowTimes
                .Include(x => x.Movie)
                .FirstOrDefaultAsync(x => x.Id == id, cancel);
        }

        public async Task<ShowtimeEntity> GetWithTicketsByIdAsync(int id, CancellationToken cancel)
        {
            return await _context.ShowTimes
                .Include(x => x.Tickets)
                .FirstOrDefaultAsync(x => x.Id == id, cancel);
        }

        public async Task<IEnumerable<ShowtimeEntity>> GetAllAsync(Expression<Func<ShowtimeEntity, bool>>? filter, CancellationToken cancel)
        {
            if (filter == null)
            {
                return await _context.ShowTimes
                .Include(x => x.Movie)
                .ToListAsync(cancel);
            }
            return await _context.ShowTimes
                .Include(x => x.Movie)
                .Where(filter)
                .ToListAsync(cancel);
        }

        public async Task<ShowtimeEntity> CreateShowtime(ShowtimeEntity showtimeEntity, CancellationToken cancel)
        {
            var showtime = await _context.ShowTimes.AddAsync(showtimeEntity, cancel);
            await _context.SaveChangesAsync(cancel);
            return showtime.Entity;
        }
    }
}
