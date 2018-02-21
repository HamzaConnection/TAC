namespace TAC.Sitecore.Abstractions.Interfaces
{
    public interface IRenderingContext
    {
        IItem HomeItem { get; }
        IItem  DatasourceOrContextItem { get; }
        IItem ContextItem { get; }
        string Parameter(string key);
        bool IsExperienceEditorEditing { get; }
    }
}
