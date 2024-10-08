using ElectechMobile.Model;
using ElectechMobile.Services;
using Syncfusion.Maui.Core;

namespace ElectechMobile.Views;

public partial class ProductsListPage : ContentPage
{
    private int _catId;
	public ProductsListPage(int id)
	{
		InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;
        _catId = id;
        GetProductsByCatId(_catId);
       
    }
    public Product[] Products { get; set; }
    async void GetProductsByCatId(int prodId)
	{
        try
        {
            busyIndicator.IsRunning = true;

            var getProducts = await ProductService.GetProductByCatId(prodId);

            if (getProducts != null)
            {
               

                CatName.Text= (await ProductService.GetCategories()).FirstOrDefault(x=>x.id== _catId).catName.ToString();

                listView.ItemsSource=getProducts;


            }
            await Task.Delay(1000);
            busyIndicator.IsRunning = false;
        }
        catch (Exception ex)
        {
            // Handle or log the exception as needed
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

    }
}