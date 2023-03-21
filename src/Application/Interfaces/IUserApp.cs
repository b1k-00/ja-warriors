﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;
public interface IUserApp
{
    Task<bool> Validate(string username, string password);


    Task<List<User>> GetUserByDesignStudio(int designStudioId);


}
