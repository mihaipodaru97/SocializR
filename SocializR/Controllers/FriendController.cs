using System.Collections.Generic;
using AutoMapper;
using BusinessLogic.Servicies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocializR.Code;
using SocializR.Models;
using SocializR.Code.Security;

namespace SocializR.Controllers
{
    public class FriendController : BaseController
    {
        private readonly FriendService friendService;
        private readonly CurrentUser currentUser;
        public FriendController(FriendService friendService, CurrentUser currentUser, IMapper mapper)
            :base(mapper)
        {
            this.currentUser = currentUser;
            this.friendService = friendService;
        }

        [Authorize(Roles = Constants.Member)]
        [HttpPost]
        public void AddFriendRequest(int id)
        {
            friendService.AddFriendRequest(currentUser.Id, id);
        }

        [Authorize(Roles = Constants.Member)]
        [HttpPost]
        public void CancelRequest(int id)
        {
            friendService.CancelRequest(id, currentUser.Id);
        }

        [Authorize(Roles = Constants.Member)]
        [HttpPost]
        public void AcceptRequest(int id)
        {
            friendService.AcceptRequest(id, currentUser.Id);
        }

        [Authorize(Roles = Constants.Member)]
        [HttpPost]
        public void Unfriend(int id)
        {
            friendService.Unfriend(id, currentUser.Id);
        }

        [Authorize(Roles = Constants.Member)]
        [HttpGet]
        public IActionResult ViewFriends()
        {
            var user = friendService.Get(currentUser.Id);
            var model = new ViewFriendModel
            {
                Friends = new List<FriendModel>(),
                Requests = new List<FriendModel>()
            };

            foreach(var friendRequest in user.FriendRequestsUserTo)
                model.Requests.Add(mapper.Map<FriendModel>(friendRequest.UserFrom));

            foreach (var friend in user.FriendsUser1)
                model.Friends.Add(mapper.Map<FriendModel>(friend.User2));

            foreach (var friend in user.FriendsUser2)
                model.Friends.Add(mapper.Map<FriendModel>(friend.User1));


            return View(model);
        }

    }
}