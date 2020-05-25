using System;
using ArtzaTechnologies.DAL.Domains.Base;
using GeoCoordinatePortable;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ArtzaTechnologies.DAL.Domains
{
    public class Aeroport:DomainObject
    {
        /// <summary>
        /// Nom de l'aeroport (Nom)
        /// </summary>
        [Display(Name = "Nom de l'aeroport")]
        [Required]
        public string Nom { get; set; }
        /// <summary>
        /// Localisation de l'aeroport
        /// </summary>
        [Display(Name = "Latitude de l'aeroport")]
        [Required]
        public Double Latitude { get; set; }

        [Display(Name = "Longtitude de l'aeroport")]
        [Required]
        public double Longtitude { get; set; }
        /// <summary>
        ///List des vols
        /// </summary>
        //public virtual ICollection<Vol> Vols { get; set; }

        //public Aeroport()
        //{
        //    Vols=new List<Vol>();
        //}

    }
}
