class Program
{
    static void Main()
    {
        PetAdoptionSystem adoptionSystem = new PetAdoptionSystem();

        Dog newDog = new Dog
        {
            Name = "Buddy",
            Age = 3,
            Species = "Dog",
            Breed = "Golden Retriever"
        };

        adoptionSystem.AddAvailablePet(newDog);

        adoptionSystem.DisplayAvailablePets();

        adoptionSystem.AdoptPet("Buddy", "John Doe");

        adoptionSystem.DisplayAvailablePets();
    }
}
