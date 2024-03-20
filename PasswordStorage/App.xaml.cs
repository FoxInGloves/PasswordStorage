using Notes_MAUI;

namespace PasswordStorage;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}