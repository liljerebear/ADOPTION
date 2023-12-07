// Ollie Pearson
// CIS317 Course Project

using System;
using System.Collections.Generic;

public class PetAdoptionSystem : IPetAdoption
{
    private List<Pet> availablePets;
    private List<string> adoptionRecords;
    private DatabaseHelper databaseHelper;

    public PetAdoptionSystem()
    {
        availablePets = new List<Pet>();
        adoptionRecords = new List<string>();
        databaseHelper = new DatabaseHelper("PetAdoptionDatabase.db");
        databaseHelper.CreatePetsTable(); // Create the Pets table if it doesn't exist
    }

    public void AddAvailablePet(Pet newPet)
    {
        availablePets.Add(newPet);
        databaseHelper.InsertPet(newPet);
    }

    public void DisplayAvailablePets()
    {
        Console.WriteLine("Available Pets:");
        foreach (var pet in availablePets)
        {
            Console.WriteLine($"Id: {pet.Id}, Name: {pet.Name}, Age: {pet.Age}, Species: {pet.Species}");
        }
    }

    public void AdoptPet(string petName, string adopterName)
    {
        Pet adoptedPet = availablePets.Find(pet => pet.Name == petName);

        if (adoptedPet != null)
        {
            availablePets.Remove(adoptedPet);
            adoptionRecords.Add($"{petName} adopted by {adopterName}");
            Console.WriteLine($"Adoption successful: {petName} adopted by {adopterName}");
        }
        else
        {
            Console.WriteLine($"Pet with name {petName} not found.");
        }
    }
}
