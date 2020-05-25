using ArtzaTechnologies.DAL.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtzaTechnologies.Services.Interfaces
{
    public interface IAeroportService
    {
        Task<ICollection<Aeroport>> GetAeroports();
    }
}
