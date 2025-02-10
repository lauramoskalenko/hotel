using System;
using System.Collections.Generic;

namespace HotelDomain.Model;

public partial class Room
{
    public int RoomId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public int RoomTypeId { get; set; }

    public int HotelId { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Hotelpl Hotel { get; set; } = null!;

    public virtual RoomType RoomType { get; set; } = null!;
}
