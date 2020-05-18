﻿using System.Collections.Generic;

namespace OS.Common.Extensions
{
    public static class GenericExtensions
    {
        private static bool Equals<TIdType>(this TIdType a, TIdType b)
        {
            return EqualityComparer<TIdType>.Default.Equals(a, b);
        }
    }
}
