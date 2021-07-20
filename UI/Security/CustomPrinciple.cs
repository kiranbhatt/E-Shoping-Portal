using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace UI.Security
{
    public class CustomPrinciple : IPrincipal
    {
        public CustomPrinciple(string Username)
        {
            GenericIdentity genericIdentity = new GenericIdentity(Username);
            Identity = genericIdentity;
        }


        public int UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string ContactNo { get; set; }
        public string[] Roles { get; set; }

        public IIdentity Identity { private set; get; }

        public bool IsInRole(string role)
        {
            if (Roles.Any(r => r.Contains(r)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}