using System;
using System.Collections.Generic;

namespace APICenterFlit.Entities;

public partial class AccessLog
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string? DeviceName { get; set; }

    public string? DeviceType { get; set; }

    public string? BrowserName { get; set; }

    public string? UserAgent { get; set; }

    public string? IpPublic { get; set; }

    public string? LocationAddress { get; set; }

    /// <summary>
    /// 0-admin, 1-portal
    /// </summary>
    public int? SystemType { get; set; }

    public int? Status { get; set; }

    public DateTime? Timer { get; set; }
}
