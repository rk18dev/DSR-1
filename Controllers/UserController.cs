using DSR_DataAccess.Models;
using DSR_DataAccess.Services;
using DSR_DataAccess.Utils.CommonModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService=userService;
        }

        [HttpPost]
        public SuccessResponse addBooking(Booking booking)
        {
            var result=_userService.addBookings(booking);
            return result;
        }

        [HttpGet]
        public List<Booking> Getbookings(int? id)
        {
            var result = _userService.getBookings(id);
            return result;
        }
    }
}
