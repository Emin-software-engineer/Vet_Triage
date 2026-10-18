namespace Vet_Triage;

public partial class TriagePage : ContentPage
{
	public TriagePage()
	{
		InitializeComponent();
	}

    private async void OnEvaluateClicked(object sender, EventArgs e)
    {
        bool emergency =
            BreathingCheck.IsChecked ||
            SeizureCheck.IsChecked ||
            BleedingCheck.IsChecked ||
            PoisonCheck.IsChecked;

        bool hasOtherSymptoms =
            VomitingCheck.IsChecked ||
            WeaknessCheck.IsChecked;

        if (AnimalPicker.SelectedIndex < 0)
        {
            await DisplayAlert(
                "Eksik bilgi",
                "Lütfen hayvan türünü seç.",
                "Tamam");
            return;
        }

        if (!emergency && !hasOtherSymptoms &&
            string.IsNullOrWhiteSpace(NotesEditor.Text))
        {
            await DisplayAlert(
                "Belirti girilmedi",
                "Lütfen en az bir belirti seç veya açıklama yaz.",
                "Tamam");
            return;
        }

        string petName = string.IsNullOrWhiteSpace(PetNameEntry.Text)
            ? "İsimsiz hayvan"
            : PetNameEntry.Text.Trim();

        if (emergency)
        {
            await DisplayAlert(
                "ACİL VETERİNER DESTEĞİ",
                $"{petName} için seçilen belirtiler acil müdahale gerektirebilir.\n\n" +
                "En yakın acil veteriner kliniğiyle hemen iletişime geç. " +
                "Uygulama teşhis koymaz; bu sonucu beklemek için veteriner desteğini geciktirme.",
                "Anladım");
        }
        else
        {
            await DisplayAlert(
                "Veteriner değerlendirmesi",
                $"{petName} için belirtiler kaydedildi.\n\n" +
                "Bu basit prototip, belirtilerin tüm risklerini değerlendiremez. " +
                "Veteriner hekimle görüşerek uygun yönlendirme al.",
                "Tamam");
        }
    }

}