using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierachies.Helpers
{
    public class HelpMethods
    {
        public static int animalIdCounter = 0;
        public static int GetNextAnimalId()
        {
            return animalIdCounter++;
        }
        public static void ChangeLanguage(IScreenDefinitionService screenService, string screenDefinitionJson)
        {
            // Оновіть мову на потрібну мову для всіх екранів
            var screenDefinition = screenService.Load(screenDefinitionJson);

            // Перевірте, чи поле ListEntries визначено для польської мови
            if (screenDefinition != null)
            {
                // Перевіряємо, чи поле ListEntries визначено для польської мови
                if (screenDefinition.ListEntries.ContainsKey("Polski"))
                {
                    // Оновлюємо поле для мови "Polski" на потрібний текст
                    screenDefinition.ListEntries["Polski"] = "Ваш новий текст для мови Polski";

                    // Зберігаємо змінену версію визначення екрану назад
                    screenService.Save(screenDefinition, screenDefinitionJson);

                    // Тут ви можете вивести повідомлення про успішну зміну мови
                    Console.WriteLine("Мова змінена успішно!");
                }
                else
                {
                    Console.WriteLine("Поле ListEntries для мови 'Polski' не було знайдено.");
                }
            }
            else
            {
                Console.WriteLine("Не вдалося завантажити визначення екрану. Перевірте, чи існує файл визначення екрану з вказаним шляхом.");
            }
        }
    }
}