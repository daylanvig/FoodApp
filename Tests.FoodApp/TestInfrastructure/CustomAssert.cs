using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Sdk;

namespace Tests.FoodApp.TestInfrastructure
{
    public static class CustomAssert
    {
        public static void Single<T>(IEnumerable<T> items, string message)
        {
            try
            {
                Assert.Single(items);
            }
            catch (Exception e)
            {
                if (e is SingleException)
                {
                    throw new ExtendedAssertionException(message, e);
                }
                else
                {
                    throw;
                }
            }
        }
    }


    public class ExtendedAssertionException : Exception
    {
        public ExtendedAssertionException(string message, Exception e) : base($"{message} - {e.Message}")
        {
            
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
