﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShoppingList
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        async void AddNewList_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new NewItemPage());
        }
    }
}
