using System;
using System.Collections.Generic;
using System.Dynamic;

namespace TAC.Sitecore.Abstractions.Testing
{
    public class ExpandoTestItemBuilder
    {

        public dynamic Build() => Build(Guid.NewGuid().ToString());
        public dynamic Build(string name)
        {
            dynamic item = new ExpandoObject();
            item.Item = BuildTestItem(name);
            return item;
        }
              
        public dynamic Build(string name, params dynamic[] children)
        {
            IDictionary<string, Object> item = Build(name);
            TestItem testItem = (TestItem)item["Item"];
            foreach (dynamic child in children)
            {
                var removeNameSpaces = ((string)child.Item.Name).Replace(" ", "");
                item.Add(removeNameSpaces, child);
                testItem.AddChildren(child.Item);
            }
            return item;
        }

        private TestItem BuildTestItem(string name)
        {
            return new TestItem
            {
              Name = name,
              Url = name + "_url",
              DisplayName = name+"_displayName",                            
            };
        }
    }
}
