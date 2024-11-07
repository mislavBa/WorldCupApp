using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Team
{
    public class TeamDataFetcher
    {
        public static Task<RestResponse<Team>> GetMenTeams()
        {
            var client = new RestClient("https://worldcup-vua.nullbit.hr/men/teams");
            return client.ExecuteAsync<Team>(new RestRequest());
        }

        public static Task<RestResponse<Team>> GetWomenTeams()
        {
            var client = new RestClient("https://worldcup-vua.nullbit.hr/women/teams");
            return client.ExecuteAsync<Team>(new RestRequest());
        }

        public static Task<RestResponse<Result>> GetMenTeamResults()
        {
            var client = new RestClient("https://worldcup-vua.nullbit.hr/men/teams/results");
            return client.ExecuteAsync<Result>(new RestRequest());
        }

        public static Task<RestResponse<Result>> GetWomenTeamResults()
        {
            var client = new RestClient("https://worldcup-vua.nullbit.hr/women/teams/results");
            return client.ExecuteAsync<Result>(new RestRequest());
        }
    }
}
