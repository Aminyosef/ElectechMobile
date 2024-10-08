using ElectechMobile.Model;
using ElectechMobile.Services;
using Syncfusion.Maui.Core;

namespace ElectechMobile.Views;

public partial class CategoryPage : ContentPage
{
	public CategoryPage()
	{
		InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;
        LoadAllcateg();
    }
	async void LoadAllcateg()
	{
        busyIndicator.IsRunning=true;
        dataGrid.ItemsSource = await ProductService.GetCategories();
        await Task.Delay(1000);
        busyIndicator.IsRunning=false;

    }

    private async void dataGrid_SelectionChanged(object sender, Syncfusion.Maui.DataGrid.DataGridSelectionChangedEventArgs e)
    {
        if (dataGrid.SelectedRow is Category category)
        {
            await Navigation.PushAsync(new ProductsListPage(category.id));
            dataGrid.SelectedRow = null;
        }
    }
}