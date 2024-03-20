namespace PasswordStorage.Models.Struct;

//TODO json не может записать поля, только свойства
public record struct UserData(string Login, string Password, string Note); 