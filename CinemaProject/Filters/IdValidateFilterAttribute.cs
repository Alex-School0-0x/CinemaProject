using CinemaProject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CinemaProject.Filters
{
    public class IdValidateFilterAttribute<T> : IAsyncActionFilter where T : class, IModel
    {
        private readonly IGetRepository<T> _repository;


        public IdValidateFilterAttribute(IGetRepository<T> repository) 
        {
            _repository = repository;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate @delegate) 
        {
            if (context.ActionArguments.TryGetValue("id", out var idObj) && idObj is int modelId)
            {
                var validationResult = await ValidationHelper.IdValidation(context, _repository, modelId);
                if (validationResult)
                {
                    await @delegate();
                }
                return;
            }

            context.ModelState.AddModelError("ModelId", "ModelId is required and must be an integer.");
            var problemDetail = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status400BadRequest
            };
            context.Result = new BadRequestObjectResult(problemDetail);

        }
    }
}
