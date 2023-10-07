using DSR_DataAccess.Models;
using DSR_DataAccess.Services;
using DSR_DataAccess.Utils.CommonModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace DSR.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService=adminService;
        }

        [HttpPost]
        public SuccessResponse AddHotel(Hotel hotel)
        {
            var result = _adminService.AddHotels(hotel);
            return result;
        }

        [HttpPost]
        public SuccessResponse AddRoom(Room room)
        {
            var result = _adminService.AddRooms(room);
            return result;
        }

        [HttpPost]
        public SuccessResponse AddAmendment(Amendment amendment)
        {
            var result = _adminService.AddAmendments(amendment);
            return result;
        }
        [HttpPost]
        public SuccessResponse AddRating(Rating rating)
        {
            var result = _adminService.AddRatings(rating);
            return result;
        }

        [HttpPost]
        public SuccessResponse AddContactDetails(ContactDetail contactDetail)
        {
            var result = _adminService.AddContactDetails(contactDetail);
            return result;
        }

        [HttpPost]
        public SuccessResponse AddLocation(Location location)
        {
            var result = _adminService.AddLocations(location);
            return result;
        }
        [HttpPost]
        public SuccessResponse AddAdditionalGuestCost(AdditionalGuestCost additionalGuestCost)
        {
            var result = _adminService.AddAdditionalGuestCost(additionalGuestCost);
            return result;
        }

        [HttpPost]
        public SuccessResponse AddUser(User user)
        {
            var result = _adminService.AddUsers(user);
            return result;
        }

        [HttpPost]
        public SuccessResponse AddImage(Image image)
        {
            var result = _adminService.AddImages(image);
            return result;
        }

        [HttpPost]
        public SuccessResponse AddAdmins(Dsradmin dsradmin)
        {
            var result = _adminService.AddAdmin(dsradmin);
            return result;
        }

        [HttpGet]
        public List<Hotel>  GetHotels(int? hotelid)
        {
            var result=_adminService.GetHotels(hotelid);
            return result;
        }

        [HttpGet]
        public List<Room> GetRooms(int? roomid)
        {
            var result=_adminService.GetRooms(roomid);
            return result;
        }

        [HttpGet]
        [Authorize]

        public List<Amendment> GetAmendments(int? amendmentid)
        {
            var result=_adminService.GetAmendments(amendmentid);
            return result;
        }

        [HttpGet]
        public List<Rating> GetRatings(int? reviewid)
        {
            var result=_adminService.GetRatings(reviewid);
            return result;
        }

        [HttpGet]
        public List<ContactDetail> GetContactDetails(int? reviewid)
        {
            var result=_adminService.GetContactDetails(reviewid);
            return result;

        }

        [HttpGet]
        public List<Location> GetLocations(int? locationid)
        {
            var result= _adminService.GetLocations(locationid);
            return result;
        }

        [HttpGet]
        public List<AdditionalGuestCost> GetAdditionalGuestCosts(int? additionguestid)
        {
            var result = _adminService.GetAdditionalGuestCosts(additionguestid);
            return result;
        }

        [HttpGet]
        public List<User> GetUsers(int? userid)
        {
            var result=_adminService.GetUsers(userid);
            return result;
        }

        [HttpGet]
        public List<Image> GetImages(int? imageid)
        {
            var result=_adminService.GetImages(imageid);
            return result;
        }

        [HttpGet]
        public List<Dsradmin> GetDsradmins(int? adminid)
        {
            var result = _adminService.GetDsradmins(adminid);
            return result;
        }
    }
}
