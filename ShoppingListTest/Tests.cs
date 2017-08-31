using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace ShoppingListTest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void AddEmptyList()
        {
            app.WaitForElement(c => c.Marked("NoResourceEntry-0").Text("New Shopping"));
            app.Tap(c => c.Marked("NoResourceEntry-0"));
            app.EnterText(e => e.Class("EntryEditText"), "NewList");
            app.PressEnter();
            app.Tap(c => c.Marked("NoResourceEntry-0"));
            Assert.AreEqual(1, app.Query(q => q.Class("ListView").Child()).Length);
        }

        [Test]
        public void AddAndRemoveList()
        {
            app.WaitForElement(c => c.Marked("NoResourceEntry-0").Text("New Shopping"));
            app.Tap(c => c.Marked("NoResourceEntry-0"));
            app.EnterText(e => e.Class("EntryEditText"), "NewList");
            app.PressEnter();
            app.Tap(c => c.Marked("NoResourceEntry-0"));
            Assert.AreEqual(1, app.Query(q => q.Class("ListView").Child()).Length);
            app.Tap(c => c.Class("AppCompatButton"));
            Assert.AreEqual(0, app.Query(q => q.Class("ListView").Child()).Length);
        }

        [Test]
        public void AddListWithItems()
        {
            int itemsNum = 7;
            app.WaitForElement(c => c.Marked("NoResourceEntry-0").Text("New Shopping"));
            app.Tap(c => c.Marked("NoResourceEntry-0"));
            app.EnterText(e => e.Class("EntryEditText"), "NewList");
            app.PressEnter();

            for (int i = 0; i < itemsNum; i++)
            {
                app.EnterText(c => c.Class("EntryEditText").Index(1), "item"+i);
                app.PressEnter();
            }

            Assert.AreEqual(itemsNum, app.Query(q => q.Class("ListView").Child()).Length);
        }
    }
}

