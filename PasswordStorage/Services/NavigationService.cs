using Microsoft.Maui.Controls;
using Notes_MAUI.Views;
using PasswordStorage.Services.Interface;

namespace PasswordStorage.Services;

public class NavigationService : INavigationService
{
    public Task NavigateToDataPage(string name)
    {
        return Shell.Current.GoToAsync($"{nameof(DataPage)}?NameOfNote={name}");
    }

    public Task NavigateToPreviousPage()
    {
        return Shell.Current.GoToAsync("..");
    }
}