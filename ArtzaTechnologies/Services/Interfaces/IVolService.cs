using ArtzaTechnologies.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArtzaTechnologies.DAL.Domains;

namespace ArtzaTechnologies.Services.Interfaces
{
    public interface IVolService
    {
        Task<ICollection<VolDto>> GetVolsDtos();
        Task<VolDto> GetVolDtoById(int? id);
        Task<bool> AddVol(Vol vol);
        Task<bool> EditVol(Vol vol);
        Task<bool> DeleteVol(int id);
        Task<Vol> GetVolById(int? id);
    }
}
