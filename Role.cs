using System;
using System.Collections.Generic;

namespace HotelDomain.Model;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
