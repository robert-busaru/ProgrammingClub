using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ProgrammingClub.CQRS.Queries;
using ProgrammingClub.DatabaseDataContext;
using ProgrammingClub.Models;

namespace ProgrammingClub.CQRS.Handlers
{
    public class GetAllCodeSnippetsHandler : IRequestHandler<GetAllCodeSnippetsQuery, IEnumerable<CodeSnippet>>
    {
        private readonly ProgrammingClubDataContext _context;
        private readonly IMemoryCache _cache;
        public GetAllCodeSnippetsHandler(ProgrammingClubDataContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<IEnumerable<CodeSnippet>> Handle(GetAllCodeSnippetsQuery request, CancellationToken cancellationToken)
        {
            const string cacheKey = "AllCodeSnippets";

            // 1. Verificăm dacă sunt date în cache
            if (_cache.TryGetValue(cacheKey, out IEnumerable<CodeSnippet> cachedCodeSnippets))
            {
                return cachedCodeSnippets; // Return cached data if available
            }

            // 2. Dacă nu sunt date în cache, le luăm din baza de date
            var codeSnippets = await _context.EventMembers.ToListAsync(cancellationToken);

            // 3. Configurăm opțiunile de cache
            var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(60));

            // 4. Salvăm datele în cache
            _cache.Set(cacheKey, codeSnippets, cacheOptions);

            return codeSnippets;
        }

    }
}
