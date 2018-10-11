﻿namespace AnimalMatcher.Services.Location
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AnimalMatcher.Data.Models;
    using AnimalMatcher.Data.Repository.Interfaces;
    using AnimalMatcher.Services.Location.Interfaces;
    using AnimalMatcher.Services.Models.Pet;
    using AnimalMatcher.Specifications;

    public class LocationService : ILocationService
    {
        private const int EarthRadiusInKm = 6371;
        private const double RadiansPerDegree = 0.0174532925;

        private readonly IGenericRepository<Pet> petRepository;

        public LocationService(IGenericRepository<Pet> petRepository)
        {
            this.petRepository = petRepository;
        }

        public IEnumerable<PetServiceModel> GetPetsInRadius(double latitude, double longitude, double radius)
        {
            double latitudeInRadians = latitude * RadiansPerDegree;
            double longitudeInRadians = longitude * RadiansPerDegree;

            var petsInRadiusSpecification = new Specification<Pet>(pet => Math.Acos(Math.Sin(latitudeInRadians) * Math.Sin(pet.Latitude * RadiansPerDegree)
            + Math.Cos(latitudeInRadians) * Math.Cos(pet.Latitude * RadiansPerDegree) * Math.Cos(pet.Longitude * RadiansPerDegree - longitudeInRadians))
            * EarthRadiusInKm <= radius);

            var petsInRadius = this.petRepository.List(petsInRadiusSpecification).ToList();

            return null;
        }
    }
}
