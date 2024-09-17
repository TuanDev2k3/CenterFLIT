using System;
using System.Collections.Generic;

namespace APICenterFlit.Entities;

public partial class Image
{
    public int Id { get; set; }

    public int SerialId { get; set; }

    public string? RefId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? RelativeUrl { get; set; }

    public string? SmallUrl { get; set; }

    public string? MediumUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public int Status { get; set; }

    public DateTime? Timer { get; set; }
}
