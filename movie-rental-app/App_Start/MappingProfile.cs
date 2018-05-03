using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using movie_rental_app.DataTransfer;
using movie_rental_app.Models;

namespace movie_rental_app.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ForMember function to exclude ID in mapping with Automapper
            CreateMap<Customer, CustomerDto>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<CustomerDto, Customer>();

            CreateMap<Movie, MovieDto>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            CreateMap<MovieDto, Movie>();
        }
    }
}