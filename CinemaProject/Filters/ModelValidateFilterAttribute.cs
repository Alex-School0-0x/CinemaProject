using CinemaProject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CinemaProject.Filters
{
    public class ModelValidateFilterAttribute<T> : IAsyncActionFilter where T : class, IModel
    {
        private readonly IFullRepository<T> _repository;

        public ModelValidateFilterAttribute(IFullRepository<T> repository) { _repository = repository; }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate @delegate) 
        {            

            var model = context.ActionArguments["model"] as T;
            var modelId = context.ActionArguments["id"] as int?;
            if (modelId.HasValue)
            {
                await IdValidation(context, (int)modelId);
            }
            if (model != null)
            {
                await IdValidation(context, model.Id);
            }
        }

        private async Task IdValidation(ActionExecutingContext context, int modelId)
        {
            if (modelId <= 0)
            {
                context.ModelState.AddModelError("ModelId", "ModelId is invalid");
                var problemDetail = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetail);
            }
            else if (!await _repository.EntityExistsAsync(modelId))
            {
                context.ModelState.AddModelError("ModelId", "ModelId not found");
                var problemDetail = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status404NotFound
                };
                context.Result = new NotFoundObjectResult(problemDetail);
            }
        }
    }
}
