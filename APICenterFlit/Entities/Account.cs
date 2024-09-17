﻿using System;
using System.Collections.Generic;

namespace APICenterFlit.Entities;

public partial class Account
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string AccountType { get; set; } = null!;

    public int Status { get; set; }

    public string? Phone { get; set; }

    public DateTime? Birthday { get; set; }

    public int? AddressId { get; set; }

    public int? ImageId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public string? Remark { get; set; }
}
