using PetClinicApp.Entities;
using System.Data.SqlClient;

namespace PetClinicApp.Repositories;

internal class AdoNetPetRepository : IPetRepository
{
    private readonly string connString;

    public AdoNetPetRepository(string connString) => this.connString = connString;


    public void Add(Pet pet)
    {
        string query = "INSERT INTO Pets (Id, Name, Type, Weight) VALUES (@Id, @Name, @Type, @Weight)";
        using var connection = new SqlConnection(connString);
        var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", pet.Id);
        command.Parameters.AddWithValue("@Name", pet.Name);
        command.Parameters.AddWithValue("@Type", pet.Type);
        command.Parameters.AddWithValue("@Weight", pet.Weight);

        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public Pet GetById(int id)
    {
        string query = "SELECT Id, Name, Type, Weight FROM Pets WHERE Id = @Id";
        using var connection = new SqlConnection(connString);
        var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);
        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            return new(
                 reader.GetInt32(0),
                 reader.GetString(1),
                 (AnimalType)reader.GetInt32(2),
                 reader.GetDouble(3));
        }

        throw new Exception("No elements or more than one element.");
    }
}
