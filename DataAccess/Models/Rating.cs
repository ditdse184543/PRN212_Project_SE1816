using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Rating
{
    public int RatingId { get; set; }

    public int CourtId { get; set; }

    public int UserId { get; set; }

    public int? Rating1 { get; set; }

    public string? Review { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Court Court { get; set; } = null!;
}
