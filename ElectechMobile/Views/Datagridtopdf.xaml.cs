using ElectechMobile.Model;
using ElectechMobile.Services;

namespace ElectechMobile.Views;

public partial class Datagridtopdf : ContentPage
{
    public Datagridtopdf(int id)
    {
        InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;

        InitCustomer(id);

    }
    public Account[] Accounts { get; private set; }
    public async void InitCustomer(int id)
    {
        var cust = await ApiService<Customer>.GetById(id);
        Accounts = await ApiService<Account>.GetByCustId(id);
        custName.Text = cust.custName;
        dataGrid.ItemsSource = Accounts.OrderBy(x => x.salNo);
    }


}