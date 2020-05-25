using ArtzaTechnologies.DAL.Domains.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArtzaTechnologies.DAL.Domains
{
    public class Vol : DomainObject
    {
        /// <summary>
        /// Date de depart de vol
        /// </summary>
        [Display(Name = "Date de depart")]
        [Required]
        public DateTime DateDepart { get; set; }
        /// <summary>
        /// Date arrivee de vol
        /// </summary>
        [Display(Name = "Date d'arrivee")]
        [Required]
        public DateTime DateArrivee { get; set; }

        /// <summary>
        /// Avion pour le vol
        /// </summary>
        [Display(Name = "Avion")]
        [Required]
        public virtual Avion Avion { get; set; }
        /// <summary>
        /// Aeroport de depart pour le vol
        /// </summary>
        [Display(Name = "Aeroport de depart")]
        [Required]
        public virtual Aeroport AeroportDepart { get; set; }
        /// <summary>
        /// Aeroport d'arrivee pour le vol
        /// </summary>
        [Display(Name = "Aeroport d'arrivee")]
        [Required]
        public virtual Aeroport AeroportArrivee { get; set; }

        public Vol()
        {
            Avion=new Avion();
            AeroportDepart=new Aeroport();
            AeroportArrivee=new Aeroport();
        }
        //TODO la methode a implementer dans un ViewModel
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (DateDepart > DateArrivee)
        //    {
        //        yield return new ValidationResult(
        //            "La date de depart doit etre superieur a la date d'arrivee.");
        //    }
        //}
    }
}
