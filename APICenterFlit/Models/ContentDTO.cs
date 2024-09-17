namespace APICenterFlit.Models
{
	public class ContentDTO
	{
		public int Id { get; set; }

		public int ContentTypeId { get; set; }

		public string Title { get; set; } = null!;

		public string? TitleSlug { get; set; }

		public string? Description { get; set; }

		public string? Detail { get; set; }

		public int? ImageId { get; set; }

		public string? ImageList { get; set; }

		public int? Sort { get; set; }

		public DateTime? PublishedAt { get; set; }

		public bool HomePage { get; set; }
	}
}
