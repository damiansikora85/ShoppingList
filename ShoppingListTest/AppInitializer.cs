using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace ShoppingListTest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.ApkFile("ShoppingList.Android.apk").StartApp();
                //return ConfigureApp.Android.StartApp();
            }

            return ConfigureApp
                .iOS
                .StartApp();
        }
    }
}

