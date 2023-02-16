using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;
public interface IUserApp
{
    bool Validate(string username, string password);

    bool CreateUser(User user);

    bool DeleteUser(string username);
    List<User> GetUsers();

}
