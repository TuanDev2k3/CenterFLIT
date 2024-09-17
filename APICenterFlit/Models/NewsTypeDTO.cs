namespace APICenterFlit.Models
{
	public class NewsTypeDTO
	{
		public int Id { get; set; }

		public int? ParentId { get; set; }

		public string Title { get; set; } = null!;

		public string? TitleSlug { get; set; }

		public int? Sort { get; set; }

		public int? Status { get; set; }

		public int? ImageId { get; set; }

		public string? Remark { get; set; }

		public int? PortalId { get; set; }
	}
}
