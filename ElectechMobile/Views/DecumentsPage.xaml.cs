using System.Xml.Linq;

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

    private void atexRv1_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("newTÜVIT16ATEX001URev1.pdf"));

    }

    private void atexRv2_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("TÜV_IT_16_ATEX_023QRev2.pdf"));
       

    }

    private void azDecl_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("DECLARATIONOFCONFORMITY_AZ_SD_IP66.pdf"));

    }

    private void alfBS_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("EnglishBR.pdf"));
    }

    private void alfEu_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("EnglishEU.pdf"));

    }

    private void adel_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("ADEL system Conformity Declaration FLEX 2016.pdf"));

    }

    private void brescat_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("BRES2017.pdf"));

    }

    private void artcat_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("artcatalogue.pdf"));

    }

    private void brescer_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("BRESIEC62208.pdf"));

    }

    private void safyastar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("ASTARUVResistance.pdf"));

    }

    private void safytest_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("RIGIDEZDIELECTRICAENVOLVENTES_eng.pdf"));

    }

    private void verextraLed_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("ks_en_EXTRA-N-LEDNEW.pdf"));

    }

    private void verextrAtEX_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("atex_en_extra-n-led.pdf"));

    }

    private void vergRYLed_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("ks_en_GREY-LED.pdf"));

    }

    private void verGRYAtEX_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("atex_en_grey-n-led.pdf"));

    }

    private void verknAtEX_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("ENG_ATEX_K-N.pdf"));
        
    }

    private void verksn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("ks_en_k-2-n_k-3-n.pdf"));

    }
    
    private void adelCatalog_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("Flex Catalogue-A4.pdf"));

    }

    private void FLEX9024A_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("FLEX9024A_R15-D.pdf"));

    }

    private void FLEX17024A_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("FLEX17024A_R15-D.pdf"));

    }

    private void adel_Clicked_1(object sender, EventArgs e)
    {

    }

    private void FLEX17024B_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("FLEX17024B_R14-D.pdf"));

    }

    private void FLEX28024A_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("FLEX28024A_R15-D.pdf"));

    }

    private void FLEX50024B_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("FLEX50024B_R14-D.pdf"));

    }

    private void ULcertificate_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("UL certificate.pdf"));

    }

    private void Geny_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PDFViewerFeatures("Manual_GENIE_NX.pdf"));

    }
}
