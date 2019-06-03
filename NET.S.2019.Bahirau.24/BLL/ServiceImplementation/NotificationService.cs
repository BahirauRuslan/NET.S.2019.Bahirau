using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class NotificationService : RepositoryService<Notification, DTONotification>, INotificationService
    {
        public NotificationService(IRepository<DTONotification> repository) : base(repository)
        {
        }
    }
}
