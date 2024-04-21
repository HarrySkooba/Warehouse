using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Windows;
using WebApi.DB;

namespace FrontEnd
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void OnPasswordChanged(object sender, RoutedEventArgs e)

        {
            if (tb2.Password.Length > 0)
            {
                WaterMark.Visibility = Visibility.Collapsed;
            }
            else
            {
                WaterMark.Visibility = Visibility.Visible;
            }
        }
        private async Task CheckLoginAsync(User loginModel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7107/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync("api/LoginCheck/login", loginModel);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(responseContent, "Success");
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(error, "Error");
                }
            }
        }

        private async void Auth_Button(object sender, RoutedEventArgs e)
        {
            User loginModel = new User
            {
                Name = tb1.Text,
                Password = tb2.Password,
            };

            await CheckLoginAsync(loginModel);
        }
    }
}