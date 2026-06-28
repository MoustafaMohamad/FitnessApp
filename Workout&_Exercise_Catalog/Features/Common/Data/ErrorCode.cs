using System.ComponentModel;

namespace Workout_Exercise_Catalog.Features.Common.Data
{
    public enum ErrorCode
    {
        [Description("No error.")]
        None = 200,

        [Description("Invalid input data.")]
        InvalidInput = 400,

        [Description("Required field is missing or has an invalid value.")]
        VAL_REQUIRED_FIELD = 4001,

        [Description("Resource not found.")]
        RES_NOT_FOUND = 4040,

        [Description("Workout not found.")]
        RES_WORKOUT_NOT_FOUND = 4041,

        [Description("Workout plan not found.")]
        RES_PLAN_NOT_FOUND = 4042,

        [Description("Exercise not found.")]
        RES_EXERCISE_NOT_FOUND = 4043,

        //[Description("Product not found.")]
        //ProductNotFound = 1000,

        [Description("Category not found.")]
        CategoryNotFound = 2000,

        [Description("Client closed the request before the server could respond.")]
        ClientClosedRequest = 499,

        [Description("Unauthorized access.")]
        Unauthorized = 401,

        [Description("An unknown error occurred.")]
        UnKnown = 500
    }

}
