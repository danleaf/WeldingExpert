using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeldingExpert.Models;

namespace WeldingExpert.Common
{
    public static class IntegerExends
    {
        public static WelderLevel ToWelderLevel(this int val)
        {
            return new WelderLevel(val);
        }

        public static UserRole ToUserRole(this int val)
        {
            return new UserRole(val);
        }
    }
}