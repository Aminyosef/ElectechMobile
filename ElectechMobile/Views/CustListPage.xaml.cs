using ElectechMobile.Services;
using Syncfusion.Maui.Core;

namespace ElectechMobile.Views;

public partial class CustListPage : ContentPage
{
	public CustListPage()
	{
		InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;
    }
    private async void filterText_TextChanged(object sender, TextChangedEventArgs e)
    {
        dataGrid.ItemsSource = await CustService.GetCustomersByName(e.NewTextValue);
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

