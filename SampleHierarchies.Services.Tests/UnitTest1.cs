using NUnit.Framework;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SampleHierarchies.Services.Tests
{
    [TestFixture]
    public class ScreenDefinitionServiceTests
    {
        private IScreenDefinitionService _screenDefinitionService;

        [SetUp]
        public void Setup()
        {
            // Ініціалізація сервісу перед кожним тестом
            _screenDefinitionService = new ScreenDefinitionService();
        }

         [Test]
        public void Load_ValidJsonFile_ReturnsScreenDefinition()
        {
            // Підготовка тестових даних
            string jsonFileName = "valid_screen.json"; // Вкажіть шлях до вашого валідного JSON файлу
            
            // Створення екземпляра ScreenDefinitionService
            ScreenDefinitionService service = new ScreenDefinitionService();
            
            // Виклик методу Load
            ScreenDefinition result = service.Load(jsonFileName);
            
            // Перевірка результату
            Assert.IsNotNull(result);
            // Ви можете додатково перевірити вміст отриманого ScreenDefinition, якщо це потрібно.
        }

        [Test]
        public void Save_ValidScreenDefinition_ReturnsTrue()
        {
            // Очікуємо, що цей тест вдало збереже ScreenDefinition у JSON файлі

            // Створення тестового ScreenDefinition
            var screenDefinition = new ScreenDefinition
            {
                LineEntries = new List<ScreenLineEntry>
                {
                    new ScreenLineEntry
                    {
                        BackgroundColor = "White",
                        ForegroundColor = "Black",
                        Text = "Sample Text"
                    }
                }
            };

            // Вкажіть шлях до тестового JSON файлу для збереження
            string jsonFilePath = "test_screen_definition.json";

            // Збереження ScreenDefinition в файл
            var result = _screenDefinitionService.Save(screenDefinition, jsonFilePath);

            // Перевірка, що збереження було успішним
            Assert.IsTrue(result);

            // Перевірка, що файл існує
            Assert.IsTrue(File.Exists(jsonFilePath));

            // Інші перевірки, які можна додати
        }
    }
}
