using EventosApp.Models;
namespace EventosApp.Views;

public partial class CreateEvent : ContentPage
{
    public CreateEvent()
    {
        InitializeComponent();
        
        var appProperties = (App)Application.Current!;

        PickPlace.ItemsSource = appProperties.Locais;

        DtpkStart.MinimumDate = DateTime.Now;
        DtpkEnd.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        DtpkEnd.MinimumDate = DtpkStart.Date.AddDays(1);
        DtpkEnd.MaximumDate = DtpkStart.Date.AddMonths(3);
    }

    private async void Comprar(object? sender, EventArgs e)
    {
        try
        {
            Evento ev = new Evento()
            {
                LocalSel = (Local) PickPlace.SelectedItem,
                EventName = EventName.Text,
                NumPessoas = Convert.ToInt32(PartNum.Text),
                
                DataInicio = DtpkStart.Date,
                DataFim = DtpkEnd.Date
            };

            if (Convert.ToInt32(PartNum.Text) > 500)
            {
                await DisplayAlert("Inválido", "O número de pessoas não pode passar de 500", "Ok");
            } 
            else
            {
                await Navigation.PushAsync(new ConfirmPage()
                {
                    BindingContext = ev
                });
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Algo deu errado", ex.Message, "Ok");
            // ReSharper disable once AsyncVoidMethod
            throw;
        }
    }
    
    private void DtpkStart_OnDateSelected(object? sender, DateChangedEventArgs e)
    {
        DatePicker? element = sender as DatePicker;
        if (element == null) return;
        DateTime selectedCheckinDate = element.Date;
	    
        DtpkEnd.MinimumDate = selectedCheckinDate.AddDays(1);
        DtpkEnd.MaximumDate = selectedCheckinDate.AddMonths(3);
    }
}