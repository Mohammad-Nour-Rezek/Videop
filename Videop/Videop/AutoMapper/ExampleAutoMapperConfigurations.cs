//using AutoMapper;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Web;
//using Videop.DTO;
//using Videop.Models;

//namespace Videop.AutoMapper
//{
//    public class AutoMapperConfigurations
//    {
//        public static IMapper Mapper { get; set; }

//        public static void RegisterProfile()
//        {
//            MapperConfiguration config = new MapperConfiguration(cfg =>
//            {
//                cfg.CreateMap<Customer, CustomerDTO>();
//                cfg.CreateMap<CustomerDTO, Customer>();
//            });

//            Mapper = config.CreateMapper();
//        }

//        //// Need  : NinjectModule
//        //public override void Load()
//        //{
//        //    Bind<IMapper>().ToMethod(AutoMapper).InSingletonScope();
//        //}

//        //private IMapper AutoMapper(Ninject.Activation.IContext context)
//        //{
//        //    Mapper.Initialize(config =>
//        //    {
//        //        config.ConstructServicesUsing(type => context.Kernel.Get(type));

//        //        config.CreateMap<MySource, MyDest>();
//        //        // .... other mappings, Profiles, etc.              

//        //    });

//        //    Mapper.AssertConfigurationIsValid(); // optional
//        //    return Mapper.Instance;
//        //}
//    }
//}