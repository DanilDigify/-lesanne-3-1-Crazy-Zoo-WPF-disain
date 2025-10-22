using System.Collections.ObjectModel;

namespace OopAnimalsApp.Models
{
    public class Cat : Animal, ICrazyAction
    {
        public Cat(string name, int age) : base(name, age)
        {
        }

        public override string MakeSound()
        {
            return "Meow!";
        }

        public void ActCrazy(ObservableCollection<string> log, IList<Animal> allAnimals)
        {
            log.Add($"{Name} stole cheese from the kitchen.");
        }
    }
}
