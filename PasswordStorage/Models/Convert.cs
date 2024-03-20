#nullable enable
using System.Collections.Concurrent;
using System.Text.Json;
using PasswordStorage.Models.Struct;

namespace PasswordStorage.Models;

public class Convert
{
    private readonly string _filePath;
    
    private readonly SingletonDictionary _singletonDictionary;
    
    public Convert()
    {
        _filePath = "C:/MAUI projects/PasswordStorage/UserData.json";
        
        _singletonDictionary = SingletonDictionary.GetInstance();
    }
    
    public async void DataToJsonAsync()
    {
        await using FileStream fileStream = new FileStream(_filePath, FileMode.Create);
        
        await JsonSerializer.SerializeAsync<ConcurrentDictionary<string, UserData>>(fileStream, _singletonDictionary.UserDataDictionary);
    }

    public async Task JsonToDataAsync()
    {
        if (!File.Exists(_filePath))
        {
            Task.FromException(new NullReferenceException());
            return;
        }

        await using FileStream openStream = new FileStream(_filePath, FileMode.Open);
            
            _singletonDictionary.UserDataDictionary =
                 JsonSerializer.Deserialize<ConcurrentDictionary<string, UserData>>(openStream);
    }
}