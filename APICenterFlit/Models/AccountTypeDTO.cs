﻿namespace APICenterFlit.Models
{
	public class AccountTypeDTO
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string Code { get; set; } = null!;

		public string? Remark { get; set; }
	}
}
