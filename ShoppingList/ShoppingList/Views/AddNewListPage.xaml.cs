using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingList.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddNewListPage : ContentPage
	{
		public AddNewListPage ()
		{
			InitializeComponent ();
            BindingContext = new ViewModels.AddNewListViewModel();
		}

        async void OnAddNewList(object sender, EventArgs e)
        {
            await Navigation.PopAsync(true);
        }
    }
}