using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Data
{
    public class Screen
    {
        private readonly IScreenDefinitionService _screenDefinitionService;

        public Screen(IScreenDefinitionService screenDefinitionService, string screenDefinitionJson)
        {
            _screenDefinitionService = screenDefinitionService ?? throw new ArgumentNullException(nameof(screenDefinitionService));
            ScreenDefinitionJson = screenDefinitionJson;
        }

        public string ScreenDefinitionJson { get; private set; }

        public void Display()
        {
            ScreenDefinition screenDefinition = _screenDefinitionService.Load(ScreenDefinitionJson);

            if (screenDefinition != null)
            {
                foreach (var entry in screenDefinition.LineEntries)
                {
                    ConsoleColor foregroundColor;
                    if (Enum.TryParse(entry.ForegroundColor, true, out foregroundColor))
                    {
                        Console.ForegroundColor = foregroundColor;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid foreground color: {entry.ForegroundColor}");
                    }

                    ConsoleColor backgroundColor;
                    if (Enum.TryParse(entry.BackgroundColor, true, out backgroundColor))
                    {
                        Console.BackgroundColor = backgroundColor;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid background color: {entry.BackgroundColor}");
                    }

                    Console.WriteLine(entry.Text);

                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("Failed to load screen definition.");
            }
        }
    }
}
