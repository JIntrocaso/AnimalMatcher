﻿namespace AnimalMatcher.Services.Pet.Interfaces
{
    using System.Collections.Generic;
    using AnimalMatcher.Services.Models.Pet;

    public interface IPetService
    {
        void Register(PetRegisterServiceModel pet);

        PetWithOwnerServiceModel GetById(int petId);

        IEnumerable<PetWithOwnerServiceModel> GetOwnersPets(string ownerId);
    }
}
