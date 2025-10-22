using System.Collections.ObjectModel;

namespace OopAnimalsApp.Models
{
    public class Monkey : Animal, ICrazyAction
    {
        public Monkey(string name, int age) : base(name, age)
        {
        }

        public override string MakeSound()
        {
            return "Ooh ooh! Aah aah!";
        }

        public void ActCrazy(ObservableCollection<string> log, IList<Animal> allAnimals)
        {
            if (allAnimals.Count < 2)
            {
                log.Add($"{Name} tried to swap names but needs at least 2 animals!");
                return;
            }

            int index1 = Random.Shared.Next(allAnimals.Count);
            int index2 = Random.Shared.Next(allAnimals.Count);

            // Ensure we pick different animals
            while (index2 == index1)
            {
                index2 = Random.Shared.Next(allAnimals.Count);
            }

            Animal animal1 = allAnimals[index1];
            Animal animal2 = allAnimals[index2];

            string oldName1 = animal1.Name;
            string oldName2 = animal2.Name;

            animal1.Name = oldName2;
            animal2.Name = oldName1;

            log.Add($"{Name} swapped names: {oldName1} <-> {oldName2}");
        }
    }
}
