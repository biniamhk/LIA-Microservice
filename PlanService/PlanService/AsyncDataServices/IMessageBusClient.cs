using PlanService.DTOS;

namespace PlanService.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublishNewPlan(PublishPlanReadDto publishedPlanDto);
    }
}
