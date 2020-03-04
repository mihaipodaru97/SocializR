using BusinessEntities.Entities;
using BusinessLogic.Base;
using DataAcces.Base;
using System;
using System.Linq;

namespace BusinessLogic.Servicies
{
    public class CommentService : BaseService
    {
        public CommentService(UnitOfWork unitOfWork) 
            :base(unitOfWork)
        {
        }

        public void AddComment(Comment comment)
        {
            comment.CreationDate = DateTime.Now;

            unitOfWork.Comments.Add(comment);

            unitOfWork.Save();
        }

        public void RemoveAllFor(int userId)
        {
            unitOfWork.Comments.RemoveRange(
                unitOfWork.Comments
                .Query()
                .Where(c => c.UserId == userId).ToList());

            unitOfWork.Save();
        }
    }
}
