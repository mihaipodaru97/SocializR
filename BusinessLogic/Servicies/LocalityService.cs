using BusinessEntities.Entities;
using BusinessLogic.Base;
using DataAcces.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Servicies
{
    public class LocalityService : BaseService
    {
        public LocalityService(UnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
        }

        public List<Locality> GetById(int countyId)
        {
            return unitOfWork.Localities
                .Query()
                .Where(l => l.CountyId == countyId)
                .ToList();
        }

        public bool Add(string locality, int countyId)
        {
            unitOfWork.Localities.Add(new Locality {
                CountyId = countyId,
                Name = locality
            });

            return unitOfWork.Save();
        }
    }
}
