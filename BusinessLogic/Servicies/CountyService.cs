using BusinessEntities.Entities;
using BusinessLogic.Base;
using DataAcces.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Servicies
{
    public class CountyService : BaseService
    {
        public CountyService(UnitOfWork unitOfWork)
            : base (unitOfWork)
        {
        }

        public List<County> GetAll()
        {
            return unitOfWork.Counties
                .Get()
                .ToList();
        }

        public bool Add(County county)
        {
            unitOfWork.Counties.Add(county);

            return unitOfWork.Save();
        }

        public bool Remove(County county)
        {
            unitOfWork.Counties.Remove(county);

            return unitOfWork.Save();
        }

        public bool Add(string county)
        {
            unitOfWork.Counties.Add(new County
            {
                Name = county
            });

            return unitOfWork.Save();
        }
    }
}
