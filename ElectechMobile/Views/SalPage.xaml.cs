using ElectechMobile.Model;
using ElectechMobile.Services;
using Syncfusion.Maui.Core;

namespace ElectechMobile.Views;

public partial class SalPage : ContentPage
{
	public SalPage()
	{
		InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;
        InitCustomers();
    }
  
    public sal[] sales { get; private set; }
    public async void InitCustomers()
    {
        busyIndicator.IsRunning = true;

        try
        {
            // Perform your loading operations here
            await Task.Delay(4000); // Simulating a 3-second loading time

            sales = await Salservice.GetAll();
            dataGrid.ItemsSource = sales;
        }
        finally
        {
            // Hide the busy indicator when loading is complete
            busyIndicator.IsRunning = false;
        }


    }
    private async void filterText_TextChanged(object sender, TextChangedEventArgs e)
    {
        dataGrid.ItemsSource = string.IsNullOrEmpty(e.NewTextValue) ? sales : await Salservice.Search(e.NewTextValue); //sales.Where(x => x.custName.Contains(text ?? x.custName, StringComparison.OrdinalIgnoreCase) || x.id.ToString().Contains(text ?? x.id.ToString(), StringComparison.OrdinalIgnoreCase));
    }

    private async void dataGrid_SelectionChanged(object sender, Syncfusion.Maui.DataGrid.DataGridSelectionChangedEventArgs e)
    {
        try
        {
            if (e?.AddedRows == null || e.AddedRows.Count == 0)
            {
                Console.WriteLine("No rows selected");
                return;
            }

            var selectedRow = e.AddedRows[0];
            if (selectedRow == null)
            {
                Console.WriteLine("Selected row is null");
                return;
            }

            // Assuming Sal_tbl is your data type
            if (selectedRow is sal selectedSal)
            {
                if (selectedSal.id <= 0)
                {
                    Console.WriteLine($"Invalid sale ID: {selectedSal.id}");
                    await DisplayAlert("Error", "Invalid sale ID", "OK");
                    return;
                }

                Console.WriteLine($"Navigating to OneSalePage with ID: {selectedSal.id}");
                await Navigation.PushAsync(new OneSalePage(selectedSal.id));
            }
            else
            {
                Console.WriteLine($"Selected row is not a Sal_tbl object. Actual type: {selectedRow.GetType().Name}");
                await DisplayAlert("Error", "Selected row is not a valid sale object", "OK");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in selection changed: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
        finally
        {
            if (dataGrid != null)
            {
                dataGrid.ClearSelection();
            }
            else
            {
                Console.WriteLine("dataGrid is null in finally block");
            }
        }

    }

}