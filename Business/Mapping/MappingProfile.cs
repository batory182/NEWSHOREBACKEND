using AutoMapper;
using Business.Entitites;
using BusinessEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<ResponseFlight, Flight>()
                .ForPath(d => d.Transport.FlightCarrier, s => s.MapFrom(x => x.FlightCarrier))
                .ForPath(d => d.Transport.FlightNumber, s => s.MapFrom(x => x.FlightNumber))
                .ForMember(d => d.Origin , s => s.MapFrom(x => x.DepartureStation))
                .ForMember(d => d.Destination , s => s.MapFrom(x => x.ArrivalStation))
                .ForMember(d => d.Price , s => s.MapFrom(x => x.Price));
        }
    }
}
