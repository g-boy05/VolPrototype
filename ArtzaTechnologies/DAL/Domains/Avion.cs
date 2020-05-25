using ArtzaTechnologies.DAL.Domains.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArtzaTechnologies.DAL.Domains
{
    public class Avion : DomainObject
    {
        /// <summary>
        /// Libelle de l'avion (Nom)
        /// </summary>
        [Display(Name = "Libelle de l'avion")]
        [Required]
        public string Libelle { get; set; }
        /// <summary>
        /// Type de l'avion (Boeing 321 ...)
        /// </summary>
        [Display(Name = "Type de l'avion")]
        [Required]
        public string Type { get; set; }
        /// <summary>
        /// Consommation kerosene par km (100L/km)
        /// </summary>
        [Display(Name = "Consommation par km")]
        [Required]
        public int ConsommationParKm { get; set; }
        /// <summary>
        /// Vitesse de l'avion (Ex : 100Km/H)
        /// </summary>
        [Display(Name = "Vitesse Km/H")]
        [Required]
        public float Vitesse { get; set; }
        /// <summary>
        /// Consommation kerosene necessaire pour decolage(Ex : 10L)
        /// </summary>
        [Display(Name = "Kerosene necessaire pour decolage")]
        [Required]
        public int EffortDecollage { get; set; }
        /// <summary>
        ///List des vols
        /// </summary>
        public virtual ICollection<Vol> Vol { get; set; }

        public Avion()
        {
            Vol=new List<Vol>();
        }
    }
}
