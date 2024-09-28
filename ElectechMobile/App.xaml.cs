namespace ElectechMobile
{
    public partial class App : Application
    {
        public App()
        {
            //Register Syncfusion license https://help.syncfusion.com/common/essential-studio/licensing/how-to-generate
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NDaF5cWWtCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXZceHRRRGNcUEJ3XUQ=");
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
