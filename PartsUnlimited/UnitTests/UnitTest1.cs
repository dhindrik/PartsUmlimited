using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartsUnlimited.ViewModels;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task CartTest()
        {
            var searchViewModel = new SearchViewModel();
            var cartViewModel = new CartViewModel();

            SearchViewModel.Buy.Execute(searchViewModel.Items[0]);
            SearchViewModel.Buy.Execute(searchViewModel.Items[1]);

            await cartViewModel.Update();

            var total = searchViewModel.Items[0].Price + searchViewModel.Items[1].Price;

            Assert.IsTrue(cartViewModel.Total == total);
        }
    }
}
