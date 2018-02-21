using System;
using System.Collections.Generic;
using System.Linq;
using TAC.Sitecore.Abstractions.Interfaces;

namespace TAC.Sitecore.Abstractions.Testing
{
    public class TestItem : IItem
    {
        

        private readonly Dictionary<string, object> _fieldValues;
        public bool AutoGenerateFieldValues { get; set; }

        public TestItem()
        {
            AutoGenerateFieldValues = true;
            _fieldValues = new Dictionary<string, object>();
        }

        public string ParameterSeparator { get; set; } = "!";

        public string DisplayName { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public IItem Parent { get; set; }


        public IEnumerable<IItem> GetAncestors()
        {
            if (Parent == null) return Enumerable.Empty<IItem>();

            var ancestors = new List<IItem>();

            for (IItem i = Parent; i.Parent != null; i = i.Parent)
            {
                ancestors.Add(i);
            }
            ancestors.Reverse();
            return ancestors;
        }

        private readonly List<TestItem> _children = new List<TestItem>();

        public void AddChildren(TestItem child)
        {
            child.Parent = this;
            _children.Add(child);
        }
        public void AddChildren(IEnumerable<TestItem> children)
        {
            foreach (var child in children)
            {
                AddChildren(child);
            }
        }

        public IEnumerable<IItem> GetChildren()
        {
            return _children;
        }

        public bool IsAncestorOrSelf(IItem item)
        {
            return item != null && (item.Equals(this) || item.GetAncestors().Contains(this));
        }

        public void SetField(string fieldNameOrID, object value)
        {
            _fieldValues[fieldNameOrID.ToLower()] = value;
        }

        public string this[string fieldNameorID] { get => RenderField(fieldNameorID) ?? string.Empty; set => SetField(fieldNameorID, value); }

        public string RenderField(string fieldNameOrID) => RenderField(fieldNameOrID, "");

        public string RenderField(string fieldNameOrID, string parameters)
        {
            var key = fieldNameOrID.ToLower();

            if (!_fieldValues.ContainsKey(key))  
            {
                if (AutoGenerateFieldValues)
                {
                    SetField(key, Guid.NewGuid().ToString());
                }
                else
                {
                    return null;
                }
            }

            return string.IsNullOrEmpty(parameters) ?
                    $"{_fieldValues[key]}" :
                    $"{_fieldValues[key]}{ParameterSeparator}{parameters}";
        }

        public IEnumerable<IItem> GetMultilistFieldItems(string fieldNameOrID)
        {
            var key = fieldNameOrID.ToLower();

            return (_fieldValues.ContainsKey(key) ? (_fieldValues[key] as IEnumerable<IItem>) : null) ?? Enumerable.Empty<IItem>();                             
        }

        public string GetFieldName(string value)
        {            
            return _fieldValues.Keys
                .FirstOrDefault(k => _fieldValues[k].Equals(value) || value.StartsWith(_fieldValues[k] + ParameterSeparator))
                    ?? $"value: {value} not found"
                .ToString();
        }
    }
}