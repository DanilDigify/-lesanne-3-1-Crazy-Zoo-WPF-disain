using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OopAnimalsApp.Models
{
    public abstract class Animal : INotifyPropertyChanged
    {
        private string _name;
        private int _age;

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged();
                }
            }
        }

        protected Animal(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public virtual string Describe()
        {
            return $"{Name} ({Age} y/o)";
        }

        public abstract string MakeSound();

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
