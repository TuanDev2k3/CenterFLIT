using System;
using System.Collections.Generic;

namespace APICenterFlit.Entities;

public partial class VertifyAccount
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string? ActiveCode { get; set; }

    public int VertifyType { get; set; }

    public int Deadline { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }
}
