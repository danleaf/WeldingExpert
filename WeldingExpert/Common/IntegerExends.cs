using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeldingExpert.Models;

namespace WeldingExpert.Common
{
    public static class IntegerExends
    {
        public static Enum<T> ToEnumClass<T>(this int val)
        {
            return new Enum<T>(val);
        }
    }
}