using TodoList.Entities;
using TodoList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using System;

public class HotelController : Controller
{
    private readonly TodoListContext _context;
    private readonly IWebHostEnvironment _hostEnvironment;

    public HotelController(TodoListContext context, IWebHostEnvironment hostEnvironment)
    {
        _context = context;
        _hostEnvironment = hostEnvironment;
    }

    [HttpGet]
    public IActionResult AddHotel()
    {
        var model = new AddHotelViewModel(); 

        var roomTypes = _context.TypeOfRooms.ToList();
        ViewData["RoomTypes"] = roomTypes;

        return View("~/Views/Management/Add/Add Hotel/Index.cshtml", model);
    }

    [HttpPost]
    public async Task<IActionResult> AddHotel(AddHotelViewModel model)
    {
        if (ModelState.IsValid)
        {
            var hotel = new Hotel
            {
                Name = model.Name,
                Rating = model.Rating,
                Description = model.Description
            };

            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();

            if (model.HotelImage != null)
            {
                string hotelImageFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads", "hotels");

                if (!Directory.Exists(hotelImageFolder))
                {
                    Directory.CreateDirectory(hotelImageFolder);
                }

                string hotelImagePath = Path.Combine(hotelImageFolder, Guid.NewGuid().ToString() + Path.GetExtension(model.HotelImage.FileName));

                using (var fileStream = new FileStream(hotelImagePath, FileMode.Create))
                {
                    await model.HotelImage.CopyToAsync(fileStream);
                }

                var hotelPhoto = new PhotosHotel
                {
                    FilePath = hotelImagePath,
                    HotelID = hotel.ID
                };

                _context.PhotosHotels.Add(hotelPhoto);
                await _context.SaveChangesAsync();
            }

            for (int i = 0; i < model.RoomDescriptions.Count; i++)
            {
                var room = new Room
                {
                    Description = model.RoomDescriptions[i],
                    CountOfPeople = model.RoomPeople[i],
                    CountOfRooms = model.RoomCount[i],
                    HotelID = hotel.ID,
                    TypeOfRoomID = model.RoomTypeIDs[i] 
                };

                _context.Rooms.Add(room);
                await _context.SaveChangesAsync();

                if (model.RoomImages != null && model.RoomImages.Count > 0)
                {
                    foreach (var roomImage in model.RoomImages)
                    {
                        if (roomImage != null)
                        {
                            string roomImageFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads", "rooms");

                            if (!Directory.Exists(roomImageFolder))
                            {
                                Directory.CreateDirectory(roomImageFolder);
                            }

                            string roomImagePath = Path.Combine(roomImageFolder, Guid.NewGuid().ToString() + Path.GetExtension(roomImage.FileName));

                            using (var fileStream = new FileStream(roomImagePath, FileMode.Create))
                            {
                                await roomImage.CopyToAsync(fileStream);
                            }

                            var roomPhoto = new PhotosRoom
                            {
                                FilePath = roomImagePath,
                                RoomID = room.ID
                            };

                            _context.PhotosRooms.Add(roomPhoto);
                        }
                    }
                }

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Add", new { area = "Management" });


        }

        return View("~/Views/Management/Add/Add Hotel/Index.cshtml", model); 
    }
}


