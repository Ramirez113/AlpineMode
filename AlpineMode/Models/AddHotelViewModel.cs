public class AddHotelViewModel
{
    public string Name { get; set; }
    public double Rating { get; set; }
    public string Description { get; set; }

    public IFormFile HotelImage { get; set; }

    public List<string> RoomDescriptions { get; set; } = new List<string>();
    public List<int> RoomPeople { get; set; } = new List<int>();
    public List<int> RoomCount { get; set; } = new List<int>();
    public List<IFormFile> RoomImages { get; set; } = new List<IFormFile>();

    public List<int> RoomTypeIDs { get; set; } = new List<int>();
}
