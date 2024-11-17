namespace GenshinAPI.DTOS
{
    public class CharacterDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Element { get; set; }
        public string Weapon { get; set; }
        public int Rarity { get; set; }
        public string Desc { get; set; }

        public CharacterDTO(string name, string element, string desc)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Element = element ?? throw new ArgumentNullException(nameof(element));
            Desc = desc ?? throw new ArgumentNullException(nameof(desc));
        }
    }
}