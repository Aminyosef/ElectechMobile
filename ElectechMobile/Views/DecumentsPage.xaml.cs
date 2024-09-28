namespace ElectechMobile.Views;

public partial class DecumentsPage : ContentPage
{
	public DecumentsPage()
	{
		InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("MetalEnclosuresP66Catalogue.pdf"));
    }

    private void fanIp66Cer_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("IP66NEW.pdf"));

    }

    private void fanLoadCent_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("LD_catalog.pdf"));

    }

    private void fanSw_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("SWITCHandJUNCTIONBOX.pdf"));
    }

    private void fanCB_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("AMCBcatalogue.pdf"));

    }

    private void fanWir_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("AWG.pdf"));

    }

    private void ekoCat_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("EKO-en.pdf"));

    }

    private void adh_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("scheda_ADH_en.pdf"));

    }

    private void az_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("NEWcatalougeAZ.pdf"));

    }
}
