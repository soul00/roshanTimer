using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace roshTimerTest;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void Button_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            // Get the input as a string
            string input = MyTextBox.Text;

            // Ensure input is a valid 4-digit number
            if (!int.TryParse(input, out int numericInput) || input.Length != 4)
            {
                ConvertedTimeLabel.Content = "Invalid input! Enter a 4-digit number.";
                return;
            }

            // Convert numeric format (e.g., 3322) into time format (33:22)
            int minutes = numericInput / 100; // Extract the first two digits as minutes
            int seconds = numericInput % 100; // Extract the last two digits as seconds

            // Validate seconds range
            if (seconds >= 60)
            {
                ConvertedTimeLabel.Content = "Invalid seconds! Last two digits must be < 60.";
                return;
            }

            // Add 10 minutes
            minutes += 8;

            int rangeMinutes = minutes + 3;
            // Display the time format
            ConvertedTimeLabel.Content = $"Roshan time: {minutes:D2}:{seconds:D2} - {rangeMinutes:D2}:{seconds:D2}";

            // Convert back to numeric format (e.g., 4322)
            int newNumericFormat = (minutes * 100) + seconds;
        }
        catch (Exception ex)
        {
            ConvertedTimeLabel.Content = "Error: " + ex.Message;
        }
    }
    
    public void OnCopyToClipboardClick(object sender, RoutedEventArgs e)
    {
        
        if (!string.IsNullOrEmpty(ConvertedTimeLabel.Content.ToString()))
        {
            // Copy the text to the clipboard
            Clipboard.SetText(ConvertedTimeLabel.Content.ToString());
        }
    }

}