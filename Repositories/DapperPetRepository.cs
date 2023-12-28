using Dapper;
using PetClinicApp.Entities;
using System.Data.SqlClient;

namespace PetClinicApp.Repositories;

internal class DapperPetRepository : IPetRepository
{
    private readonly string connString;

    public DapperPetRepository(string connString) => this.connString = connString;

    public void Add(Pet pet)
    {
        using var connection = new SqlConnection(connString);
        var sql = "INSERT INTO Pets (Id, Name, Type, Weight) VALUES (@Id, @Name, @Type, @Weight)";
        connection.Execute(sql, pet);
    }

    public Pet GetById(int id)
    {
        using var connection = new SqlConnection(connString);
        var sql = "SELECT Id, Name, Type, Weight FROM Pets WHERE Id = @Id";
        return connection.QuerySingle<Pet>(sql, new { Id = id });
    }
}