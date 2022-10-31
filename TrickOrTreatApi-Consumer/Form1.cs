using System.Text.Json;
using TrickOrTreatApi.Models;

namespace TrickOrTreatApi_Consumer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnAction_Click(object sender, EventArgs e)
        {
            // Disable any previous errors
            lblError.Visible = false;

            // Fetch the result from the HTTP server
            try
            {
                HalloweenItem result = await TrickOrTreat();

                // Display the result
                if (result.ItemType == HalloweenItem.Type.Trick)
                {
                    // User got a trick!
                    lblResult.Text = "You've been tricked!";
                }
                else
                {
                    // User got a treat!
                    lblResult.Text = $"You got {result.Count} of {result.CandyName}!";
                }

                picResult.LoadAsync(result.ImageUrl);
            }
            catch (Exception ex)
            {
                // There was an error
                MessageBox.Show(ex.Message, "Trick or Treat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblError.Visible = true;
            }
        }

        private async Task<HalloweenItem> TrickOrTreat()
        {
            using HttpClient http = new();

            Stream response = await http.GetStreamAsync(@"https://localhost:7283/TrickOrTreat");
            HalloweenItem? result = await JsonSerializer.DeserializeAsync<HalloweenItem?>(response);
            
            if (result is null)
                throw new InvalidDataException("Receieved a HalloweenItem with invalid data.");

            return result;
        }
    }
}