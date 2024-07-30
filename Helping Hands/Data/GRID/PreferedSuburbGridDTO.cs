using Newtonsoft.Json;

namespace Helping_Hands.Data.GRID
{
    public class PreferedSuburbGridDTO : GridDTO
    {
        [JsonIgnore]
        public const string DefaultFilter = "all";
        public string Location { get; set; } = DefaultFilter;

    }
}
