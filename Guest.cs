using System;
using System.Collections.Generic;

namespace HotelDomain.Model;

public partial class Guest
{
    public int GuestId { get; set; }

    public string FullName { get; set; } = null!;

    public string PassportNumber { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
