using AutoMapper;
using MementoService.DTOs;
using MementoService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MementoService.Profiles
{
    public class MementoProfile : Profile
    {
        public MementoProfile()
        {
            CreateMap<MementoCreateDTO, MementoModel>();
            CreateMap<MementoModel, MementoReadDTO>();
        }
    }
}
