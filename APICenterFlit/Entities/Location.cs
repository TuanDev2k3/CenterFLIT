using System;
using System.Collections.Generic;

namespace APICenterFlit.Entities;

public partial class Location
{
    public int Id { get; set; }

    public int SerialId { get; set; }

    public string? RefId { get; set; }

    public string Name { get; set; } = null!;

    public int? Status { get; set; }

    public int? ShowUi { get; set; }

    public int? ReOrder { get; set; }

    public string? Remark { get; set; }

    public DateTime Timer { get; set; }

    public virtual ICollection<Banner> Banners { get; set; } = new List<Banner>();
}
