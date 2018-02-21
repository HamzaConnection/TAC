using Sitecore.Configuration;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using TAC.Sitecore.Abstractions.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System;
using Sitecore.Data.Fields;
using Sitecore.Diagnostics;

namespace TAC.Sitecore.Abstractions.SitecoreImplementation
{
    public class SitecoreItem : IItem
    {
        private readonly Item _item;

        public SitecoreItem(Item item)
        {
            Assert.ArgumentNotNull(item, nameof(item));
            _item = item;
        }

        public SitecoreItem(string itemPathOrId, string databaseName)
            : this(Factory.GetDatabase(databaseName)?.GetItem(itemPathOrId))
        { }


        public string this[string fieldNameorID] { get => _item[fieldNameorID]; set => _item[fieldNameorID] = value; }

        public string DisplayName => _item.DisplayName;

        public string Name => _item.Name;

        public string Url => LinkManager.GetItemUrl(_item);

        public IItem Parent => new SitecoreItem(_item.Parent);

        public IEnumerable<IItem> GetChildren()
        {
            return _item.GetChildren().Select(i => new SitecoreItem(i));
        }

        public bool IsAncestorOrSelf(IItem item)
        {
            var sitecoreItem = item as SitecoreItem;
            return sitecoreItem != null && (_item.Axes.IsAncestorOf(sitecoreItem._item) || sitecoreItem._item.ID == _item.ID);
        }

        public string RenderField(string fieldNameOrID) => RenderField(fieldNameOrID, "");

        public string RenderField(string fieldNameOrID, string parameters)
        {
            return FieldRenderer.Render(_item, fieldNameOrID, parameters);
        }

        public IEnumerable<IItem> GetMultilistFieldItems(string fieldNameOrID)
        {
            MultilistField field = _item.Fields[fieldNameOrID];
            return field?.GetItems().Select(i => new SitecoreItem(i)) ?? Enumerable.Empty<IItem>();
        }

        IEnumerable<IItem> IItem.GetAncestors()
        {
            return _item.Axes.GetAncestors().Select(i => new SitecoreItem(i));
        }
    }
}
