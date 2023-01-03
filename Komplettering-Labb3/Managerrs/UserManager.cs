using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Documents;
using Komplettering_Labb3.DataModels.Products;
using Komplettering_Labb3.DataModels.Users;
using Komplettering_Labb3.Enums;

namespace Komplettering_Labb3.Managerrs;

public static class UserManager
{
    private static IEnumerable<User> _users = new List<User>();
    public static IEnumerable<User>? Users => _users;

    public static string path = (Path.Combine(Environment.GetFolderPath(folder: Environment.SpecialFolder.LocalApplicationData), "Store"));
    
    private static User _currentUser;
    public static User CurrentUser  
    {
        get => _currentUser;
        set
        { 
            _currentUser = value;
            CurrentUserChanged?.Invoke();
        }
    }

    public static event Action CurrentUserChanged;

    // Skicka detta efter att användarlistan ändrats eller lästs in
    public static event Action UserListChanged;

    public static bool IsAdminLoggedIn => CurrentUser.Type is UserTypes.Admin;

    public static void ChangeCurrentUser(string name, string password, UserTypes type)
    {
        throw new NotImplementedException();
    }

    public static void LogOut()
    {
        throw new NotImplementedException();
    }

    public static async Task SaveUsersToFile()
    {
        var filePath = Path.Combine(path, "Users.json");
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            await sw.WriteLineAsync(JsonSerializer.Serialize(_users,
                new JsonSerializerOptions() { WriteIndented = true }));
        }
    }

    public static async Task LoadUsersFromFile()
    {
        string filePath = Path.Combine(path, "Users.json");
        using (StreamReader r = new StreamReader(filePath))
        {
            string json = await r.ReadToEndAsync();
            _users = JsonSerializer.Deserialize<List<User>>(json);
        }
    }
    public static void Register(string name, string password, UserTypes userType)
    {
        if (userType is UserTypes.Admin)
        {
            _users = _users.Append(new Admin(name, password));
        }
        else if (userType is UserTypes.Customer)
        {
            _users = _users.Append(new Customer(name, password));
        }
        SaveUsersToFile();
    }
    public static bool LogIn(string name, string password)
    {
        LoadUsersFromFile();
        var user = _users.FirstOrDefault(u => u.Name.Equals(name));
        if (user == null)
        {
            return false;
        };
        if (user.Authenticate(password))
        {
            _currentUser = user;
            return true;
        };
        return false;
    }
}