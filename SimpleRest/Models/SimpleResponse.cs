using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRest {
    public class SimpleResponse<T> : ISimpleResponse<T> {
        public T DataConverted { get; set; }
        public object DataRaw { get; set; }
    }
}
