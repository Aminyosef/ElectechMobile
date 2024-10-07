using Elc2025API.Models;
using ElectechMobile.Services;

namespace ElectechMobile.Views;

public partial class EngineerListPage : ContentPage
{
	public EngineerListPage()
	{
		InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;
        InitializeData();
	}
	public Engineer[] Engineers { get; set; }
	async void InitializeData()
	{
		busyIndicator.IsRunning = true;
		Engineers = (await ApiService<Engineer>.GetAll(nameof(Engineer)))
             .Where(eng => eng.Id != 6).ToArray(); 
		dataGrid.ItemsSource = Engineers;
		await Task.Delay(3000);
		busyIndicator.IsRunning = false;
	}

    private async void dataGrid_SelectionChanged(object sender, Syncfusion.Maui.DataGrid.DataGridSelectionChangedEventArgs e)
    {
		if(e.AddedRows[0] is Engineer eng)
		{
			await Navigation.PushAsync(new EngineerDetailsPage(eng.Id));
		}
		else
		{
			await DisplayAlert("Error", "Selected object is another type", "Cancel");
		}
    }
}