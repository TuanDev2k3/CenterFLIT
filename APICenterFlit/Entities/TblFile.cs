using System;
using System.Collections.Generic;

namespace APICenterFlit.Entities;

public partial class TblFile
{
    public int Id { get; set; }

    public string Guid { get; set; } = null!;

    public string Fname { get; set; } = null!;

    public byte[] Fcontent { get; set; } = null!;

    public string FcontentType { get; set; } = null!;

    public string Fextension { get; set; } = null!;

    public long Fsize { get; set; }

    /// <summary>
    /// Các id của table nào muốn dùng file
    /// </summary>
    public int TableId { get; set; }

    public int Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }
}
