using MvcWithDiContainerDemo.Data.Entities;
using MvcWithDiContainerDemo.Data.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace MvcWithDiContainerDemo.Data.Repositories
{
    public class MessageRepository : Repository<Message>
    {
        public MessageRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override Message GetById(object id)
        {
            return _objectSet.SingleOrDefault(s => s.MessageId == (int)id);
        }
    }
}