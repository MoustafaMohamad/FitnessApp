using System.ComponentModel;

namespace ProgressTrackingService.Common.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            var attribute = field?
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .Cast<DescriptionAttribute>()
                .FirstOrDefault();

            return attribute?.Description ?? value.ToString();
        }
    }
}
