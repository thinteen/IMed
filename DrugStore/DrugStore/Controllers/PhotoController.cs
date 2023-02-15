using DrugStore.Repositories.PhotoRepository;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore.Controllers
{
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoRepository _photoRepository;

        public PhotoController(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        [HttpPost]
        [Route("SavePhoto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<string> UploadPhoto(IFormFile file)
        {
            try
            {
                var result = await _photoRepository.WriteFile(file);

                return "{\"name\": \"" + result + "\"}";
            }
            catch (Exception)
            {
                return "{\"name\": \"default.png\"}";
            }
        }
    }
}
