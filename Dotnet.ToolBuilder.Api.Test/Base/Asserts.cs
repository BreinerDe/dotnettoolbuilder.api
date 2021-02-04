using System;
using System.Linq.Expressions;
using Dotnet.ToolBuilder.Api.Test.Extensions;
using Extensions.Pack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dotnet.ToolBuilder.Api.Test.Base
{
    // XUnit does not have possibility to extend :-( => MsTestV2 have it with "Assert.That"
    public static class Asserts
    {
        public static void ObjectsAreEqual<T>(Expression<Func<T>> object1, Expression<Func<T>> object2) where T : class
        {
            var differences = new ObjectsComparer.Comparer<T>().CalculateDifferences(object1.Compile()(), object2.Compile()());

            Assert.IsTrue(differences.IsEmpty(), differences.ToResultTable(object1.NameOf(), object2.NameOf()));
        }

        public static void ObjectsAreEqual<T>(Expression<Func<string>> json, Expression<Func<T>> object2) where T : class
        {
            var object1 = System.Text.Json.JsonSerializer.Deserialize<T>(json.Compile()());
            var differences = new ObjectsComparer.Comparer<T>().CalculateDifferences(object1, object2.Compile()());

            Assert.IsTrue(differences.IsEmpty(), differences.ToResultTable(json.NameOf(), object2.NameOf()));
        }
    }
}
