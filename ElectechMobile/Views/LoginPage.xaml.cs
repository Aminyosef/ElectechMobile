using Newtonsoft.Json;
using System.Text;

namespace ElectechMobile.Views;

public partial class LoginPage : ContentPage
{
    private readonly HttpClient _httpClient;

    public LoginPage()
    {
        InitializeComponent();
        _httpClient = new HttpClient();
        // ضع هنا عنوان الـ API الخاص بك
        _httpClient.BaseAddress = new Uri("https://amingomaa-001-site4.atempurl.com/api/auth/");
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        LoadingIndicator.IsVisible = true;
        LoadingIndicator.IsRunning = true;
        MessageLabel.Text = string.Empty;

        try
        {
            var loginRequest = new
            {
                UserName = UserNameEntry.Text,
                Password = PasswordEntry.Text
            };

            var json = JsonConvert.SerializeObject(loginRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("login", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                // فك الـ JSON
                var result = JsonConvert.DeserializeObject<LoginResponse>(responseContent);

                if (result.Success)
                {
                    // حفظ التوكن في SecureStorage
                    await SecureStorage.SetAsync("auth_token", result.Token);

                    // إظهار رسالة نجاح أو الانتقال لصفحة أخرى
                    await DisplayAlert("نجاح", "تم تسجيل الدخول بنجاح", "حسنًا");

                    // مثال: الانتقال للصفحة الرئيسية
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    MessageLabel.Text = result.Message;
                }
            }
            else
            {
                MessageLabel.Text = "خطأ في الاتصال بالسيرفر";
            }
        }
        catch (Exception ex)
        {
            MessageLabel.Text = $"خطأ: {ex.Message}";
        }
        finally
        {
            LoadingIndicator.IsVisible = false;
            LoadingIndicator.IsRunning = false;
        }
    }
}

// موديل النتيجة
public class LoginResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public string Token { get; set; }
    public UserInfo User { get; set; }
}

public class UserInfo
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public List<string> Roles { get; set; }
}
