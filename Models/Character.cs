namespace GenshinAPI.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Element { get; set; }
        public string Weapon { get; set; }
        public int Rarity { get; set; }
        public string Desc { get; set; }
        public DateTime Launch { get; set; }
        public float BaseHP { get; set; }
        public float BaseATK { get; set; }
        public float BaseDEF { get; set; }

    }
}