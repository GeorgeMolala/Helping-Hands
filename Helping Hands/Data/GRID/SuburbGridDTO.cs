using Newtonsoft.Json;

namespace Helping_Hands.Data.GRID
{
    public class SuburbGridDTO : GridDTO
    {
        [JsonIgnore]
        public const string DefaultFilter = "all";

        public string CityLoc { get; set; } = DefaultFilter;

    }
}
