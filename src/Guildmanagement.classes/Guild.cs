﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;

namespace GuildManagement.Framework
{
    public class CustomGuildMembersConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Integer)
            {
                return null;
            }

            //JArray jArray = JArray.Load(reader);
            //List<GuildMember> charactersA = jArray.ToObject<List<GuildMember>>();
            //Character[] characters = JsonConvert.DeserializeObject<Character[]>(jArray.ToString());

            //List<GuildMember> characters = serializer.Deserialize<List<GuildMember>>(reader);
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }

    public class Guild
    {
        public Guild ConvertJSON(string json)
        {
            //var sett = new JsonSerializerSettings
            //{
                
            //}
            Guild guild = JsonConvert.DeserializeObject<Guild>(json);

            return guild;
        }

        public Guild()
        {
            Key = Guid.NewGuid();
        }

        [Key]
        public Guid Key { get; set; }

        public string Name { get; set; }
        public string Realm { get; set; }
        public string Battlegroup { get; set; }

        public string Website { get; set; }
        public Guid?  Owner { get; set; }

        [JsonConverter(typeof(CustomGuildMembersConverter))]
        public List<Character> Members { get; set; }
    }
}