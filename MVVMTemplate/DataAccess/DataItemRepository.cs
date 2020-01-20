using System.Collections.Generic;
using MVVMTemplate.Model;

namespace MVVMTemplate.DataAccess
{
    public class DataItemRepository
    {
        public List<DataItem> DataItems { get; private set; }

        public DataItemRepository()
        {
            DataItems = new List<DataItem>();
        }

        public void LoadData()
        {
            var dataItems = new List<DataItem>();
            dataItems.Add(new DataItem { UserId = 1, UserName = "test1" });
            dataItems.Add(new DataItem { UserId = 2, UserName = "test2" });
            dataItems.Add(new DataItem { UserId = 3, UserName = "test3" });
            dataItems.Add(new DataItem { UserId = 4, UserName = "test4" });

            DataItems = dataItems;
        }
    }
}
