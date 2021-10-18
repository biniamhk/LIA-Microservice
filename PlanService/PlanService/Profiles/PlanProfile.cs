using AutoMapper;
using PlanService.DTOS;
using PlanService.Models;

namespace PlanService.Profiles
{
    public class PlanProfile : Profile
    {
        public PlanProfile()
        {
            //source to target

            CreateMap<Plan, PlanReadDto>();
            CreateMap<PlanCreateDto,Plan>();
            CreateMap<PublishPlanReadDto, PublishPlanReadDto>();
        }
    }
}