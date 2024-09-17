using System;
using System.Collections.Generic;

namespace APICenterFlit.Entities;

public partial class News
{
    public int Id { get; set; }

    public int NewsTypeId { get; set; }

    public string? NewstypeIdList { get; set; }

    public string Title { get; set; } = null!;

    public string? TitleSlug { get; set; }

    public string? Description { get; set; }

    public string Detail { get; set; } = null!;

    public int? ImageId { get; set; }

    public string? ImageList { get; set; }

    public string? LinkRef { get; set; }

    public int? LikeNumber { get; set; }

    public int? ViewNumber { get; set; }

    public int? IsHot { get; set; }

    public int? Status { get; set; }

    public int? Sort { get; set; }

    public DateTime? PublishedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual NewsType NewsType { get; set; } = null!;
}
