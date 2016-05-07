using GuildManagement.Framework;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace GuildManagement.DataLayer
{
    public class BlizzardConnectionRepository : IBlizzardConnectionRepository
    {
        string _apiKey;
        string _blizzardURI;

        public BlizzardConnectionRepository(IConfiguration config)
        {
            _apiKey = config["BlizzardAPIKey"];
            _blizzardURI = "https://us.api.battle.net/wow/";
        }

        private string AppendAPIKey(string uri)
        {
            if (uri.Contains("?"))
            {
                uri += "&";
            }
            else
            {
                uri += "?";
            }

            return uri += "apikey=" + _apiKey;
        }

        private async Task<string> CallBlizzard(string uri)
        {
            uri = AppendAPIKey(uri);
            string response = await new HttpClient().GetStringAsync(uri);

            return response;
        }

        public Character GetCharacter(string name, string realm, bool getGuild = false)
        {
            string uri = _blizzardURI + "character/" + realm + "/" + name + "?locale=en_US";
            if (getGuild)
            {
                uri += "&fields=guild";
            }

            Task<string> call = CallBlizzard(uri);
            call.Wait();

            Character character = new Character();
            character = character.ConvertJSON(call.Result);

            return character;
        }

        public Guild GetGuild(string name, string realm, bool getMembers = false)
        {
            string uri = _blizzardURI + "guild/" + realm + "/" + name + "?locale=en_US";
            //https://us.api.battle.net/wow/guild/Caelestrasz/Windburst?locale=en_US&apikey=7jzkneux9z8ux4xvwzd3htuq29tfhcpb
            if (getMembers)
            {
                uri += "&fields=members";
            }

            Task<string> call = CallBlizzard(uri);
            call.Wait();

            Guild guild = new Guild();
            guild = guild.ConvertJSON(call.Result);

            return guild;
        }
    }
}
