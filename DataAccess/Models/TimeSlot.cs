using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class TimeSlot
{
    public int TsId { get; set; }

    public DateOnly TsDate { get; set; }

    public string TsTime { get; set; } = null!;

    public bool TsCheckedIn { get; set; }

    public int CoId { get; set; }

    public int BId { get; set; }

    public virtual Booking BIdNavigation { get; set; } = null!;

    public virtual Court Co { get; set; } = null!;
}
