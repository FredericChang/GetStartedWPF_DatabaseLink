using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace GetStartedWPF_DatabaseLink
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product>
            Products
        { get; private set; } =
            new ObservableCollection<Product>();
        /// <summary>
        /// ObjectModel-->ObservableCollection-->代表在加入和移除項目時，或重新整理整份清單時提供通知的動態資料集合。
        /// </summary>

        //https://docs.microsoft.com/zh-tw/dotnet/api/system.collections.generic.icollection-1?view=net-5.0

    }
}
