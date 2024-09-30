using ElectechMobile.Model;
using ElectechMobile.Services;
using ElectechMobile.Views;

namespace ElectechMobile.Views;

public partial class CustomerDisplayPage : ContentPage
{
    public CustomerDisplayPage(int id)
    {
        InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;

        InitCustomer(id);

    }
    public Customer Customer = new();
    public async void InitCustomer(int id)
    {
        Customer = await ApiService<Customer>.GetById(id);
        CustId.Text = Customer.id.ToString();
        Name.Text = Customer.custName;
        Address.Text = Customer.custAdd;
        EngName.Text = Customer.engName;
        TaxNo.Text = Customer.taxNo;
        CustKind.Text = Customer.kind;
        Mobile.Text = Customer.custMobile;
        Email.Text = Customer.email;
        Phone.Text = Customer.custPhone;
    }

    private async void ExportButton_Clicked(object sender, EventArgs e)
    {
        int custId;
        if (int.TryParse(CustId.Text.Trim(), out custId))
        {
            await Navigation.PushAsync(new Datagridtopdf(custId));
        }

    }

    private async void FollowButton_Clicked(object sender, EventArgs e)
    {
        int custId;
        if (int.TryParse(CustId.Text.Trim(), out custId))
        {
            await Navigation.PushAsync(new CustFollw(custId));
        }
    }

    private async void NewVistBtn_Clicked(object sender, EventArgs e)
    {
        int custId;
        if (int.TryParse(CustId.Text.Trim(), out custId))
        {
            await Navigation.PushAsync(new AddFollowPage(custId));
        }
    }
}