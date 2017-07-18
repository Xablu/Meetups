using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xablu.Petstore.Models;

namespace Xablu.Petstore.Services
{
    public interface IPetService
    {
        Pet AddPet(Pet pet);
        bool DeletePet(long? petId);
        IEnumerable<Pet> FindPetsByStatus(List<Pet.StatusEnum?> searchStatus);
        IEnumerable<Pet> FindPetsByTags(List<string> tags);
        Pet FindPetById(long petId);
        Pet UpdatePet(long petId, Pet source);
    }
}
