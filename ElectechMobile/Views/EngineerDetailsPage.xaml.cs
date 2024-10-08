using Elc2025API.Models;
using ElectechMobile.Services;

namespace ElectechMobile.Views;

public partial class EngineerDetailsPage : ContentPage
{
    private int engineerId;  // Field to store the ID

    public EngineerDetailsPage(int Id)
	{
		InitializeComponent();
		InitializeDetails(Id);
        engineerId = Id;
        Getcustomer(Id);

    }
	async void InitializeDetails(int id)
	{
		var engineer = await ApiService<Engineer>.GetById(id, nameof(Engineer));
		EngName.Text = engineer.EngName;
		PhoneNum.Text = engineer.Phone;
		Mobile.Text = engineer.Mobil;
		Area.Text= engineer.EngArea;
        EngineerPhoto.Source= $"eng_{engineer.Id}.jpg";
    }
    async void Getcustomer(int id)
    {
        int custCount = (await ApiService<Customer>.GetFolwByEngId(id)).Length;
        btnCustomers.Text = $"عملاء لم يتم متابعتهم منذ30يوما {custCount} عميل";
    }
    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private void btnCustomers_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new CustNotFollMonthPage(engineerId));
    }
}