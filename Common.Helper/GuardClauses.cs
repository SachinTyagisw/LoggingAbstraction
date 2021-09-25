using System;

namespace Common.Helper
{
    public static class GuardClauses
    {
        public static void IsNotNull(object argumentValue, string argumentName)
        {
            if (argumentValue == null)
                throw new ArgumentNullException(argumentName);
        }
    }
}
