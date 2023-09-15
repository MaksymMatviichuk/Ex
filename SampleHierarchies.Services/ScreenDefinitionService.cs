using Newtonsoft.Json;
using SampleHierarchies.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Services
{
    public class ScreenDefinitionService : IScreenDefinitionService
    {
        private List<ScreenDefinition> screenDefinitions;
        public ScreenDefinition Load(string jsonFileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(jsonFileName))
                {
                    string json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<ScreenDefinition>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка завантаження визначення екрану: {ex.Message}");
                return null;
            }
        }

        public bool Save(ScreenDefinition screenDefinition, string jsonFileName)
        {
            try
            {
                string json = JsonConvert.SerializeObject(screenDefinition, Formatting.Indented);
                File.WriteAllText(jsonFileName, json);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка збереження визначення екрану: {ex.Message}");
                return false;
            }
        }
    }
}