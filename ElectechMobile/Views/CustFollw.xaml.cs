using ElectechMobile.Model;
using ElectechMobile.Services;
using ElectechMobile.Viewmodel;

namespace ElectechMobile.Views;

public partial class CustFollw : ContentPage
{
    public CustFollw(int id)
    {
        InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;
        InitCustomerAsync(id);

    }
    public CustomerFlow[] Follws { get; private set; }


    public async Task InitCustomerAsync(int id)
    {
        try
        {
            var cust = await ApiService<Customer>.GetById(id);
            var follows = await ApiService<CustomerFlow>.GetFolwByCustId(id);

            if (cust != null)
            {
                custNameLabel.Text = cust.custName;

                if (follows != null)
                {
                    var followItems = new List<FollowItem>();

                    foreach (var item in follows)
                    {
                        followItems.Add(new FollowItem
                        {
                            Date = item.date.ToShortDateString(),
                            Detail = item.details
                        });
                    }

                    listView.ItemsSource = followItems.Last(10);
                }
            }
        }
        catch (Exception ex)
        {
            // Handle or log the exception as needed
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
