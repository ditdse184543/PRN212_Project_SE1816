using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Booking
{
    public int BId { get; set; }

    public int UserId { get; set; }

    public int CoId { get; set; }

    public string? BGuestName { get; set; }

    public string BBookingType { get; set; } = null!;

    public int? BTotalHours { get; set; }

    public virtual Court Co { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();

    public virtual User User { get; set; } = null!;
}
