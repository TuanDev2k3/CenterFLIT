namespace APICenterFlit.Models
{
	public class NewsDTO
	{
		public int Id { get; set; }

		public int NewsTypeId { get; set; }

		public string? NewsTypeName { get; set; }

		public string? NewstypeIdList { get; set; }

		public string Title { get; set; } = null!;

		public string? TitleSlug { get; set; }

		public string? Description { get; set; }

		public string Detail { get; set; } = null!;

		public int? ImageId { get; set; }

		public string? ImageList { get; set; }

		public int? IsHot { get; set; }

		public int? Sort { get; set; }

		public DateTime? PublishedAt { get; set; }
	}
}
