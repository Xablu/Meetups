using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xablu.Petstore.Models;
using Xablu.Petstore.Persistence;

namespace Xablu.Petstore.Services
{
    public class PetService : IPetService
    {
        private readonly PetstoreDbContext _dbContext;

        public PetService(PetstoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Pet AddPet(Pet pet)
        {
            var dbPet = new PetDbContext();
            _dbContext.Pets.Add(dbPet);
            _dbContext.SaveChanges();
            pet.Id = dbPet.PetDbContextId;
            dbPet.Pet = pet;
            _dbContext.SaveChanges();
            return pet;
        }

        public bool DeletePet(long? petId)
        {
            if (petId == null) return false;
            var dbPet = _dbContext.Pets.FirstOrDefault(dbp => dbp.PetDbContextId == petId);
            if (dbPet == null) return false;
            _dbContext.Pets.Remove(dbPet);
            _dbContext.SaveChanges();
            return true;
        }

        public Pet FindPetById(long petId)
        {
            return _dbContext.Pets.FirstOrDefault(dbp => dbp.PetDbContextId == petId)?.Pet;
        }

        public IEnumerable<Pet> FindPetsByStatus(List<Pet.StatusEnum?> searchStatus)
        {
            var pets = _dbContext.Pets.Where(dbp => searchStatus.Contains(dbp.Pet.Status)).Select(dbp => dbp.Pet);
            return pets.ToList();
        }

        public IEnumerable<Pet> FindPetsByTags(List<string> tags)
        {
            var pets = _dbContext.Pets.Where(dbp => dbp.Pet.Tags.Any(t => tags.Contains(t.Name))).Select(dbp => dbp.Pet);
            return pets.ToList();
        }

        public Pet UpdatePet(long petId, Pet source)
        {
            var dbPet = _dbContext.Pets.FirstOrDefault(dbp => dbp.PetDbContextId == petId);
            var pet = dbPet?.Pet;
            if (pet == null) return null;

            if (source.Name != default(string)) pet.Name = source.Name;
            if (source.PhotoUrls != null) pet.PhotoUrls = source.PhotoUrls;
            if (source.Status != null) pet.Status = source.Status;
            if (source.Tags != null) pet.Tags = source.Tags;
            dbPet.Pet = pet;
            _dbContext.SaveChanges();

            return pet;
        }
    }
}
