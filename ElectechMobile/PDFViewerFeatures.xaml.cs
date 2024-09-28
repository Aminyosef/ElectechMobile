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
    public Stream PdfDocumentStream { get; set; }
    public PDFViewModel(string fileName)
    {
        //Accessing the PDF document that is added as embedded resource as stream.
        PdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream($"ElectechMobile.Assets.{fileName}");
    }
}