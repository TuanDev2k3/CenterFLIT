using System;
using System.Collections.Generic;

namespace APICenterFlit.Entities;

public partial class Banner
{
    public int Id { get; set; }

    public int SerialId { get; set; }

    public string? RefId { get; set; }

    public string? Title { get; set; }

    public string? DescShort { get; set; }

    public string? Url { get; set; }

    public int? ImageId { get; set; }

    public int? ClickNumber { get; set; }

    public int? LocationId { get; set; }

    public DateTime? StartAt { get; set; }

    public DateTime? EndAt { get; set; }

    public int IsNeverExpired { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime Timer { get; set; }

    public virtual Location? Location { get; set; }
}
