using CinemaProject.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CinemaProject.Filters
{
    public class ModelIdValidationFilterAttribute<T> : IAsyncActionFilter where T : class, IModel
    {
        private readonly IGetRepository<T> _repository;

        public ModelIdValidationFilterAttribute(IGetRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate @delegate)
        {
            if (context.ActionArguments.ContainsKey("model") && context.ActionArguments["model"] is T model)
            {
                var modelId = model.Id;
                await ValidationHelper.IdValidation(context, _repository, modelId);
            }
            if (context.Result != null)
            {
                return;
            }

            await @delegate();
        }
    }
}
