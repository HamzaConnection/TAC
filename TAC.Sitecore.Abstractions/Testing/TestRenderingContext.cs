using System;
using TAC.Sitecore.Abstractions.Interfaces;

namespace TAC.Sitecore.Abstractions.Testing
{
    public class TestRenderingContext : IRenderingContext
    {
        public IItem HomeItem { get; set; }

        public IItem DatasourceOrContextItem { get; set; }

        public IItem ContextItem { get; set; }

        public bool IsExperienceEditorEditing { get; set; }

        public string Parameter(string key)
        {
            throw new NotImplementedException();
        }
    }
}
