using System.Collections.Generic;
using System.Threading.Tasks;
using ArtzaTechnologies.DAL.Contexts;
using ArtzaTechnologies.DAL.Domains;
using ArtzaTechnologies.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtzaTechnologies.Services
{
    public class AeroportService : IAeroportService
    {
        private readonly AppDomainContext _context;

        public AeroportService(AppDomainContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Aeroport>> GetAeroports()
        {
            var aeroports = await _context.Aeroports.ToListAsync();
            return aeroports;
        }
    }
}
