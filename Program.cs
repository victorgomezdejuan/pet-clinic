using PetClinicApp.EF;
using PetClinicApp.Entities;
using PetClinicApp.Repositories;
using System.Data.SqlClient;

Console.WriteLine("Welcome to my Pet Clinic!");

string connString = "Server=localhost;Database=PetClinicApp;User Id=sa;Password=;TrustServerCertificate=true;";

InitDatabase(connString);

//IPetRepository repository = new AdoNetPetRepository(connString);
//IPetRepository repository = new DapperPetRepository(connString);
IPetRepository repository = new EFPetRepository(new PetClinicAppContext(connString));

Console.WriteLine("Let's add my pet Tao to the app database");

var tao = new Pet(1, "Tao", AnimalType.Dog, 8.33);
repository.Add(tao);

Console.WriteLine("Now let's print the data from the database");

var taoData = repository.GetById(1);

Console.WriteLine($"This the data relative to Tao: {{ {taoData} }}");

static void InitDatabase(string connString)
{
    string query = "TRUNCATE TABLE Pets";
    using var connection = new SqlConnection(connString);
    var command = new SqlCommand(query, connection);
    connection.Open();
    command.ExecuteNonQuery();
    connection.Close();
}