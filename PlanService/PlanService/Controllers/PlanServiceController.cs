using Microsoft.AspNetCore.Mvc;
using PlanService.Models;
using PlanService.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlanService.Services;
using System.Net;
using AutoMapper;
using PlanService.DateManager;
using PlanService.DTOS;
using PlanService.Database;
using Swashbuckle.AspNetCore.Annotations;

namespace PlanService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanServiceController : Controller
    {
        private readonly IPlanService _planService;
        private readonly DateValidator _dateValidator;
        private readonly IMapper _mapper;


        public PlanServiceController(IPlanService planService, DateValidator dateValidator, IMapper mapper, PlanServiceDatabase planServiceDataBase)
        {
            _planService = planService;
            _dateValidator = dateValidator;
            _mapper = mapper;
        }

        [SwaggerOperation("GetPlanAsync")]
        [HttpGet("{planId:length(24)}", Name = "GetPlanAsync")]
        public async Task<ActionResult<PlanReadDto>> GetPlanAsync(string planId)
        {
            var plan = await _planService.GetPlanByIdAsync(planId);
            if (plan != null)
            {
                return Ok(_mapper.Map<PlanReadDto>(plan));
            }
            else
            {
                return NotFound();
            }


        }

        [SwaggerOperation("GetAllPlansByUserIdAsync")]
        [HttpGet("getAllPlans/{userId}", Name = ("GetAllPlansByUserIdAsync"))]
        public async Task<ActionResult<List<PlanReadDto>>> GetAllPlansByUserIdAsync(string userId)
        {
            var plans = await _planService.GetAllPlansByUserIdAsync(userId);
            if (plans.Count != 0)
            {
                return Ok(_mapper.Map<List<Plan>, List<PlanReadDto>>(plans));
            }
            else
            {
                return NotFound();
            }

        }

        [SwaggerOperation("GetPlansWhereUserHasMemberShipAsync")]
        [HttpGet("membership/{userId}")]
        public async Task<ActionResult<List<PlanReadDto>>> GetPlansWhereUserHasMemberShipAsync(string userId)
        {
            var plans = await _planService.GetPlansWhereUserHasMemberShipAsync(userId);
            if (plans.Count != 0)
            {
               
                return Ok(_mapper.Map<List<Plan>, List<PlanReadDto>>(plans));
            }
            else
            {
                return NotFound();
            }
        }

        [SwaggerOperation("CreatePlan")]
        [HttpPost(Name = "CreatePlan")]
        public async Task<ActionResult<PlanReadDto>> CreatePlan(PlanCreateDto plan)
        {
            var newPlan = _mapper.Map<Plan>(plan);
            if (newPlan != null && _dateValidator.ValidateDates(newPlan.ToDate, newPlan.FromDate))
            {
                await _planService.CreatePlanAsync(newPlan);
                return Ok(_mapper.Map<PlanReadDto>(newPlan));
            }
            else
            {
                return BadRequest();
            }

        }

        [SwaggerOperation("UpdatePlan")]
        [HttpPut(Name = "UpdatePlan")]
        public async Task<ActionResult<PlanReadDto>> UpdatePlan(Plan plan)
        {
            
            if (plan != null && _dateValidator.ValidateDates(plan.ToDate, plan.FromDate))
            {

                await _planService.UpdatePlanAsync(plan);
                return Ok(_mapper.Map<PlanReadDto>(plan));
            }
            else
            {
                return NotFound();
            }
        }


        [HttpDelete("{planId}", Name = "DeletePlan")]
        public async Task<ActionResult<PlanReadDto>> DeletePlan(string planId)
        {

            var deletedPlan = await _planService.DeletePlanAsync(planId);
            if (deletedPlan != null)
            {
                return Ok(_mapper.Map<PlanReadDto>(deletedPlan));
            }
            else
            {
                return NotFound();
            }
        }

    }
}
