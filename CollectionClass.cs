using System;
using System.Dynamic;
using System.IO.Compression;

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
    try
        {
            List<User> users = new List<User> { _user1, _user2, _user3 };
            Console.WriteLine("Default sort by Name (IComparable)");
            users.Sort(); 

            foreach (var user in users)
            {
                Console.WriteLine($"{user.UserId} {user.Name} {user.Surname}");
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Sorting failed: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error in ListFunction: " + ex.Message);
        }

  }

  public void DictionaryFunction()
  {
  
        try
        {
            var users = new Dictionary<int, User>();
            users.Add(_user1.UserId, _user1);
            users.Add(_user2.UserId, _user2);
            users.Add(_user3.UserId, _user3);

            if (users.TryGetValue(2, out User user))
            {
                Console.WriteLine($"User: {user.UserId} {user.Name} {user.Surname}");
            }
            else
            {
                Console.WriteLine("User with ID 2 not found.");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Duplicate key: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error in DictionaryFunction: " + ex.Message);
        }
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

  public void HashSetFunction()
  {
    var set = new HashSet<User>();

    var duplicateUser = new User()
    {
      UserId = 4,
      Name = "jhonny",
      Surname = "Smith"
    };

    var duplicateUser5 = new User()
    {
      UserId = 5,
      Name = "jhonny",
      Surname = "Smith"
    };

    set.Add(_user1);        // jhonny Smith
    set.Add(_user2);        // Tumi
    set.Add(_user3);        // Tumi
    set.Add(duplicateUser); // Duplicate of user1 in content, different object
    set.Add(duplicateUser5); // Duplicate of user1 in content, different object

    Console.WriteLine($"HashSet Count: {set.Count}");

 foreach (var user in set)
    {
      Console.WriteLine($"User: {user.UserId} {user.Name} {user.Surname}");
     }



  }
  



  }

public class User:IComparable<User>
{
  public int UserId { get; set; }
  public string Name { get; set; }
  public string Surname { get; set; }

  public int CompareTo(User other)
  {
    return Name.CompareTo(other.Name);
  }

  public override bool Equals(object obj)
  {
    if (obj is not User other) return false;
      return Name == other.Name && Surname == other.Surname;
    // return ReferenceEquals(this, obj);
  }
  // }

   public override int GetHashCode()
  {
    int hash = HashCode.Combine(Name, Surname);
    Console.WriteLine($"[GetHashCode] User({Name}, {Surname}) => HashCode: {hash}");
    return hash;
  }
  }




