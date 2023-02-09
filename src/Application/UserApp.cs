using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Application;
public class UserApp
//a.m    type    name
{
    static List<User> users = new List<User>();
    //a.m   type        name      
    

    //understand why we used static instead

    public static List<User> GetUsers() { return users; }
    //access mod    type        method       parameters
}
