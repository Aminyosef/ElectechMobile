using ElectechMobile.Model;
using ElectechMobile.Services;
using Microsoft.Maui;
using Newtonsoft.Json;
using Syncfusion.Maui.Core;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ElectechMobile.Views;

public partial class ProductTranPage : ContentPage, INotifyPropertyChanged
{
    private int _prodId;
    private ObservableCollection<ProductTrans> _products;

    public event PropertyChangedEventHandler PropertyChanged;

    public ObservableCollection<ProductTrans> Products
    {
        get => _products;
        set
        {
            if (_products != value)
            {
                _products = value;
                OnPropertyChanged();
            }
        }
    }

    public ProductTranPage(int id,string prodName)
    {
        InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;
        _prodId = id;
        BindingContext = this;
        Products = new ObservableCollection<ProductTrans>();
        ProdName.Text = prodName;
    }

   

    async Task GetProductsByCatId()
    {
        try
        {
            busyIndicator.IsRunning = true;

            DateTime sd = SDatepicker.SelectedDate.Value;
            DateTime ed = EDatepicker.SelectedDate.Value;

            var productMotions = await ProductService.GetProductMotion(_prodId, sd, ed);

            Products.Clear();
            foreach (var product in productMotions)
            {
                Products.Add(product);
            }
        }
        catch (Exception ex)
        {
            // Handle or log the exception as needed
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
        finally
        {
            busyIndicator.IsRunning = false;
        }
    }

    private async void btnGetProdMotion_Clicked(object sender, EventArgs e)
    {
        await GetProductsByCatId();
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

   
}


