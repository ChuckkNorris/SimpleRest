using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRest {
    public interface ISimpleResponse<T> {
        T DataConverted { get; set; }
        object DataRaw { get; set; }
    }
}
