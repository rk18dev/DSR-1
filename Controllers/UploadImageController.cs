using DSR.Models;
using DSR_DataAccess.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace DSR.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UploadImageController : ControllerBase
    {
        IUploadImageService _uploadImageService;
        public UploadImageController(IUploadImageService uploadImageService)
        {
            _uploadImageService = uploadImageService;
        }

        [HttpPost]
        public Response UploadImages([FromForm]FileModel fileModel)
        {
            var result=_uploadImageService.UploadImage(fileModel);
            return result;
        }
    }
}
