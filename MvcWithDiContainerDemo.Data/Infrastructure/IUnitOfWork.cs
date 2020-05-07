using MvcWithDiContainerDemo.Data.Entities;

namespace MvcWithDiContainerDemo.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<Message> Messages { get; }
        void Save();
    }
}
