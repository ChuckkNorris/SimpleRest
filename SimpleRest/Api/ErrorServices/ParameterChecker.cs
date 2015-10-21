using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRest.Api.ErrorServices {
    internal class ParameterChecker {
        internal static Uri ConvertToUri(string stringToConvert) {
            return new Uri(stringToConvert);
        }
    }
}
