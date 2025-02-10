using System;
using System.Collections.Generic;

namespace HotelDomain.Model;

public partial class Hotelpl
{
    public int HotelId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int NumberOfRooms { get; set; }

    public decimal Rating { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
