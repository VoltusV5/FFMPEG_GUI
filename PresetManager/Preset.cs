namespace PresetManager
{
    public class Preset
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CommandTemplate { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Name}: {Description}";
        }
    }
}
