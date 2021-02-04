using System;
using System.Linq.Expressions;
using System.Text.Json;
using Extensions.Pack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectsComparer;

namespace Dotnet.ToolBuilder.Api.Test.Extensions
{
    internal static class Asserts
    {
        private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public static void ObjectsAreEqual<T>(this Assert assert, Expression<Func<T>> object1, Expression<Func<T>> object2) where T : class
        {
            assert.ObjectsAreEqual(object1, object2, input => input);
        }

#pragma warning disable IDE0060 // This is allowed because we use the extension mechanism of MsTest V2.x
        internal static void ObjectsAreEqual<T>(this Assert assert, Expression<Func<T>> object1, Expression<Func<T>> object2, Func<T, T> orderFunc) where T : class
#pragma warning restore IDE0060 // This is allowed because we use the extension mechanism of MsTest V2.x
        {
            var obj1 = orderFunc(object1.Compile()());
            var obj2 = orderFunc(object2.Compile()());

            var differences = new Comparer<T>().CalculateDifferences(obj1, obj2);

            Assert.IsTrue(differences.IsEmpty(), differences.ToResultTable(object1.NameOf(), object2.NameOf()));
        }

#pragma warning disable IDE0060 // This is allowed because we use the extension mechanism of MsTest V2.x
        internal static void ObjectsAreEqual<T>(this Assert assert, Expression<Func<string>> json, Expression<Func<T>> object2) where T : class
#pragma warning restore IDE0060 // This is allowed because we use the extension mechanism of MsTest V2.x
        {
            var object1 = JsonSerializer.Deserialize<T>(json.Compile()(), JsonSerializerOptions);
            var differences = new Comparer<T>(new ComparisonSettings()).CalculateDifferences(object1!, object2.Compile()());

            Assert.IsTrue(differences.IsEmpty(), differences.ToResultTable(json.NameOf(), object2.NameOf()));
        }
    }
}