using CleaningProductExercise.Models;
using CleaningProductExercise.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CleaningProductExercise.Tests
{
    [TestClass]
    public class ProductValidatorTests
    {
        private IProductValidator _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _sut = new ProductValidator();
        }

        [TestMethod]
        public void WhenProductListsContainsAllValidProducts_ThoseProductsAreValid()
        {
            var productList = new List<Product>
            {
                GetProduct("123"),
                GetProduct("456"),
                GetProduct("789"),
                GetProduct("xxx"),
                GetProduct("yyy"),
                GetProduct("zzz"),
            };

            var invalidProducts = _sut.GetInvalidRegistrations(productList);

            Assert.AreEqual(0, invalidProducts.Count);
        }

        [TestMethod]
        public void WhenProductListsContainsDuplicateProducts_ThoseProductsAreInvalid()
        {
            var productList = new List<Product>
            {
                GetProduct("123"),
                GetProduct("456"),
                GetProduct("789"),
                GetProduct("123"),
                GetProduct("xxx"),
                GetProduct("yyy"),
                GetProduct("123"),
            };

            var invalidProducts = _sut.GetInvalidRegistrations(productList);

            Assert.AreEqual(3, invalidProducts.Count);
            Assert.IsTrue(invalidProducts.All(p => p.RegistrationId == "123"));
        }

        [TestMethod]
        public void WhenProductListsContainsProductsWithBlankRegistrations_ThoseProductsAreInvalid()
        {
            var productList = new List<Product>
            {
                GetProduct("123"),
                GetProduct("456"),
                GetProduct("789"),
                GetProduct("   "),
                GetProduct(""),
                GetProduct(null),
                GetProduct("  \n "),
                GetProduct("xxx"),
            };

            var invalidProducts = _sut.GetInvalidRegistrations(productList);

            Assert.AreEqual(4, invalidProducts.Count);
            Assert.IsNotNull(invalidProducts.Single(p => p.RegistrationId == "   "));
            Assert.IsNotNull(invalidProducts.Single(p => p.RegistrationId == ""));
            Assert.IsNotNull(invalidProducts.Single(p => p.RegistrationId == null));
            Assert.IsNotNull(invalidProducts.Single(p => p.RegistrationId == "  \n "));
        }

        [TestMethod]
        public void WhenProductListsContainsProductsWithInvalidContactTimes_ThoseProductsAreInvalid()
        {
            Assert.IsTrue(_sut.IsValid(GetProduct("123", "10")));
            Assert.IsTrue(_sut.IsValid(GetProduct("456", "20")));
            Assert.IsTrue(_sut.IsValid(GetProduct("789", "30")));
            Assert.IsFalse(_sut.IsValid(GetProduct("xxx", "")));
            Assert.IsFalse(_sut.IsValid(GetProduct("yyy", null)));
            Assert.IsFalse(_sut.IsValid(GetProduct("zzz", "10 seconds")));
            Assert.IsTrue(_sut.IsValid(GetProduct("qwerty", "55.5")));
        }

        private Product GetProduct(string registrationId)
        {
            return new Product
            {
                ActiveIngredients = new List<string>(),
                ContactTime = string.Empty,
                ProductName = string.Empty,
                RegistrationId = registrationId,
                VirusesKilled = new List<string>(),
            };
        }

        private Product GetProduct(string registrationId, string contactTime)
        {
            return new Product
            {
                ActiveIngredients = new List<string>(),
                ContactTime = contactTime,
                ProductName = string.Empty,
                RegistrationId = registrationId,
                VirusesKilled = new List<string>(),
            };
        }

    }
}
