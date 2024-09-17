using System;
using System.Collections.Generic;

namespace APICenterFlit.Entities;

public partial class StatusList
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string TableName { get; set; } = null!;

    public int Status { get; set; }

    public int? Sort { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public string? Remark { get; set; }

    public bool? Del { get; set; }
}
