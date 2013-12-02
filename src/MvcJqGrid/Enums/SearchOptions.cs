using System;

namespace MvcJqGrid.Enums
{
    [Flags]
    public enum SearchOptions
    {
        None = 0,
        Equal = 1,
        NotEqual = 2,
        Less = 4, 
        LessOrEqual = 8,
        Greater = 16,
        GreaterOrEqual = 32,
        BeginsWith = 64,
        DoesNotBeginWith = 128,
        IsIn = 256,
        IsNotIn = 1024,
        EndsWith = 2048,
        DoesNotEndWith = 4096,
        Contains = 8192,
        DoesNotContain = 16384
    }
}
