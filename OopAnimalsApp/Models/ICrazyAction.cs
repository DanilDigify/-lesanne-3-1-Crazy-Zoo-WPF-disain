using System.Collections.ObjectModel;

namespace OopAnimalsApp.Models
{
    public interface ICrazyAction
    {
        void ActCrazy(ObservableCollection<string> log, IList<Animal> allAnimals);
    }
}
