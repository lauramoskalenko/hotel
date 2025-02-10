using System;
using System.Collections.Generic;

namespace HotelDomain.Model;

public partial class RoomType
{
    public int RoomTypeId { get; set; }

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
