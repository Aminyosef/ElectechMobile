using Elc2025API.Models;
using ElectechMobile.Services;

namespace ElectechMobile.Views;

public partial class EngineerDetailsPage : ContentPage
{
	public EngineerDetailsPage(int Id)
	{
		InitializeComponent();
		InitializeDetails(Id);
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

    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private void btnCustomers_Clicked(object sender, EventArgs e)
    {

    }
}