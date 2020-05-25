using System;
using System.ComponentModel.DataAnnotations;

namespace ArtzaTechnologies.Dto
{
    public class VolDto
    {
        public int Id { get; set; }
        [Display(Name = "Libelle de l'avion")]
        public string Avion { get; set; }
        [Display(Name = "Duree de vol")]
        public TimeSpan DureeVol { get; set; }
        [Display(Name = "Aeroport de depart")]
        public string Depart { get; set; }
        [Display(Name = "Aeroport d'arrivee")]
        public string Arrivee { get; set; }
        [Display(Name = "Distance de vol en KM")]
        public double Distance { get; set; }
        [Display(Name = "Kerosene necessaire pour le vol")]
        public float KeroseneNecessaire { get; set; }
    }
}
