using System;
using System.Collections.Generic;

namespace APICenterFlit.Entities;

public partial class Province
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ProvinceCode { get; set; } = null!;

    public decimal? AxisMeridian { get; set; }

    public int? CountryId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<District> Districts { get; set; } = new List<District>();
}
