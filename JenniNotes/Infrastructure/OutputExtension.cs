using Microsoft.AspNetCore.Mvc;

namespace JenniNotes.Infrastructure
{
    public static class OutputExtension
    {
        public static IActionResult Response(this Output result)
        {
            switch(result.StatusCode)
            {
                case StatusCodes.Status200OK:
                    return new OkObjectResult(result);

                case StatusCodes.Status400BadRequest:
                    return new BadRequestObjectResult(result);

                case StatusCodes.Status404NotFound:
                    return new NotFoundObjectResult(result);

                case StatusCodes.Status401Unauthorized:
                    return new UnauthorizedObjectResult(result);

                case StatusCodes.Status500InternalServerError:
                    return new InternalServerObjectResult(result);

                default:
                    return new InternalServerObjectResult(result);


            }
        }

        public class InternalServerObjectResult : ObjectResult
        {
            public InternalServerObjectResult(object? value) : base(value)
            {
            }
        }
    }
}
