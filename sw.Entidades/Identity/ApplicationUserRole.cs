using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace sw.Entidades.Identity
{
    public class ApplicationUserRole: IdentityUserRole<string>
    {
        public ApplicationUserRole() : base()
        { }
    }
}
