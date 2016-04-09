using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace GuildManagement.Framework
{
    public class Character
    {
        public Character ConvertJSON(string json)
        {
            Character character = JsonConvert.DeserializeObject<Character>(json);

            return character;
        }

        public Character()
        {
            Key = Guid.NewGuid().ToString();
        }

        public string Key { get; set; }

        public string Name { get; set; }
        public string Realm { get; set; }
        public string Battlegroup { get; set; }

        [JsonProperty("class")]
        private int ClassID { get; set; }
        [JsonProperty(Required = Required.Default)]
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
        [JsonProperty(Required = Required.Default)]
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
        [JsonProperty(Required = Required.Default)]
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
}
