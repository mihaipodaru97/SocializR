using BusinessEntities.Entities;
using BusinessLogic.Base;
using DataAcces.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Servicies
{
    public class InterestService : BaseService
    {
        public InterestService(UnitOfWork unitOfWork) 
            :base(unitOfWork)
        {

        }

        public List<Interest> GetAll()
        {
            return unitOfWork.Interests
                .Query()
                .ToList();
        }

        public List<Interest> Get(string interestName, int numberOfInterests)
        {
            return unitOfWork.Interests
                .Query()
                .Where(i => i.Name.Contains(interestName))
                .OrderBy(i => i.Name)
                .Take(numberOfInterests)
                .ToList();
        }

        public Interest Get(int id)
        {
            return unitOfWork.Interests
                .Query()
                .SingleOrDefault(i => i.Id == id);
        }

        public bool Add(string interest)
        {
            unitOfWork.Interests.Add(new Interest {
                Name = interest
            });

            return unitOfWork.Save();
        }

        public void RemoveAllFor(int userId)
        {
            unitOfWork.UserInterests.RemoveRange(
                unitOfWork.UserInterests
                .Query()
                .Where(ui => ui.UserId == userId).ToList());

            unitOfWork.Save();
        }
    }
}
