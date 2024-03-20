using System.Collections.ObjectModel;
using System.Windows.Input;
using PasswordStorage.Services;
using Notes_MAUI.Views;
using PasswordStorage.Models;
using PasswordStorage.ViewModels.Base;
using Convert = PasswordStorage.Models.Convert;

namespace PasswordStorage.ViewModels.Implementation;

public sealed class MainPageViewModel : BaseViewModel
{
    private readonly NavigationService _navigationService;
    
    private readonly SingletonDictionary _singletonDictionary;

    private ObservableCollection<string> _notes;

    private readonly Convert _convert;
    
    //TODO как-то сделать добавление элементов из collectionView в словарь (мб триггер на переход с DataPage на MainPage)
    //TODO или добавлять по кнопке "Save" на другой странице
    public MainPageViewModel()
    {
        _navigationService = new NavigationService();
        
        _singletonDictionary = SingletonDictionary.GetInstance();

        _convert = new Convert();
        
        _notes = _singletonDictionary.DictionaryToObservableCollection();
        
        NavigateDataPageCommand = new Command<string>(parameter =>
            _navigationService.NavigateToDataPage(parameter));
        
        //TODO добавить удаление элемента
        DeleteCommand = new Command( async () => 
            await Application.Current.MainPage.DisplayAlert("Удалено", "Удалено", "Ok"));
        
        AddNoteCommand = new Command(AddNoteAsync);
    }
    
    public ObservableCollection<string> Notes
    {
        get => _notes;

        set => SetField(ref _notes, value);
    }

    public ICommand NavigateDataPageCommand { get; private set;  }
    
    public ICommand DeleteCommand { get; private set; }
    
    public ICommand AddNoteCommand { get; private set; }

    private Task NavigateToDataPage(string name)
    {
        return Shell.Current.GoToAsync($"{nameof(DataPage)}?NameOfNote={name}");
    }

    private async void AddNoteAsync()
    {
        //TODO При отмене добавления нас всё раввно кидает на следующую страницу
        var newNote = await Application.Current.MainPage.DisplayPromptAsync
            ("Name", "Enter the name of the service", "Ok", "Cancel");

        if (newNote is "") return;
        if (Notes.Contains(newNote))
            await Application.Current.MainPage.DisplayAlert("A service with this name already exists", "", "ok");
        
        Notes.Add(newNote);
        await NavigateToDataPage(newNote);

    }
}