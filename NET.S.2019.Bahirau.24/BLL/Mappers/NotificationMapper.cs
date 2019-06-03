using System.Collections.Generic;
using AutoMapper;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class NotificationMapper
    {
        public static DTONotification ToDTONotification(this Notification notification)
        {
            return Mapper.Map<DTONotification>(notification);
        }

        public static Notification ToNotification(this DTONotification dtoNotification)
        {
            return Mapper.Map<Notification>(dtoNotification);
        }

        public static IEnumerable<DTONotification> ToDTONotifications(this IEnumerable<Notification> notifications)
        {
            return Mapper.Map<IEnumerable<DTONotification>>(notifications);
        }

        public static IEnumerable<Notification> ToNotifications(this IEnumerable<DTONotification> dtoNotifications)
        {
            return Mapper.Map<IEnumerable<Notification>>(dtoNotifications);
        }
    }
}
