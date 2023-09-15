using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SampleHierarchies.Data;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Services
{
    public class JsonSettingsService 
    {
        private readonly string _filePath;

        public JsonSettingsService(string filePath)
        {
            _filePath = filePath;
        }

        public ISettings LoadSettings()
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                JObject settingsJson = JObject.Parse(json);

                // Додайте код для завантаження мови з налаштувань
                string language = settingsJson.GetValue("Language")?.ToString();

                return new Settings
                {
                    MainScreenColor = settingsJson.GetValue("MainScreenColor")?.ToString(),
                    Language = language // Завантаження мови
                };
            }
            else
            {
                return new Settings();
            }
        }

        public void SaveSettings(ISettings settings)
        {
            // Додайте код для збереження мови в налаштуваннях
            JObject json = new JObject
            {
                ["MainScreenColor"] = settings.MainScreenColor,
                ["Language"] = settings.Language // Збереження мови
            };

            File.WriteAllText(_filePath, json.ToString());
        }
    }
}
