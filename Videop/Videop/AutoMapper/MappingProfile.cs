using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videop.DTO;
using Videop.Models;

namespace Videop.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Will find it's props and mapps them based on name so automapper is convention based mapping tool
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MovieDTO, Movie>();            
        }
    }
}