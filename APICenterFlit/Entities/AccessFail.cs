using System;
using System.Collections.Generic;

namespace APICenterFlit.Entities;

public partial class AccessFail
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string? DeviceName { get; set; }

    public string? DeviceType { get; set; }

    public string? BrowserName { get; set; }

    public string? UserAgent { get; set; }

    public string? IpPublic { get; set; }

    /// <summary>
    /// 0-admin, 1-portal
    /// </summary>
    public int? SystemType { get; set; }

    public int? TimeActive { get; set; }

    public DateTime? Timer { get; set; }
}
