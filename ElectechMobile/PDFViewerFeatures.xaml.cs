using ElectechMobile.Services;
using System.Reflection;
namespace ElectechMobile;
///<summary>
///PDFViewerFeatures class
///</summary>
public partial class PDFViewerFeatures : ContentPage
{
	///<summary>
    ///PDFViewerFeatures constructor
    ///</summary>
    public PDFViewerFeatures(string pdfName)
    {
        InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;
        BindingContext = new PDFViewModel(pdfName);
        
    }
}
///<summary>
///ViewModel class for the PDFViewerFeatures 
///</summary>
public class PDFViewModel
{
    public Stream PdfDocumentStream { get; set; } = new MemoryStream();
    public PDFViewModel(string url)
    {
        Init(url);
        //Accessing the PDF document that is added as embedded resource as stream.
    }
    async void Init(string url)
    {
        using (HttpClient client = new())
        (await client.GetStreamAsync($"http://amingomaa-001-site24.dtempurl.com/Assets/{url}")).CopyTo(PdfDocumentStream);
        int temp=0;
    }
}