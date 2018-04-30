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
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
        }
    }
}