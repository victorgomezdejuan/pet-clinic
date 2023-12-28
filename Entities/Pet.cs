namespace PetClinicApp.Entities;

public record Pet(int Id, string Name, AnimalType Type, double Weight)
{
    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Type: {Type}, Weight: {Weight}";
    }
}

public enum AnimalType
{
    Dog = 0,
    Cat = 1
}
