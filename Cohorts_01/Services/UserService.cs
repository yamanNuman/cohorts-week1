using System.Net;
using Cohorts_01.Models;

namespace Cohorts_01.Services;

public class UserService
{
    public static List<User> users = new List<User>();

    static UserService()
    {

        User user1 = new User();
        user1.Age = 40;
        user1.ID = 1;
        user1.Name = "Steven";
        user1.LastName = "Gerrard";
        users.Add(user1);

        User user2 = new User();
        user2.Age = 42;
        user2.ID = 2;
        user2.Name = "Fernando";
        user2.LastName = "Torres";
        users.Add(user2);
    }

    public User findById(int id)
    {
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].ID == id)
            {
                return users[i];
            }
        }

        return null;
    }

    public void createUser(User user)
    {
        users.Add(user);
    }

    public bool updateUser(int id,User user)
    {
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].ID == id)
            {
                users[i].ID = user.ID;
                users[i].Name = user.Name;
                users[i].LastName = user.LastName;
                users[i].Age = user.Age;
                return true;
            }
        }

        return false;
    }

    public void deleteUser(int id)
    {
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].ID == id)
            {
                users.RemoveAt(i);
            }
        }
    }

    public bool patchName(int id,User user)
    {
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].ID == id)
            {
                users[i].Name = user.Name;
                return true;
            }
        }

        return false;
    }

}