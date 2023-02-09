using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Application;
using Application.DTOs.DadJoke;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace API.Controllers;
public class UsersController : BaseApiController //inhertited the BAC for UC
//a.m    type       

{
    string str = "Class Level";
    //type  name    
    //List<User> users = new List<User>();
    //this would be used to create our list of users
    //if we wanted to call look @ method in HTTPGET below
    public UsersController()
    {
        //rem discussion we can declare our own types
        //which is why below
        //User(type) user1(variable) = new User()(object)
        //User user1 = new User();
        //var users = UserApp.GetUsers();
        //user1.Email = "brennencolins@mv.com";
        //user1.Password = "Kob324";
        //users.Add(user1);

        //User user2 = new User();
        //user2.Email = "test";
        //user2.Password = "test";
        //users.Add(user2);
    }




    [HttpPost("Validate")]

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public bool ValidateUser(string username, string password)
    //aM   TYPE  method        parameter1             parameter 2
    {
        var result = false;
        //NAME REsult false?

        //find user with same name from list

        //  List < User > = users;

        var users = UserApp.GetUsers();
        //declare type after my method from 


        var foundUser = users.Find(y => y.Email == username);
        //      declare  type         method


        if (foundUser == null)
        {
            return false;
        }
        else
        {

            return foundUser.Password == password;



        }
        //if user exist test password if the
        //swagger pw && model pw match then true

        //else false

        //https://stackoverflow.com/questions/4495698/c-sharp-using-listt-find-with-custom-objects





        return result;
    }




    [HttpGet("AllUsers")]

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<User>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public List<User> AllUsers()
    //access mod   type     method
    {
        var users = UserApp.GetUsers();
        //valling my mget users method from my user app file 
        return users;
        //simple return what i declared the method 

    }

    [HttpPost("CreateUser")]

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public bool CreateUser(User user)
    //a.m    type     method    parameters
    {
        var users = UserApp.GetUsers();
        //dec  type     method
        //we made a class in the application folder
        //with a method called getusers()

        if (user == null)
            return false;
        else
            users.Add(user);
        return true;

    }
    [HttpPost("Delete")]

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public bool DeleteUser( string username  ) 
    {
        var users = UserApp.GetUsers();

        var delUser = users.Find(y => y.Email == username);

        if (delUser == null)
            return false;
        else    
            users.Remove(delUser);
        return true;    



        //if(users.Remove(user));
        //return false;
        //else
        //    return true;


        //var user = users.Find(y => y.Email == "brennenc" );

        //if (username == null)
        //    return false;
        //else
        //    username.Remove(user);
        //return true;

    }
}
