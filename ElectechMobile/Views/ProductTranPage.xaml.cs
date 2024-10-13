using ElectechMobile.Model;
using ElectechMobile.Services;
using Microsoft.Maui;
using Syncfusion.Maui.Core;

namespace ElectechMobile.Views;

public partial class ProductTranPage : ContentPage
{
    private int _prodId;
    public ProductTranPage(int id)
    {
        InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;
        _prodId = id;
        GetProductName(_prodId);

    }
    public ProductTrans[] Products { get; set; }

    async void GetProductName(int id)
    {
        ProdName.Text = (await ProductService.GetProductByCatId(_prodId)).FirstOrDefault(x => x.id == _prodId).name.ToString();

    }
    async void GetProductsByCatId(int prodId)
    {
        try
        { 
           busyIndicator.IsRunning = true;
            DateTime sd = new();
            DateTime ed = new();
            ed = EDatepicker.SelectedDate.Value;
            sd = EDatepicker.SelectedDate.Value;

            var getProductsm = await ProductService.GetProductMotion(_prodId, sd,ed);
            
            if (getProductsm != null)
            {



               listView.ItemsSource = getProductsm;


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