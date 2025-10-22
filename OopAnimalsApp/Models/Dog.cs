using System.Collections.ObjectModel;

namespace OopAnimalsApp.Models
{
    public class Dog : Animal, ICrazyAction
    {
        public Dog(string name, int age) : base(name, age)
        {
        }

        public override string MakeSound()
        {
            return "Woof!";
        }

        public void ActCrazy(ObservableCollection<string> log, IList<Animal> allAnimals)
        {
            for (int i = 0; i < 5; i++)
            {
                log.Add("Woof!");
            }
        }
    }
}
