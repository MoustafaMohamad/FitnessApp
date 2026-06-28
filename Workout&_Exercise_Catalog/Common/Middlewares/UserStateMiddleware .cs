using System.Security.Claims;
using Workout_Exercise_Catalog.Entities;

namespace Workout_Exercise_Catalog.Common.Middlewares
{
    public class UserStateMiddleware : IMiddleware
    {
        private UserState _userState;

        public UserStateMiddleware(UserState userState)
        {
            _userState = userState;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var loggedUser = context.User;

            if (loggedUser.Identity?.IsAuthenticated == true)
            {
                var idClaimValue = loggedUser.FindFirst("ID")?.Value;
                if (Guid.TryParse(idClaimValue, out var parsedId))
                {
                    _userState.ID = parsedId;
                }
                else
                {
                    _userState.ID = Guid.Empty;
                }
                _userState.Name = loggedUser.FindFirst(ClaimTypes.Name)?.Value ?? "";

                var roleValue = loggedUser.FindFirstValue(ClaimTypes.Role);
                if (Enum.TryParse<Role>(roleValue, out var parsedRole))
                {
                    _userState.Role = parsedRole;
                }
                else
                {
                    _userState.Role = default;
                }
            }



            await next(context);
        }
    }
}
