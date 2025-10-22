using System.Collections.ObjectModel;

namespace OopAnimalsApp.Models
{
    public class Raccoon : Animal, ICrazyAction
    {
        private static readonly string[] TrinketList = { "bolt", "coin", "glass bead" };

        public Raccoon(string name, int age) : base(name, age)
        {
        }

        public override string MakeSound()
        {
            return "Chitter-chatter!";
        }

        public void ActCrazy(ObservableCollection<string> log, IList<Animal> allAnimals)
        {
            int randomIndex = Random.Shared.Next(TrinketList.Length);
            string trinket = TrinketList[randomIndex];
            log.Add($"{Name} found a shiny trinket: {trinket}");
        }
    }
}
