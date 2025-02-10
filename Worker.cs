using System;
using System.Collections.Generic;

namespace HotelDomain.Model;

public partial class Worker
{
    public int WorkerId { get; set; }

    public string FullName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int HotelId { get; set; }

    public int RoleId { get; set; }

    public virtual Hotelpl Hotel { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
