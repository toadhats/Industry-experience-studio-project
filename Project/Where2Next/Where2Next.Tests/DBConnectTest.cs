// <copyright file="DBConnectTest.cs">
//     Copyright © 2016
// </copyright>
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Where2Next;

namespace Where2Next.Tests
{
    /// <summary>
    /// This class contains parameterized unit tests for DBConnect
    /// </summary>
    [PexClass(typeof(DBConnect))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class DBConnectTest
    {
        /// <summary>
        /// Test stub for getHousePriceOfSuburb(String)
        /// </summary>
        [PexMethod]
        public SuburbPriceData getHousePriceOfSuburbTest([PexAssumeUnderTest]DBConnect target, string suburbName)
        {
            SuburbPriceData result = target.getHousePriceOfSuburb(suburbName);
            return result;
            // TODO: add assertions to method DBConnectTest.getHousePriceOfSuburbTest(DBConnect, String)
        }
    }
}
