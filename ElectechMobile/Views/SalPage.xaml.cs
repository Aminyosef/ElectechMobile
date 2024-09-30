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
    private void filterText_TextChanged(object sender, TextChangedEventArgs e)
    {
        string? text = string.IsNullOrEmpty(e.NewTextValue) ? null : e.NewTextValue;
        dataGrid.ItemsSource = sales.Where(x => x.custName.Contains(text ?? x.custName, StringComparison.OrdinalIgnoreCase) || x.id.ToString().Contains(text ?? x.id.ToString(), StringComparison.OrdinalIgnoreCase));
    }

    private async void dataGrid_SelectionChanged(object sender, Syncfusion.Maui.DataGrid.DataGridSelectionChangedEventArgs e)
    {
        if (dataGrid.SelectedRow is sal sal)
        {
            Navigation.PushAsync(new OneSalePage(sal.id));
            dataGrid.SelectedRow = null;
        }
    }

}