using ElectechMobile.Services;

namespace ElectechMobile.Views;

public partial class CustNotFollMonthPage : ContentPage
{
	public CustNotFollMonthPage(int id)
	{
		InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;
        Getcustomer(id);
        dataGrid.ShowSortNumbers = true;
    }
    async void Getcustomer(int id)
    {
        dataGrid.ItemsSource = await ApiService<Customer>.GetFolwByEngId(id);

    }
    private void dataGrid_SelectionChanged(object sender, Syncfusion.Maui.DataGrid.DataGridSelectionChangedEventArgs e)
    {
        if (dataGrid.SelectedRow is Customer customer)
        {
            Navigation.PushAsync(new CustomerDisplayPage(customer.id));
            dataGrid.SelectedRow = null;
        }
    }

    // Call this after setting ItemsSource
}