using System;
using ArtzaTechnologies.DAL.Domains;
using ArtzaTechnologies.Dto;
using AutoMapper;
using GeoCoordinatePortable;

namespace ArtzaTechnologies.AutoMapperProfiles.Resolver
{
    public class DistanceResolver : IValueResolver<Vol, VolDto, double>
    {
        public double Resolve(Vol source, VolDto destination, double destMember, ResolutionContext context)
        {
            GeoCoordinate arriveCoordinate = new GeoCoordinate(source.AeroportArrivee.Latitude, source.AeroportArrivee.Longtitude);
            GeoCoordinate departCoordinate=new GeoCoordinate(source.AeroportDepart.Latitude,source.AeroportDepart.Longtitude);
            return departCoordinate.GetDistanceTo(arriveCoordinate);
        }
    }
    public class ConsommationResolver : IValueResolver<Vol, VolDto, float>
    {
        public float Resolve(Vol source, VolDto destination, float destMember, ResolutionContext context)
        {
            var result = source.Avion.EffortDecollage + (source.Avion.ConsommationParKm * destination.Distance);
            return (float)result;
        }
    }
    public class DureeVolResolver : IValueResolver<Vol, VolDto, TimeSpan>
    {
        public TimeSpan Resolve(Vol source, VolDto destination, TimeSpan destMember, ResolutionContext context)
        {
            //TODO gerer les fuseaux horaires juste pour la simplification on peut implementer un resolver avec ce calcul
            //var autreCalcul = TimeSpan.FromHours(destination.Distance / source.Avion.Vitesse);
            var result = source.DateArrivee - source.DateDepart;
            return result;
        }
    }
}
