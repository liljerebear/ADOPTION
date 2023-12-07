// Ollie Pearson
// CIS317 Course Project

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

public class DatabaseHelper
{
    private string connectionString;

    public DatabaseHelper(string dbPath)
    {
        connectionString = $"Data Source={dbPath};Version=3;";
    }

    public void CreatePetsTable()
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            using (SQLiteCommand command = new SQLiteCommand(
                "CREATE TABLE IF NOT EXISTS Pets (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Age INTEGER, Species TEXT);",
                connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    public void InsertPet(Pet pet)
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            using (SQLiteCommand command = new SQLiteCommand(
                "INSERT INTO Pets (Name, Age, Species) VALUES (@Name, @Age, @Species);",
                connection))
            {
                command.Parameters.AddWithValue("@Name", pet.Name);
                command.Parameters.AddWithValue("@Age", pet.Age);
                command.Parameters.AddWithValue("@Species", pet.Species);

                command.ExecuteNonQuery();
            }
        }
    }

    public List<Pet> GetAllPets()
    {
        List<Pet> pets = new List<Pet>();

        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Pets;", connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pets.Add(new Pet
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = Convert.ToString(reader["Name"]),
                            Age = Convert.ToInt32(reader["Age"]),
                            Species = Convert.ToString(reader["Species"])
                        });
                    }
                }
            }
        }

        return pets;
    }
}
