using ElectechMobile.Model;
using ElectechMobile.Services;
using Microsoft.Maui.Controls;
using Syncfusion.Maui.Core;
using Syncfusion.Maui.ListView;
using System.Numerics;

namespace ElectechMobile.Views;

public partial class OneSalePage : ContentPage
{
    private int _saleId;
    public sal[] sales { get; private set; }

    public OneSalePage(int id)
    {
        InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;
        _saleId = id;
        GetProductsByCatId(_saleId);
    }


    public SaleDet[] saleDets { get; set; }
    async void GetProductsByCatId(int prodId)
    {
        try
        {
            busyIndicator.IsRunning = true;

            var getSal = (await Salservice.GetAll()).FirstOrDefault(x=>x.id==_saleId);
            saleDets = await Salservice.GetSalId(_saleId);

            if (getSal != null)
            {


                CatName.Text = getSal.custName.ToString();
                Total.Text = saleDets.Sum(x=>x.amount).ToString();
                Dis.Text=getSal.dis.ToString();
                FinalTotal.Text=getSal.total.ToString();
                sallistView.ItemsSource = saleDets;


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