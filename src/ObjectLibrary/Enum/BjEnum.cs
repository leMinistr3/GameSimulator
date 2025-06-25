using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary.Enum
{
    public enum BjSplit
    {
        No = 'N',
        Split = 'S',
        SplitIfDouble = 'D'
    }

    public enum BjAction
    {
        Hit,
        Stand,
        Double,
        Split
    }
}
