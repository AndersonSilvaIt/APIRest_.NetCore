using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace DevIO.Business.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        Guid GetUserId();
        string GetUserEmail();
        bool IsAuthenticated();
        bool IsInRole();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
