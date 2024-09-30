using ElectechMobile.Model;
using ElectechMobile.Services;

namespace ElectechMobile.Views;

public partial class OneSalePage : ContentPage
{
    public OneSalePage(int id)
    {
        InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;
        InitCustomer(id);

    }
    public SaleDet[] saleDets { get; private set; }
    public sal[] sales { get; private set; }

    public async void InitCustomer(int id)
    {
        sales = await Salservice.GetAll();
        var cust = sales.FirstOrDefault(x => x.id == id).custName;
        salNo.Text = id.ToString();
        custName.Text = cust.ToString();
        saleDets = await Salservice.GetSalId(id);
        dataGrid.ItemsSource = saleDets.ToList();
    }
}