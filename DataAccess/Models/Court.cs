using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models;

public partial class Court
{
    public int CoId { get; set; }

    public string CoName { get; set; } = null!;

    public string? CoPath { get; set; }
    [NotMapped]
    public string AbsoluteCoPath => System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..", CoPath);
    public bool CoStatus { get; set; }

    public string CoAddress { get; set; } = null!;

    public string CoInfo { get; set; } = null!;

    public double? CoPrice { get; set; }

    public int UserId { get; set; }

    public string? CoBeneficiaryAccountName { get; set; }

    public string? CoBeneficiaryPayPalEmail { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<CourtCondition> CourtConditions { get; set; } = new List<CourtCondition>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual ICollection<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();

    public virtual User User { get; set; } = null!;
}
