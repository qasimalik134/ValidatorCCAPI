namespace CreditCardValidatorApi.Application.Interfaces
{
    public interface IUnitOfWork
    {
        //ITaskRepository Tasks { get; }
        ICardRepository Card { get; }

    }
}