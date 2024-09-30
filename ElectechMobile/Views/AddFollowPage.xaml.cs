using ElectechMobile.Model;
using ElectechMobile.Services;
using Microsoft.Maui.Graphics;

namespace ElectechMobile.Views;

public partial class AddFollowPage : ContentPage
{
    private int _id; // Class-level variable to store the 'id'

    public AddFollowPage(int id)
    {
        InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;

        _id = id;
        GetCust(id);
    }
    public Customer Customer = new();

    async void GetCust(int id)
    {
        Customer = await ApiService<Customer>.GetById(id);
        lbCust.Text = "اضافة زيارة للعميل :" + "" + Customer.custName;
    }
    private async void AddFlowBton_Clicked(object sender, EventArgs e)
    {


        var custFollowDTO = new CustFolwDTO
        {
            customerId = _id,
            details = TxtFlow.Text

        };

        try
        {
            bool success = await CustService.Post(custFollowDTO);
            if (success)
            {
                await DisplayAlert("Success", "تم اضافة البيانات بنجاح", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "خطأ في ادخال البيانات", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Unexpected error: {ex.Message}", "OK");
        }

    }
}