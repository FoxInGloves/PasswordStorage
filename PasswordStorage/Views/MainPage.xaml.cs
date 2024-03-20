using PasswordStorage.ViewModels.Implementation;

namespace PasswordStorage.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel mainPageViewModel)
    {
        InitializeComponent();
        
        BindingContext = mainPageViewModel;
    }
}