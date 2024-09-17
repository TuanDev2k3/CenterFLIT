using System;
using System.Collections.Generic;

namespace APICenterFlit.Entities;

public partial class FileType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Extension { get; set; }

    public int? Status { get; set; }
}
