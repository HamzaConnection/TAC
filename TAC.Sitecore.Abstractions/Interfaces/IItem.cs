using System.Collections.Generic;

namespace TAC.Sitecore.Abstractions.Interfaces
{
    public interface IItem 
    {
        string DisplayName { get; }

        string Name { get; }

        string this[string fieldNameorID] { get; set; }

        string RenderField(string fieldNameOrID);

        string RenderField(string fieldNameOrID, string parameters);

        IItem Parent { get; }

        IEnumerable<IItem> GetAncestors();

        bool IsAncestorOrSelf(IItem item);

        string Url { get; }

        IEnumerable<IItem> GetChildren();

        IEnumerable<IItem> GetMultilistFieldItems(string fieldNameOrID);
    }
}
