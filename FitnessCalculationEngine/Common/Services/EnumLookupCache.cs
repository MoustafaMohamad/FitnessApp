using FitnessCalculationEngine.Common.Enums;
using FitnessCalculationEngine.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace FitnessCalculationEngine.Common.Services
{
    public class EnumLookupCache
    {
        private readonly IMemoryCache _memoryCache;
        private readonly Context _context;

        public EnumLookupCache(Context context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public async Task<long> GetLookupId(LookupEnum enumId)
        {
            return await _memoryCache.GetOrCreateAsync(enumId, async entry =>
            {
                entry.Priority = CacheItemPriority.NeverRemove;

                var lookup = await _context.Lookups
                    .Where(x => x.EnumId == enumId)
                    .Select(x => x.Id)
                    .FirstOrDefaultAsync();

                return lookup;
            });
        }
    }
}
