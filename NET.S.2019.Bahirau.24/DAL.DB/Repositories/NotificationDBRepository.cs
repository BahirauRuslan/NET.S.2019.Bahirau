using System.Data.Entity;
using DAL.Interface.DTO;

namespace DAL.DB.Repositories
{
    public class NotificationDBRepository : DBRepository<DTONotification>
    {
        public NotificationDBRepository(BankContext bankContext) : base(bankContext)
        {
        }

        protected override DbSet<DTONotification> ThisSet => BankContext.Notifications;
    }
}
