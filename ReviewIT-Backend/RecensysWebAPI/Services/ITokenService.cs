using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecensysWebAPI.Services
{
    interface ITokenService
    {
        string GetToken(int uid);
        int ValidateToken(string token);
    }
}
