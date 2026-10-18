namespace Vet_Triage
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnNewCaseClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TriagePage());
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
         
        }
    }
}
