using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVP
{
    public class Rootobject
    {
        public Player[] Property1 { get; set; }
    }

    public class Player
    {
        //This is a list of the properties for the player object
        //Using Json attributes to allow for proper coding conventions
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "team")]
        public string Team { get; set; }

        [JsonProperty(PropertyName = "points")]
        public double PointsPerGame { get; set; }

        [JsonProperty(PropertyName = "rebounds")]
        public double ReboundsPerGame { get; set; }

        [JsonProperty(PropertyName = "assists")]
        public double AssistsPerGame { get; set; }

        [JsonProperty(PropertyName = "steals")]
        public double StealsPerGame { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }
    }
}