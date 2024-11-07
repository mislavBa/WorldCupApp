using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Match
{
    public class MatchDataFetcher
    {
        public static Task<RestResponse<Match>> GetMenMatches()
        {
            var client = new RestClient("https://worldcup-vua.nullbit.hr/men/matches");
            return client.ExecuteAsync<Match>(new RestRequest());
        }

        public static Task<RestResponse<Match>> GetWomenMatches()
        {
            var client = new RestClient("https://worldcup-vua.nullbit.hr/women/matches");
            return client.ExecuteAsync<Match>(new RestRequest());
        }

        public static Task<RestResponse<Match>> GetMenMatchesCountry(string code)
        {
            var client = new RestClient($"https://worldcup-vua.nullbit.hr/men/matches/country?fifa_code={code}");
            return client.ExecuteAsync<Match>(new RestRequest());
        }

        public static Task<RestResponse<Match>> GetWomenMatchesCountry(string code)
        {
            var client = new RestClient($"https://worldcup-vua.nullbit.hr/women/matches/country?fifa_code={code}");
            return client.ExecuteAsync<Match>(new RestRequest());
        }
    }
}
