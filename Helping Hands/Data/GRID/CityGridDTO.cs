using Newtonsoft.Json;

namespace Helping_Hands.Data.GRID
{
    public class CityGridDTO : GridDTO
    {
        [JsonIgnore]
        public const string DefaultFilter = "all";

        public string NoFilter { get; set; } = DefaultFilter;

    }
}
