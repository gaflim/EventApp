namespace EventosApp;
using Models;

public partial class App : Application
{
    public List<Local> Locais = new()
    {
        new Local
        {
            Desc = "Chácara São Bento \nValor: R$ 150,00",
            Preco = 150
        },
        new Local
        {
            Desc = "Castelo Brando \nValor: R$ 250,00",
            Preco = 250
        },
        new Local
        {
            Desc = "Chácara Bela \nValor: R$ 350,00",
            Preco = 350
        },
        new Local
        {
            Desc = "Santa Melinda \nValor: R$ 450,00",
            Preco = 450
        }
    };
    
    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(new Views.CreateEvent());
    }
}