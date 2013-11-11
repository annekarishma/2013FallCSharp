using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicContactsTests
{
    [TestClass]
    public class TodoVMTest
    {
        [TestMethod]
        public void AddTodoReallyAddsAnItem()
        {
            var vm = new BasicContacts.TodoVM();
            Assert.AreEqual(0, vm.List.Count);

            vm.Text = "Test";
            vm.AddCommand.Execute(null);

            Assert.AreEqual(1, vm.List.Count);
            Assert.AreEqual("Test", vm.List.First());
            Assert.IsNull(vm.Text);
        }
    }
}