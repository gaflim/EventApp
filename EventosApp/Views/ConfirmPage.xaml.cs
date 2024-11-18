namespace EventosApp.Views;

public partial class ConfirmPage : ContentPage
{
    public ConfirmPage()
    {
        InitializeComponent();
    }

    private void Finalizar(object? sender, EventArgs e)
    {
        try
        {
            DisplayAlert("Sucesso", "Evento criado com sucesso!", "Ok");
        }
        catch (Exception ex)
        {
            DisplayAlert("Erro", "Algo deu errado "+ex.Message, "Ok");
            throw;
        }
    }
}