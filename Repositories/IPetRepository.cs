using PetClinicApp.Entities;

namespace PetClinicApp.Repositories;

internal interface IPetRepository
{
    void Add(Pet pet);
    Pet GetById(int id);
}
