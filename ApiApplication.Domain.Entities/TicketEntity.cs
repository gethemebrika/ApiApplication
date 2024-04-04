﻿namespace ApiApplication.Domain.Entities
{
    public class TicketEntity
    {
        public Guid Id { get; set; }
        public int ShowtimeId { get; set; }
        public ICollection<SeatEntity> Seats { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public bool Paid { get; set; } = false;
        public ShowtimeEntity Showtime { get; set; }
    }
}
