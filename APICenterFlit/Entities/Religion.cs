using System;
using System.Collections.Generic;

namespace APICenterFlit.Entities;

public partial class Religion
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public int? Status { get; set; }

    public string? Remark { get; set; }
}
