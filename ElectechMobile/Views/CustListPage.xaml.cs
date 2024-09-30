using ElectechMobile.Services;
using Syncfusion.Maui.Core;

namespace ElectechMobile.Views;

public partial class CustListPage : ContentPage
{
	public CustListPage()
	{
		InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;
        InitCustomers();
    }
    public Customer[] Customers { get; private set; }
    public async void InitCustomers()
    {
        busyIndicator.IsRunning = true;

        try
        {
            // Perform your loading operations here
            await Task.Delay(4000); // Simulating a 3-second loading time

            Customers = await ApiService<Customer>.GetAll();
            dataGrid.ItemsSource = Customers;
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
        dataGrid.ItemsSource = Customers.Where(x => x.custName.Contains(text ?? x.custName, StringComparison.OrdinalIgnoreCase));
    }

    private async void dataGrid_SelectionChanged(object sender, Syncfusion.Maui.DataGrid.DataGridSelectionChangedEventArgs e)
    {
        if (dataGrid.SelectedRow is Customer customer)
        {
            Navigation.PushAsync(new CustomerDisplayPage(customer.id));
            dataGrid.SelectedRow = null;
        }
    }
}

