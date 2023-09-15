namespace SampleHierarchies.Interfaces.Services
{
    public class ScreenDefinition
    {
        public List<ScreenLineEntry> LineEntries { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> ListEntries { get; set; } 

        public string GetListEntry(string language)
        {
            if (ListEntries != null && ListEntries.ContainsKey(language))
            {
                return ListEntries[language];
            }
            return Name; 
        }
    }
}