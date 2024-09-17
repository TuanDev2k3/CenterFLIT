namespace APICenterFlit.Models
{
	public class AccountDTO
	{
		public int Id { get; set; }

		public string UserName { get; set; } = null!;

		public string FullName { get; set; } = null!;

		public string Password { get; set; } = null!;

		public string Email { get; set; } = null!;

		public string AccountType { get; set; } = null!;

		public string? Phone { get; set; }

		public DateTime? Birthday { get; set; }

		public int? AddressId { get; set; }

		public int? ImageId { get; set; }

		public string? Remark { get; set; }
	}
}
