using ArtzaTechnologies.DAL.Contexts;
using ArtzaTechnologies.DAL.Domains;
using ArtzaTechnologies.Dto;
using ArtzaTechnologies.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtzaTechnologies.Services
{
    public class VolService : IVolService
    {
        private readonly AppDomainContext _context;
        private readonly IMapper _mapper;

        public VolService(AppDomainContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddVol(Vol vol)
        {
            var aeroportDepart = _context.Aeroports.FirstOrDefault(x => x.Id == vol.AeroportDepart.Id);
            var aeroportArrive = _context.Aeroports.FirstOrDefault(x => x.Id == vol.AeroportArrivee.Id);
            var avion = _context.Avions.FirstOrDefault(x => x.Id == vol.Avion.Id);
            vol.AeroportDepart = aeroportDepart;
            vol.AeroportArrivee = aeroportArrive;
            vol.Avion = avion;

            _context.Add(vol);
            int id=await _context.SaveChangesAsync();
            return id != 0;
        }

        public async Task<bool> DeleteVol(int id)
        {
            var vol =await _context.Vols.FindAsync(id);
            _context.Vols.Remove(vol);
            int idDeleted=await _context.SaveChangesAsync();
            return idDeleted != 0;
        }

        public async Task<bool> EditVol(Vol vol)
        {
            bool isUpdateSuccess = false;
            try
            {
                var aeroportDepart = _context.Aeroports.FirstOrDefault(x => x.Id == vol.AeroportDepart.Id);
                var aeroportArrive = _context.Aeroports.FirstOrDefault(x => x.Id == vol.AeroportArrivee.Id);
                var avion = _context.Avions.FirstOrDefault(x => x.Id == vol.Avion.Id);
                vol.AeroportDepart = aeroportDepart;
                vol.AeroportArrivee = aeroportArrive;
                vol.Avion = avion;
                _context.Update(vol);
                await _context.SaveChangesAsync();
                isUpdateSuccess = true;
            }

            catch(DbUpdateConcurrencyException)
            {
                //Add serilog for best Log exception
                if (!VolExists(vol.Id))
                    isUpdateSuccess = false;
            }

            return isUpdateSuccess;
        }
        public async Task<Vol> GetVolById(int? id)
        {
            var vol = await _context.Vols.Include("Avion").Include("AeroportDepart").Include("AeroportArrivee").FirstOrDefaultAsync(x => x.Id == id);
            return vol;
        }

        public async Task<VolDto> GetVolDtoById(int? id)
        {
            var vol = await _context.Vols.Include("Avion").Include("AeroportDepart").Include("AeroportArrivee").FirstOrDefaultAsync(x=>x.Id==id);
            var volDto = _mapper.Map<Vol, VolDto>(vol);
            return volDto;
        }

        public async Task<ICollection<VolDto>> GetVolsDtos()
        {
            
            var vols = await _context.Vols.Include("Avion").Include("AeroportDepart").Include("AeroportArrivee").ToListAsync();
            ICollection<VolDto> volDtos = _mapper.Map<List<Vol>, List<VolDto>>(vols);
            return volDtos;
        }

        #region PrivateMethods

        private bool VolExists(int id)
        {
            return _context.Vols.Any(x => x.Id == id);
        }
        #endregion
    }
}
