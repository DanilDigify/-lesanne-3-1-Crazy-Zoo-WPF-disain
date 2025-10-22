using System.Collections.ObjectModel;

namespace OopAnimalsApp.Models
{
    public class Bird : Animal, IFlyable, ICrazyAction
    {
        private bool _isFlying;

        public bool IsFlying
        {
            get => _isFlying;
            set
            {
                if (_isFlying != value)
                {
                    _isFlying = value;
                    OnPropertyChanged();
                }
            }
        }

        public Bird(string name, int age) : base(name, age)
        {
            _isFlying = false;
        }

        public override string MakeSound()
        {
            return "Chirp!";
        }

        public void Fly()
        {
            IsFlying = true;
        }

        public void ActCrazy(ObservableCollection<string> log, IList<Animal> allAnimals)
        {
            IsFlying = !IsFlying;
            string state = IsFlying ? "is now flying" : "has landed";
            log.Add($"{Name} {state}. CHIRP!!!");
        }
    }
}
