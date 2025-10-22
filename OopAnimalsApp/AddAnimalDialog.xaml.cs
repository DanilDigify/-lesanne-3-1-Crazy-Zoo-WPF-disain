using System.Windows;
using System.Windows.Controls;

namespace OopAnimalsApp;

public partial class AddAnimalDialog : Window
{
    public string AnimalName { get; private set; } = "";
    public int AnimalAge { get; private set; }
    public string AnimalType { get; private set; } = "";

    public AddAnimalDialog()
    {
        InitializeComponent();
        TypeComboBox.SelectedIndex = 0;
    }

    private void OK_Click(object sender, RoutedEventArgs e)
    {
        string name = NameTextBox.Text.Trim();
        string ageText = AgeTextBox.Text.Trim();
        string? type = TypeComboBox.SelectedItem?.ToString();

        if (string.IsNullOrEmpty(name))
        {
            MessageBox.Show("Please enter an animal name!", "Validation Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (!int.TryParse(ageText, out int age) || age < 0)
        {
            MessageBox.Show("Please enter a valid age!", "Validation Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (string.IsNullOrEmpty(type))
        {
            MessageBox.Show("Please select an animal type!", "Validation Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        AnimalName = name;
        AnimalAge = age;
        AnimalType = type;

        DialogResult = true;
        Close();
    }
}
