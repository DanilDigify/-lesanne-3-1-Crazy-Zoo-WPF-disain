# OOP Animals App - WPF .NET 8 Exercise

A minimal but clean WPF desktop application demonstrating OOP principles, including abstract classes, interfaces, polymorphism, and data binding.

## Overview

This application showcases five animal types (Cat, Dog, Bird, Raccoon, Monkey) with different behaviors:
- **Cat**: Steals food from the kitchen
- **Dog**: Barks 5 times
- **Bird**: Toggles flying state and chirps
- **Raccoon**: Finds random trinkets
- **Monkey**: Swaps names of two random animals

## Project Structure

```
OopAnimalsApp/
├── Models/
│   ├── Animal.cs          (abstract base class)
│   ├── IFlyable.cs        (interface)
│   ├── ICrazyAction.cs    (interface)
│   ├── Cat.cs
│   ├── Dog.cs
│   ├── Bird.cs
│   ├── Raccoon.cs
│   └── Monkey.cs
├── Views/
│   ├── MainWindow.xaml
│   ├── MainWindow.xaml.cs
│   ├── AddAnimalDialog.xaml
│   └── AddAnimalDialog.xaml.cs
├── App.xaml
├── App.xaml.cs
└── OopAnimalsApp.csproj
```

## Building & Running

### Prerequisites
- .NET 8 SDK installed

### Build
```bash
cd OopAnimalsApp
dotnet build
```

### Run
```bash
dotnet run
```

## Features

### Animal Management
- **List**: Left panel displays all animals in the collection
- **Select**: Click an animal to view details and enable actions
- **Add**: "Add Animal" button opens a dialog to create new animals
- **Remove**: "Remove Animal" button removes the selected animal

### Animal Actions
- **Make Sound**: Logs the animal's sound to the action log
- **Feed**: Enters a food item and logs "{Name} sõi {food}" (Estonian)
- **Crazy Action**: Triggers type-specific behavior:
  - Cat: logs "stole cheese from the kitchen"
  - Dog: logs "Woof!" 5 times
  - Bird: toggles flying state
  - Raccoon: finds random trinket
  - Monkey: swaps two random animal names

### Logging
- All actions are logged with timestamps in format: `[HH:mm:ss] message`
- Clear Log button empties the log
- Log scrolls automatically as new messages are added

## Git Workflow (Classroom Exercise)

### Initial Setup (Instructor)

```bash
# Create project and initialize git
git init
git add .
git commit -m "Initial commit: OOP Animals App setup"

# Create first issue on GitHub (or simulate locally)
# Issue: "Add three animal classes"
```

### Feature Development (Student 1)

```bash
# Check out feature branch from main
git checkout -b feature/add-animals-from-issue

# Implement the three animal classes (Cat, Dog, Bird)
# Edit Models/ files and MainWindow.xaml.cs as needed

# Stage and commit changes
git add Models/
git add MainWindow.xaml.cs
git commit -m "Add Cat, Dog, and Bird animal classes

- Cat implements ICrazyAction: steals cheese
- Dog implements ICrazyAction: barks 5 times
- Bird implements IFlyable and ICrazyAction: toggles flying
"

# Push branch
git push origin feature/add-animals-from-issue
```

### Code Review Checklist (Student 2)

When reviewing the Pull Request, check:
- [ ] Class names are clear and follow C# naming conventions
- [ ] `Describe()` method returns proper format (e.g., "Muri (2 y/o)")
- [ ] `MakeSound()` returns appropriate sound for each animal
- [ ] `ActCrazy()` implementation logs messages correctly
- [ ] No external package dependencies (BCL only)
- [ ] Code is simple and teachable
- [ ] Interfaces are properly implemented
- [ ] Property changes trigger UI updates (via INotifyPropertyChanged)

### Merging Feature Branch

```bash
# Switch to feature branch (or review PR online)
git checkout feature/add-animals-from-issue

# Verify final state
git log --oneline -5

# Merge back to main
git checkout main
git merge feature/add-animals-from-issue --no-ff

# Delete feature branch
git branch -d feature/add-animals-from-issue
git push origin --delete feature/add-animals-from-issue

# Push main
git push origin main
```

## Code Examples

### Creating a Custom Animal

```csharp
public class Elephant : Animal, ICrazyAction
{
    public Elephant(string name, int age) : base(name, age) { }

    public override string MakeSound()
    {
        return "Trumpet!";
    }

    public void ActCrazy(ObservableCollection<string> log, IList<Animal> allAnimals)
    {
        log.Add($"{Name} sprayed water everywhere!");
    }
}
```

### Adding to MainWindow.xaml.cs

Update the `AddAnimal_Click` method to include new types:

```csharp
Animal? newAnimal = type switch
{
    "Cat" => new Cat(name, age),
    "Dog" => new Dog(name, age),
    "Bird" => new Bird(name, age),
    "Raccoon" => new Raccoon(name, age),
    "Monkey" => new Monkey(name, age),
    "Elephant" => new Elephant(name, age),  // Add this
    _ => null
};
```

## Key OOP Concepts Demonstrated

1. **Abstract Classes**: `Animal` defines a contract for all animals
2. **Interfaces**: `IFlyable` and `ICrazyAction` enable flexible behavior composition
3. **Polymorphism**: `MakeSound()` and `ActCrazy()` have type-specific implementations
4. **Encapsulation**: Properties with private backing fields and validation
5. **Data Binding**: WPF binds UI to `ObservableCollection<Animal>`
6. **Property Change Notification**: `INotifyPropertyChanged` for UI updates

## Architecture Notes

- **No external dependencies**: Uses only BCL (System, System.Collections.ObjectModel, System.Windows, etc.)
- **Simple code-behind**: Straightforward event handlers rather than complex MVVM
- **In-memory only**: No database or file I/O
- **Minimal generics**: Only `List<T>` and `ObservableCollection<T>` as required

## Deliverables

✅ Complete working WPF application
✅ Five animal implementations with different behaviors
✅ Clean UI with animal list, details, and action log
✅ Add/Remove animal functionality
✅ Proper INotifyPropertyChanged for UI updates
✅ Git workflow documentation for classroom use
✅ No third-party dependencies

## Testing

To test all features:
1. Launch the app
2. Select different animals and click "Make Sound"
3. Enter food in textbox and click "Feed"
4. Click "Crazy Action" and observe type-specific behavior
5. Click "Add Animal" to create new instances
6. Click "Remove Animal" to delete from list
7. Verify log messages appear with timestamps

## License

Educational exercise - MIT License

---

**Author**: Generated for OOP teaching exercise
**Target Framework**: .NET 8 WPF
**Created**: 2025
