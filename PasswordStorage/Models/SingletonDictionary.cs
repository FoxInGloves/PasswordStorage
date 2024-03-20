using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using PasswordStorage.Models.Struct;

namespace PasswordStorage.Models;

public class SingletonDictionary
{
    private static SingletonDictionary _instance;
    
    private ConcurrentDictionary<string, UserData> _userDataDictionary;

    public SingletonDictionary()
    {
        _userDataDictionary = new ConcurrentDictionary<string, UserData>();
    }
        
    public ConcurrentDictionary<string, UserData> UserDataDictionary
    {
        get => _userDataDictionary;

        set => _userDataDictionary = value; 
    }
    
    public static SingletonDictionary GetInstance()
    {
        return _instance ??= new SingletonDictionary();
    }

    public void DictionaryAdd(string key, UserData value)
    {
        if (!_userDataDictionary.ContainsKey(key))
        {
            _userDataDictionary.TryAdd(key, value);
        }
        else
        {
            //_userDataDictionary.Remove(key);
            _userDataDictionary.TryAdd(key, value);
        }
    }

    /*public void DictionaryDelete(string key)
    {
        try
        {
            _userDataDictionary.TryRemove(key, );
        }
        catch (Exception e)
        {
            Console.WriteLine("Error when deleting from the dictionary");
            Console.WriteLine(e);
            Console.WriteLine(e.Message);
            throw;
        }
    }*/

    public ObservableCollection<string> DictionaryToObservableCollection()
    {
        var observableCollection = new ObservableCollection<string>();

        foreach (var word in UserDataDictionary)
        {
            observableCollection.Add(word.Key);
        }

        return observableCollection;
    }
}