using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace GuildManagement.Framework
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Character
    {
        public Character ConvertJSON(string json)
        {
            Character character = JsonConvert.DeserializeObject<Character>(json);

            return character;
        }

        public Character()
        {
            Key = Guid.NewGuid();
        }

        [Key]
        public Guid Key { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("realm")]
        public string Realm { get; set; }
        [JsonProperty("battlegroup")]
        public string Battlegroup { get; set; }

        [JsonProperty("class")]
        private int ClassID { get; set; }
        [JsonIgnore]
        public GameClass Class
        {
            get
            {

                return (GameClass)ClassID;
            }
            set
            {
                ClassID = (int)value;
            }
        }

        [JsonProperty("race")]
        private int RaceID { get; set; }
        [JsonIgnore]
        public Race Race
        {
            get
            {
                return (Race)RaceID;
            }
            set
            {
                RaceID = (int)value;
            }
        }

        [JsonProperty("gender")]
        private int GenderID { get; set; }
        [JsonIgnore]
        public Gender Gender
        {
            get
            {
                return (Gender)GenderID;
            }
            set
            {
                GenderID = (int)value;
            }
        }
        public int Level { get; set; }
        public int Faction { get; set; }

        public Guild Guild { get; set; }
    }

    public enum GameClass
    {
        Warrior = 1,
        Rogue = 2,
        Paladin = 3
    }

    public enum Race
    {
        Dwarf = 1
    }

    public enum Gender
    {
        Male = 0,
        Female = 1
    }

    public class GuildMember
    {
        Character Character { get; set; }
        int Rank { get; set; }
    }
}
