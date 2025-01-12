using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using CinemaProject.Interfaces;

namespace CinemaProject.Filters
{
    public static class ValidationHelper
    {
        public static async Task<bool> IdValidation<T>(ActionExecutingContext context, IGetRepository<T> repository, int modelId) where T : class, IModel
        {
            if (modelId <= 0)
            {
                context.ModelState.AddModelError("ModelId", "ModelId is invalid");
                var problemDetail = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetail);
                return false;
            }
            else if (!await repository.EntityExistsAsync(modelId))
            {
                context.ModelState.AddModelError("ModelId", "ModelId not found");
                var problemDetail = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status404NotFound
                };
                context.Result = new NotFoundObjectResult(problemDetail);
                return false;
            }
            return true;
        }
    }
}
