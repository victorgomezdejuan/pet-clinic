using PetClinicApp.EF;
using PetClinicApp.Entities;

namespace PetClinicApp.Repositories;

internal class EFPetRepository : IPetRepository
{
    private readonly PetClinicAppContext context;

    public EFPetRepository(PetClinicAppContext context) => this.context = context;

    public void Add(Pet pet)
    {
        context.Pets.Add(pet);
        context.SaveChanges();
    }

    public Pet GetById(int id) => context.Pets.Single(p => p.Id == id);
}
