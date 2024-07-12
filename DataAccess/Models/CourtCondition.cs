using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class CourtCondition
{
    public int CdId { get; set; }

    public DateTime CdCreatedAt { get; set; }

    public int CdSurfaceCondition { get; set; }

    public int CdNetCondition { get; set; }

    public int CdLightningCondition { get; set; }

    public int CdCleanlinessCondition { get; set; }

    public int CdOverallCondition { get; set; }

    public string? CdNotes { get; set; }

    public int CoId { get; set; }

    public virtual Court Co { get; set; } = null!;
}
