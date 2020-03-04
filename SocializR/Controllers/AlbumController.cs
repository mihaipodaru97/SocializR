using AutoMapper;
using BusinessEntities.Entities;
using BusinessLogic.Servicies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocializR.Code;
using SocializR.Models;
using System.Collections.Generic;
using SocializR.Code.Security;

namespace SocializR.Controllers
{
    public class AlbumController : BaseController
    {
        private readonly CurrentUser currentUser;
        private readonly AlbumService albumService;
        private readonly FriendService friendService;

        public AlbumController(CurrentUser currentUser, FriendService friendService, 
            AlbumService albumService, IMapper mapper)
            :base(mapper)
        {
            this.friendService = friendService;
            this.currentUser = currentUser;
            this.albumService = albumService;
        }

        [HttpGet]
        [Authorize(Roles = Constants.Member)]
        public IActionResult AddAlbum()
        {
            return View(new CreateAlbumModel());
        }

        [HttpGet]
        [Authorize(Roles = Constants.Member)]
        public IActionResult Index()
        {
            var albums = albumService.GetAlbumsById(currentUser.Id);
            var model = new List<ViewAlbumsModel>();

            albums.ForEach(a => model.Add(mapper.Map<ViewAlbumsModel>(a)));

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = Constants.Member)]
        public IActionResult AddAlbum(CreateAlbumModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            albumService.AddAlbum(new Album
            {
                Name = model.Name,
                UserId = currentUser.Id
            });

            return RedirectToAction("Index", "Album");
        }

        [HttpGet]
        [Authorize(Roles = Constants.Member)]
        public IActionResult EditAlbum(int id)
        {
            if (currentUser.Id != albumService.GetUserId(id))
                return AccessDenied();

            var album = albumService.GetAlbumById(id);
            var model = mapper.Map<EditAlbumModel>(album);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = Constants.Member)]
        public void EditAlbumName(int albumId, string name)
        {
            if (currentUser.Id != albumService.GetUserId(albumId))
                return;

            albumService.EditAlbumName(currentUser.Id, albumId, name);
        }

        [HttpGet]
        public IActionResult ViewAlbum(int id)
        {
            var user = albumService.GetUser(id);
            var canSee = albumService.CanSee(currentUser.Id, user) || currentUser.CanViewProfile; 
            if (!canSee)
                return RedirectToAction("Index", "Feed");

            var photos = albumService.GetPhotos(id);
            var photosModel = new List<PhotoProfileModel>();

            if (photos != null)
                photos.ForEach(p => photosModel.Add(mapper.Map<PhotoProfileModel>(p)));

            return View(new ViewAlbumModel {
                Photos = photosModel,
                Name = albumService.GetAlbumName(id)
            });
        }
    }
}