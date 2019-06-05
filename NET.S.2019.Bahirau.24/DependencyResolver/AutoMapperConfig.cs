using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.DTO;
using Ninject;

namespace DependencyResolver
{
    public static class AutoMapperConfig
    {
        static AutoMapperConfig()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigurateResolver();
        }

        private static IKernel Resolver { get; }

        public static void Configure()
        {
            Mapper.Initialize(cfg => 
            {
                cfg.BonusConfigure();
                cfg.HolderConfigure();
                cfg.NotificationConfigure();
                cfg.AccountTypeConfigure();
                cfg.AccountConfigure();
            });
        }

        private static void BonusConfigure(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Bonus, DTOBonus>()
                .ForMember(dest => dest.BonusPoints, opt => opt.MapFrom(src => src.Points));
            cfg.CreateMap<DTOBonus, Bonus>()
                .ForMember(dest => dest.Points, opt => opt.MapFrom(src => src.BonusPoints));
        }

        private static void HolderConfigure(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Holder, DTOHolder>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Accounts, opt => opt.Ignore())
                .ForMember(dest => dest.Notifications, opt => opt.Ignore());
            cfg.CreateMap<DTOHolder, Holder>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Accounts, opt => opt.Ignore())
                .ForMember(dest => dest.Notifications, opt => opt.Ignore());
        }

        private static void NotificationConfigure(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Notification, DTONotification>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.Holder, opt => opt.MapFrom(src => Mapper.Map<Holder, DTOHolder>(src.Holder)));
            cfg.CreateMap<DTONotification, Notification>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.Holder, opt => opt.MapFrom(src => Mapper.Map<DTOHolder, Holder>(src.Holder)));
        }

        private static void AccountTypeConfigure(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<AccountType, DTOAccountType>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.TypeName))
                .ForMember(dest => dest.TypeValue, opt => opt.MapFrom(src => src.TypeValue))
                .ForMember(dest => dest.Accounts, opt => opt.Ignore());
            cfg.CreateMap<DTOAccountType, AccountType>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.TypeName))
                .ForMember(dest => dest.TypeValue, opt => opt.MapFrom(src => src.TypeValue))
                .ForMember(dest => dest.Accounts, opt => opt.Ignore());
        }

        private static void AccountConfigure(this IMapperConfigurationExpression cfg)
        {
            var notificationService = Resolver.Get<INotificationService>();
            cfg.CreateMap<Account, DTOAccount>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IsEnabled, opt => opt.MapFrom(src => src.IsEnabled))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance))
                .ForMember(dest => dest.AccountType, opt => opt.MapFrom(src => Mapper.Map<AccountType, DTOAccountType>(src.AccountType)))
                .ForMember(dest => dest.Holder, opt => opt.MapFrom(src => Mapper.Map<Holder, DTOHolder>(src.Holder)))
                .ForMember(dest => dest.Bonus, opt => opt.MapFrom(src => Mapper.Map<Bonus, DTOBonus>(src.Bonus)));
            cfg.CreateMap<DTOAccount, Account>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IsEnabled, opt => opt.MapFrom(src => src.IsEnabled))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance))
                .ForMember(dest => dest.AccountType, opt => opt.MapFrom(src => Mapper.Map<DTOAccountType, AccountType>(src.AccountType)))
                .ForMember(dest => dest.Holder, opt => opt.MapFrom(src => Mapper.Map<DTOHolder, Holder>(src.Holder)))
                .ForMember(dest => dest.Bonus, opt => opt.MapFrom(src => Mapper.Map<DTOBonus, Bonus>(src.Bonus)))
                .AfterMap((_, acc) => 
                {
                    acc.OnTransaction += 
                    (sender, e) => { sender.Bonus.Points += sender.AccountType.TypeValue * ((int)(e.NewBalance - e.Balance)); };
                    acc.OnTransaction += (sender, e) => 
                    {
                        notificationService.Add(new Notification()
                        {
                            Holder = sender.Holder,
                            Content = $"Balance have been changed to { e.NewBalance - e.Balance }$. " +
                            $"Old balance: { e.Balance }$, now: { e.NewBalance }$"
                        });
                        notificationService.UpdateAll();
                    };
                    if (!(acc.Bonus is null))
                    {
                        acc.Bonus.OnTransaction += (sender, e) =>
                        {
                            notificationService.Add(new Notification()
                            {
                                Holder = acc.Holder,
                                Content = $"Points have been changed to { e.NewBonusPoints - e.BonusPoints }. " +
                                $"Old points: { e.BonusPoints }, now: { e.NewBonusPoints }"
                            });
                            notificationService.UpdateAll();
                        };
                    }
                });
        }
    }
}
