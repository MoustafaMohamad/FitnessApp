using ProgressTrackingService.Common.Enums;

namespace ProgressTrackingService.Common.Services
{
    public class EnumLookupCache
    {
        // Since Lookup.Id IS now LookupEnum, no DB lookup is needed.
        // This method is kept for backward compatibility but simply casts the enum.
        public Task<LookupEnum> GetLookupId(LookupEnum enumId)
        {
            return Task.FromResult(enumId);
        }
    }
}
