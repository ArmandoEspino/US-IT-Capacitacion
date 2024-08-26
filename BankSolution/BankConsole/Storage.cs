using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace BankConsole;

public static class Storage{

    static string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\users.json";


    public static void AddUser(User user){

        string json = "", usersInFile = "";

        if(File.Exists(filePath)){
            usersInFile = File.ReadAllText(filePath);
        }

        var listUsers = JsonConvert.DeserializeObject<List<Object>>(usersInFile);

        if (listUsers == null){
            listUsers = new List<Object>();
        }

        listUsers.Add(user);

        JsonSerializerSettings settings = new JsonSerializerSettings { Formatting = Formatting.Indented};

        json = JsonConvert.SerializeObject(listUsers, settings);

        File.WriteAllText(filePath,json);
    }

    public static List<User> GetNewUsers(){

        string usersInFile = "";
        var listUsers = new List<User>();

        if (File.Exists(filePath))
            usersInFile = File.ReadAllText(filePath);
        
        var listObjects = JsonConvert.DeserializeObject<List<object>>(usersInFile);

        if (listObjects == null)
            return listUsers;
        
        foreach (object obj in listObjects){
            User newUser;
            JObject user = (JObject)obj;

            if (user.ContainsKey("TaxRegime"))
                newUser = user.ToObject<Client>();
            else
                newUser = user.ToObject<Employee>();

            listUsers.Add(newUser);
        }

        var newUsersList = listUsers.Where(user => user.GetRegisterDate().Date.Equals(DateTime.Today)).ToList();

        return newUsersList;
    }

        public static string UserExist(int ID){

        string usersInFile = "";
        var listUsers = new List<User>();

        if (File.Exists(filePath))
            usersInFile = File.ReadAllText(filePath);
        
        var listObjects = JsonConvert.DeserializeObject<List<object>>(usersInFile);

        if (listObjects == null)
            return "There aren't users today";
        
        foreach (JObject obj in listObjects){
            var user = (int?)obj["ID"];

            if (user == ID){
                return "ID Exist";
            }
        }

        return "";
    }

    public static bool EmailCorrect(string email){

        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        return Regex.IsMatch(email, pattern);
    }

public static string DeleteUser(int ID)
{
    string usersInFile = "";

    if (File.Exists(filePath))
        usersInFile = File.ReadAllText(filePath);
    else
        return "File not found";

    var listObjects = JsonConvert.DeserializeObject<List<JObject>>(usersInFile);

    if (listObjects == null || listObjects.Count == 0)
        return "There aren't users in file";

    var listUsers = new List<User>();

    foreach (var obj in listObjects)
    {
        User newUser;
        JObject user = (JObject)obj;

        if (obj.ContainsKey("TaxRegime"))
            newUser = obj.ToObject<Client>();
        else
            newUser = obj.ToObject<Employee>();

        listUsers.Add(newUser);
    }

    var userToDelete = listUsers.SingleOrDefault(user => user.GetID() == ID);

    if (userToDelete == null)
        return "User not found";

    listUsers.Remove(userToDelete);

    JsonSerializerSettings settings = new JsonSerializerSettings { Formatting = Formatting.Indented };
    string json = JsonConvert.SerializeObject(listUsers, settings);

    File.WriteAllText(filePath, json);

    return "Success";
}


}