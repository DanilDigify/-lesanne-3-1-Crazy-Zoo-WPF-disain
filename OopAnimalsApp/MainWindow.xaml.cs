using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using OopAnimalsApp.Models;

namespace OopAnimalsApp;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    private ObservableCollection<Animal> _animals = null!;
    private ObservableCollection<string> _log = null!;
    private Animal? _selectedAnimal;

    public ObservableCollection<Animal> Animals
    {
        get => _animals;
        set
        {
            if (_animals != value)
            {
                _animals = value;
                OnPropertyChanged();
            }
        }
    }

    public ObservableCollection<string> Log
    {
        get => _log;
        set
        {
            if (_log != value)
            {
                _log = value;
                OnPropertyChanged();
            }
        }
    }

    public Animal? SelectedAnimal
    {
        get => _selectedAnimal;
        set
        {
            if (_selectedAnimal != value)
            {
                _selectedAnimal = value;
                OnPropertyChanged();
                UpdateAnimalDetails();
                UpdateButtonStates();
            }
        }
    }

    public MainWindow()
    {
        _animals = new ObservableCollection<Animal>();
        _log = new ObservableCollection<string>();

        InitializeComponent();

        DataContext = this;

        SeedAnimals();
    }

    private void SeedAnimals()
    {
        Animals.Add(new Cat("Muri", 2));
        Animals.Add(new Dog("Rex", 4));
        Animals.Add(new Bird("Piu", 1));
        Animals.Add(new Raccoon("Bandit", 3));
        Animals.Add(new Monkey("Koko", 5));
    }

    private void UpdateAnimalDetails()
    {
        if (SelectedAnimal != null)
        {
            AnimalDescTextBlock.Text = SelectedAnimal.Describe();
        }
        else
        {
            AnimalDescTextBlock.Text = "(No animal selected)";
        }
    }

    private void UpdateButtonStates()
    {
        bool hasSelection = SelectedAnimal != null;
        MakeSoundBtn.IsEnabled = hasSelection;
        FeedBtn.IsEnabled = hasSelection;
        CrazyActionBtn.IsEnabled = hasSelection;
    }

    private void LogMessage(string message)
    {
        string timestamp = DateTime.Now.ToString("[HH:mm:ss]");
        Log.Add($"{timestamp} {message}");
    }

    private void MakeSound_Click(object sender, RoutedEventArgs e)
    {
        if (SelectedAnimal != null)
        {
            string sound = SelectedAnimal.MakeSound();
            LogMessage($"{SelectedAnimal.Name} says: {sound}");
        }
    }

    private void Feed_Click(object sender, RoutedEventArgs e)
    {
        string food = FoodTextBox.Text.Trim();

        if (string.IsNullOrEmpty(food))
        {
            MessageBox.Show("Please enter a food item!", "Validation Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (SelectedAnimal != null)
        {
            LogMessage($"{SelectedAnimal.Name} sõi {food}");
            FoodTextBox.Clear();
        }
    }

    private void CrazyAction_Click(object sender, RoutedEventArgs e)
    {
        if (SelectedAnimal is ICrazyAction crazyAnimal)
        {
            crazyAnimal.ActCrazy(Log, Animals);
        }
    }

    private void AddAnimal_Click(object sender, RoutedEventArgs e)
    {
        AddAnimalDialog dialog = new AddAnimalDialog();
        if (dialog.ShowDialog() == true)
        {
            string name = dialog.AnimalName;
            int age = dialog.AnimalAge;
            string type = dialog.AnimalType;

            Animal? newAnimal = type switch
            {
                "Cat" => new Cat(name, age),
                "Dog" => new Dog(name, age),
                "Bird" => new Bird(name, age),
                "Raccoon" => new Raccoon(name, age),
                "Monkey" => new Monkey(name, age),
                _ => null
            };

            if (newAnimal is not null)
            {
                Animals.Add(newAnimal);
                LogMessage($"Added {name} the {type}");
            }
        }
    }

    private void RemoveAnimal_Click(object sender, RoutedEventArgs e)
    {
        if (SelectedAnimal != null)
        {
            string animalName = SelectedAnimal.Name;
            Animals.Remove(SelectedAnimal);
            LogMessage($"Removed {animalName}");
        }
    }

    private void ClearLog_Click(object sender, RoutedEventArgs e)
    {
        Log.Clear();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
