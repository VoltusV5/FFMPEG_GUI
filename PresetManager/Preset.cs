namespace PresetManager
{
    public class Preset
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CommandTemplate { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Description}";
        }
    }
}
