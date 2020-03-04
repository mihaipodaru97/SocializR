using BusinessEntities.Entities;
using BusinessLogic.Servicies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocializR.Code;
using SocializR.Models;
using SocializR.Code.ExtensionMethods;
using SocializR.Code.Security;

namespace SocializR.Controllers
{
    public class PhotoController : BaseController
    {
        private readonly PhotoService photoService;

        public PhotoController(PhotoService photoService)
        {
            this.photoService = photoService;
        }

        [ResponseCache(Duration = 60)]
        [HttpGet]
        public IActionResult GetPhoto(int id)
        {
            var photo = photoService.GetPhoto(id);

            if (photo != null)
                return File(photo, "image/jpeg");

            return NotFound();
        }

        [HttpGet]
        [Authorize(Roles = Constants.Member)]
        public IActionResult AddPhoto(int albumId)
        {
            return View(new PhotoModel
            {
                AlbumId = albumId
            });
        }

        [HttpPost]
        [Authorize(Roles = Constants.Member)]
        public IActionResult AddPhoto(PhotoModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            photoService.Add(new Photo {
                AlbumId = model.AlbumId,
                Description = model.Description,
                Image = model.Photo.GetFileBytes()
            });

            return RedirectToAction("EditAlbum", "Album", new { id = model.AlbumId });
        }

        [HttpPost]
        [Authorize(Roles = Constants.Member)]
        public IActionResult ChangePhotoDescription(int photoId, int albumId, string description)
        {
            photoService.ChangePhotoDescription(photoId, albumId, description);

            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = Constants.Member)]
        public IActionResult DeletePhoto(int photoId)
        {
            photoService.Delete(photoId);

            return Ok();
        }
    }
}