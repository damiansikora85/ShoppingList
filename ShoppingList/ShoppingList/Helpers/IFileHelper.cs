using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Helpers
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
