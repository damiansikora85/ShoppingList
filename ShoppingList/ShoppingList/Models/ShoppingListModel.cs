using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

using Xamarin.Forms;
using ShoppingList.Services;
using System.Collections.ObjectModel;
using SQLite;

namespace ShoppingList.Models
{
    public class ShoppingListModel : Helpers.ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        //store items as '|' separated string
        private string itemsString;
        public string ItemsString
        {
            get { return itemsString; }
        
            set
            {
                itemsString = value;
                items = ConvertStringToList();
                itemsNum = items.Count;
            }
        }

        private ObservableCollection<string> items;
        private int itemsNum;

        [Ignore]
        public ObservableCollection<string> Items
        {
            get { return items; }
            set
            {
                items = value;
                itemsNum = value.Count;
                itemsString = ConvertListToString();
            }
        }

        [Ignore]
        public int ItemsNum
        {
            get { return itemsNum; }
            set
            {
                SetProperty(ref itemsNum, value);
            }
        }
        [Ignore]
        public int ItemsBought { get { return 0; } }
        [Ignore]
        public ICommand RemoveListCommand { get; set; }

        public ShoppingListModel()
        {
            Setup();
        }

        public ShoppingListModel(string name)
        {
            Name = name;
            Setup();
        }

        private void Setup()
        {
            Items = new ObservableCollection<string>();
            RemoveListCommand = new Command(() =>
                ShoppingListManager.Instance.Database.DeleteItemAsync(this)
            );
        }

        private string ConvertListToString()
        {
            string listString = "";
            foreach (string item in items)
            {
                listString += item;
                listString += '|';
            }

            return listString;
        }

        private ObservableCollection<string> ConvertStringToList()
        {
            ObservableCollection<string> localItems = new ObservableCollection<string>();
            string[] itemsStringSplit = itemsString.Split('|');
            foreach(string item in itemsStringSplit)
            {
                if(string.IsNullOrEmpty(item) == false)
                    localItems.Add(item);
            }

            return localItems;
        }
    }
}
