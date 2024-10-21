using ElectechMobile.Model;
using ElectechMobile.Services;
using Syncfusion.Maui.Core;

namespace ElectechMobile.Views;

public partial class ProductsListPage : ContentPage
{
    public int _catId;
	public ProductsListPage(int id)
	{
		InitializeComponent();
        BindingContext = this;
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

    private async void btnProdMothon_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;

        if (button?.CommandParameter is Product product)
        {

            // Example: Navigate or perform an action using the product object
             await Navigation.PushAsync(new ProductTranPage(product.id,product.name));
        }
        else
        {
           await DisplayAlert("Error", "Failed to retrieve product information.", "OK");
        }


    }
}