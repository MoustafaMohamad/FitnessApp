using Workout_Exercise_Catalog.Common.Helpers;
using Workout_Exercise_Catalog.Features.Common.Data;

namespace Workout_Exercise_Catalog.Features.Common.Views
{
    public record RequestResult<T>(T Data, bool IsSuccess, string Message, ErrorCode ErrorCode)
    {
        public static RequestResult<T> Success(T data, string message = "")
        {
            return new RequestResult<T>(data, true, message, ErrorCode.None);
        }
        public static RequestResult<T> Failure(ErrorCode errorCode, string message = null)
        {
            if (message is null)
            {
                message = errorCode.GetDescription();
            }
            return new RequestResult<T>(default, false, message, errorCode);
        }
    }
}
