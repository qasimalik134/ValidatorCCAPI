using CreditCardValidatorApi.Application.Interfaces;

namespace CreditCardValidatorApi.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        //public UnitOfWork(ITaskRepository taskRepository, IBankTypeRepository bankTypeRepository)
        public UnitOfWork( ICardRepository cardRepository)

        {
            //Tasks = taskRepository;
            Card = cardRepository;
        }
        //public ITaskRepository Tasks { get; }
        public ICardRepository Card { get; }
       



    }
}
