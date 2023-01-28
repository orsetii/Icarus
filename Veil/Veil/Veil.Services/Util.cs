using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veil.Services
{
    public static class Util
    {
        // TODO FIXME only works with 2 words lmao
        public static string Capitalize(this string word)
{
    return word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
}
    }
}
