﻿using OS.Common.Exceptions;

using System;

namespace OS.Common.Extensions
{
    public static class StringExtentions
    {
        public static bool IsNullOrWhiteSpace(this string StringExtended, bool ThrowException = false)
        => !ThrowException ? String.IsNullOrWhiteSpace(StringExtended) : StringExtended.IsNullOrWhiteSpace("IsNullOrWhiteSpace(bool) @ StringExtentions");

        public static bool IsNullOrWhiteSpace(this string StringExtended, string ExceptionMessage)
            => !String.IsNullOrWhiteSpace(StringExtended) ? false : throw new IsNullOrWhiteSpaceException(ExceptionMessage);

        public static string Base64Encode(this string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(this string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
