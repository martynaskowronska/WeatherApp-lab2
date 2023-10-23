using Newtonsoft.Json;
using System.Net;
using System.Xml.Linq;
using WeatherApp.ViewModel;
using WeatherApp.Model;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        AccuWeatherService accuWeatherService;
        public Form1()
        {
            InitializeComponent();
            accuWeatherService = new AccuWeatherService(new HttpClient());
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            City[] cities = await accuWeatherService.GetLocations(textBox1.Text);

            // Dodanie Data Binding - u�ytkownik widzi nazw� miasta, ale program przechowuje i 
            // wykorzystuje klucz miasta.
            listBox1.DataSource = cities;
            listBox1.DisplayMember = "LocalizedName"; // Wy�wietla nazw� miasta
            listBox1.ValueMember = "Key";     // Przechowuje klucz miasta

        }


        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private async void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCity = (City)listBox1.SelectedItem;

            if (selectedCity != null)
            {
                // Zastosowanie architektury MVC
                textBox2.Text = selectedCity.Country.LocalizedName;

                weatherAppViewModel weatherAppViewModel= new WeatherAppViewModel(selectedCity, accuWeatherService);
                string[] weatherData = await weatherAppViewModel.GetData();
                textBox3.Text = weatherData[0];
                textBox4.Text = weatherData[1];
                textBox5.Text = weatherData[2];
                textBox6.Text = weatherData[3];


                // Wcze�niej w sekcji widoku by�o wprowadzanie zmiennych i obs�uga metod:

                // string administrativeArea = selectedCity.AdministrativeArea.LocalizedName;
                // textBox3.Text = administrativeArea;

                // var weather = await accuWeatherService.GetCurrentConditions(selectedCity.Key);
                // double tempValue = weather.Temperature.Metric.Value;
                // textBox4.Text = Convert.ToString(tempValue);

                // var past6hWeather = await accuWeatherService.GetPast6hConditions(selectedCity.Key);
                // double past6hTempValue = past6hWeather.Temperature.Metric.Value;
                // textBox5.Text = Convert.ToString(past6hTempValue);

                // var past24hWeather = await accuWeatherService.GetPast24hConditions(selectedCity.Key);
                // double past24hTempValue = past24hWeather.Temperature.Metric.Value;
                // textBox6.Text = Convert.ToString(past24hTempValue);

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}