using BusinessEntities.Entities;
using BusinessLogic.Base;
using DataAcces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BusinessLogic.Servicies
{
    public class FriendService : BaseService
    {
        public FriendService(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public bool AreFriends(User user, int id)
        {
            foreach (var friend in user.FriendsUser1)
                if (friend.User2Id == id)
                    return true;

            foreach (var friend in user.FriendsUser2)
                if (friend.User1Id == id)
                    return true;

            return false;
        }

        public bool FriendRequestSent(int fromId, int toId)
        {
            return unitOfWork.FriendsRequests.
                Query()
                .SingleOrDefault(fr => fr.UserFromId == fromId && fr.UserToId == toId) != null;
        }

        public User Get(int id)
        {
            return unitOfWork.Users
                .Query()
                .Include(u => u.FriendRequestsUserTo)
                    .ThenInclude(fr => fr.UserFrom)
                .Include(u => u.FriendsUser1)
                    .ThenInclude(f => f.User2)
                .Include(u => u.FriendsUser2)
                    .ThenInclude(f => f.User1)
                .SingleOrDefault(u => u.Id == id);
        }

        public bool AreFriends(int userId, int myId)
        {
            return unitOfWork.Friends
                .Query()
                .SingleOrDefault(f => (f.User1Id == userId && f.User2Id == myId) ||
                (f.User1Id == myId && f.User2Id == userId))
                == null
                ? false
                : true;
        }

        public void AddFriendRequest(int fromId, int toId)
        {
            unitOfWork.FriendsRequests
                .Add(new FriendRequest
                {
                    UserFromId = fromId,
                    UserToId = toId
                });

            unitOfWork.Save();
        }

        public void CancelRequest(int fromId, int toId)
        {
            unitOfWork.FriendsRequests.Remove(new FriendRequest
            {
                UserFromId = fromId,
                UserToId = toId
            });

            unitOfWork.Save();
        }

        public void AcceptRequest(int fromId, int toId)
        {
            CancelRequest(fromId, toId);
            unitOfWork.Friends.Add(new Friend
            {
                User1Id = fromId,
                User2Id = toId
            });

            unitOfWork.Save();
        }

        public void Unfriend(int id1, int id2)
        {
            var friendship = unitOfWork.Friends
                .Query()
                .SingleOrDefault(f => (f.User1Id == id1 && f.User2Id == id2) ||
                (f.User1Id == id2 && f.User2Id == id1));

            if (friendship == null)
                return;

            unitOfWork.Friends.Remove(friendship);
            unitOfWork.Save();
        }

        public void RemoveAllFor(int id)
        {
            unitOfWork.Friends.RemoveRange(
                unitOfWork.Friends
                .Query()
                .Where(f => f.User1Id == id || f.User2Id == id).ToList());

            unitOfWork.Save();

            unitOfWork.FriendsRequests.RemoveRange(
                unitOfWork.FriendsRequests
                .Query()
                .Where(fr => fr.UserFromId == id || fr.UserToId == id).ToList());

            unitOfWork.Save();
        }
    }
}
