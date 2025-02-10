using System;
using System.Collections.Generic;

namespace HotelDomain.Model;

public partial class Booking
{
    public int BookingId { get; set; }

    public int RoomId { get; set; }

    public int GuestId { get; set; }

    public DateOnly CheckInDate { get; set; }

    public DateOnly CheckOutDate { get; set; }

    public int NumberOfGuests { get; set; }

    public virtual Guest Guest { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
