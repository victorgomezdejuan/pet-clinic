# Pet Clinic Console App
This is a very simple console app to show some of the basic differences in terms of code boilerplate regarding EF Core, Dapper and ADO.NET.

## Running the application
The most interesting part of the application lies in the Repository classes but, in case you want to run the app, you can do it following these steps:
- Restore the backup file PetClinic.bak in your SQL Server instance.
- Update the connection string included in Program.cs accordingly.
- In Program.cs, uncomment the line to make use of any of the data access posibilities and comment the others.
- Go to the terminal and run `dotnet run`
