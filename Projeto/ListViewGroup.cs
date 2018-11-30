using System;
using System.Collections.Generic;
using static Projeto.MainPage;

namespace Projeto
{
    public class ListViewGroup: List<ListItem>
    {
        public string Key { get; set; }

        public ListViewGroup(String key, List<ListItem> listItems )
        {
            Key = key;

            foreach(var item in listItems)
            {
                this.Add(item);
            }

        }

    }


}
