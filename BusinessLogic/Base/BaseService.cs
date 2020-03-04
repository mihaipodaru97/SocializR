using DataAcces.Base;

namespace BusinessLogic.Base
{
    public class BaseService
    {
        protected readonly UnitOfWork unitOfWork;

        public BaseService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
