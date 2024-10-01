using ElectechMobile.Model;
using ElectechMobile.Services;

namespace ElectechMobile.Views;

public partial class OneSalePage : ContentPage
{
    private int _saleId;
    public SaleDet[] saleDets { get; private set; }
    public sal[] sales { get; private set; }

    public OneSalePage(int id)
    {
        InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;
        _saleId = id;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await InitializeSaleData();
    }

    private async Task InitializeSaleData()
    {
        try
        {
            sales = await Salservice.GetAll();
            if (sales == null || sales.Length == 0)
            {
                await DisplayAlert("Error", "Failed to load sales data", "OK");
                return;
            }

            var sale = sales.FirstOrDefault(x => x.id == _saleId);
            if (sale == null)
            {
                await DisplayAlert("Error", $"Sale with ID {_saleId} not found", "OK");
                return;
            }

            salNo.Text = _saleId.ToString();
            custName.Text = sale.custName?.ToString() ?? "N/A";

            saleDets = await Salservice.GetSalId(_saleId);
            if (saleDets == null)
            {
                await DisplayAlert("Error", "Failed to load sale details", "OK");
                return;
            }

            dataGrid.ItemsSource = saleDets.ToList();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            Console.WriteLine($"Error in InitializeSaleData: {ex}");
        }
    }
}