using System;

namespace CollectionsTutorial;

public class CollectionsClass
{
  User _user1;
  User _user2;
  User _user3;

  public CollectionsClass()
  {
    _user1 = new User()
    {
      UserId = 1,
      Name = "jhonny",
      Surname = "Smith",
    };

    _user2 = new User()
    {
      UserId = 2,
      Name = "Tumi",
      Surname = "Sihlangu",
    };

    _user3 = new User()
    {
      UserId = 3,
      Name = "jonny",
      Surname = "Mark",
    };
  }

  public void ListFunction()
  {
    List<User> users = new List<User>();
    users.Add(_user1);
    users.Add(_user2);
    users.Add(_user3);

    var matchUsers = users.Where(u => u.Name.ToLower() == "jonny").ToList();// search in a list

     foreach (var user in matchUsers)
     {
        Console.WriteLine($"{user.UserId}{user.Name}{user.Surname}");
     }
  }

  public void DictionaryFunction()
  {
    var users = new Dictionary<int, User>();
    users.Add(_user1.UserId, _user1);
    users.Add(_user2.UserId, _user2);
    users.Add(_user3.UserId, _user3);

    User user = null;
    bool isMatchFound = users.TryGetValue(2, out user);

    if (isMatchFound)
      Console.WriteLine($"$ User {user.UserId}{user.Name}{user.Surname}");

  }

  public void ArraysFunction()
  {
    User[] users = new User[3];
    users[0] = _user1;
    users[1] = _user2;
    users[2] = _user3;

    for (int i = 0; i < 3; i++)
    {
      var user = users[i];
      Console.WriteLine($"$User:{user.UserId}{user.Name}{user.Surname}");
    }

  }
  }
  
  public class User
  {
    public int UserId { get; set; }
  public string Name { get; set; } 
    public string Surname { get; set; }
  }




