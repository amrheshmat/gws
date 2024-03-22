using MWS.Data.Entities;
using MWS.Infrustructure.Context;
using TripBusiness.Ibusiness;

namespace TripBusiness.business
{
    public class LanguageService : ILanguageService
    {

        private readonly AGGRDbContext _context;

        public LanguageService(AGGRDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Language> GetLanguages()
        {
            return _context.languages.ToList();
        }

        public Language GetLanguageByCulture(string culture)
        {
            return _context.languages.FirstOrDefault(x =>
                x.code.Trim().ToLower() == culture.Trim().ToLower());
        }
    }
}
