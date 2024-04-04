using ApiApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace ApiApplication.Infrastructure.Data.Extension;

public static class DependenciesRegistration
{
    public static IServiceCollection AddInMemoryDbContext(this IServiceCollection services)
    {
        services.AddDbContext<CinemaContext>(options =>
        {
            options.UseInMemoryDatabase("CinemaDb")
                .EnableSensitiveDataLogging()
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        });

        return services;
    }

    public static void SeedData(this CinemaContext context)
    {
        context.Auditoriums?.Add(new AuditoriumEntity
        {
            Id = 1,
            Showtimes = new List<ShowtimeEntity> 
            { 
                new ShowtimeEntity
                {
                    Id = 1,
                    SessionDate = new DateTime(2023, 1, 1, 0,0,0, DateTimeKind.Utc),
                    Movie = new MovieEntity
                    {
                        Id = 1,
                        Title = "Inception",
                        ImdbId = "tt1375666",
                        ReleaseDate = new DateTime(2010, 01, 14,  0,0,0, DateTimeKind.Utc),
                        Stars = "Leonardo DiCaprio, Joseph Gordon-Levitt, Ellen Page, Ken Watanabe"                            
                    },
                    AuditoriumId = 1,
                } 
            },
            Seats = GenerateSeats(1, 28, 22)
        });

        context.Auditoriums?.Add(new AuditoriumEntity
        {
            Id = 2,
            Seats = GenerateSeats(2, 21, 18)
        });

        context.Auditoriums?.Add(new AuditoriumEntity
        {
            Id = 3,
            Seats = GenerateSeats(3, 15, 21)
        });

        context.SaveChanges();
    }
    
    private static List<SeatEntity> GenerateSeats(int auditoriumId, short rows, short seatsPerRow)
    {
        var seats = new List<SeatEntity>();
        for (short r = 1; r <= rows; r++)
        {
            for (short s = 1; s <= seatsPerRow; s++)
            {
                seats.Add(new SeatEntity { AuditoriumId = auditoriumId, Row = r, SeatNumber = s });
            }
        }
        
        return seats;
    }
}