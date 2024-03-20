using System.Windows.Input;
using Microsoft.Maui.Controls;
using PasswordStorage.Models;
using PasswordStorage.Models.Struct;
using PasswordStorage.ViewModels.Base;
using Convert = PasswordStorage.Models.Convert;

namespace PasswordStorage.ViewModels.Implementation;

[QueryProperty("NameOfNote", "NameOfNote")]
public sealed class DataPageViewModel : BaseViewModel
{
    private string _nameOfNote;

    private string _login;

    private string _password;

    private string _note;

    private readonly SingletonDictionary _singletonDictionary;

    private readonly Convert _convert;
    
    public DataPageViewModel()
    {
        _singletonDictionary =  SingletonDictionary.GetInstance();
        
        _convert = new Convert();
        
        NavigateMainPageCommand = new Command(async () => await Shell.Current.GoToAsync(".."));

        SaveCommand = new Command(SaveValue);
    }

    
    public ICommand NavigateMainPageCommand { get; private set; }
    
    public ICommand SaveCommand { get; private set; }

    public string NameOfNote
    {
        get => _nameOfNote;

        set
        {
            SetField(ref _nameOfNote, value);

            if (!_singletonDictionary.UserDataDictionary.TryGetValue(_nameOfNote, out var userData)) return;
            
            Login = userData.Login;
            Password = userData.Password;
            Note = userData.Note;
        }
    }
    
    public string Login
    {
        get => _login;
        
        set => SetField(ref _login, value);
    }

    public string Password
    {
        get => _password;
        
        set => SetField(ref _password, value);
    }

    public string Note
    {
        get => _note;

        set => SetField(ref _note, value);
    }

    private void SaveValue()
    {
        var key = NameOfNote;

        var value = new UserData(Login, Password, Note);
        
        _singletonDictionary.DictionaryAdd(key, value);
        
        _convert.DataToJsonAsync();
    }
}