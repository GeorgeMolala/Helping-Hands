using Newtonsoft.Json;

namespace Helping_Hands.Data.GRID
{
    public class ConditionsGridDTO : GridDTO
    {
        [JsonIgnore]
        public const string DefaultFilter = "all";
        public string NoFilter { get; set; } = DefaultFilter;
    }
}
