using Newtonsoft.Json;

namespace Helping_Hands.Data.GRID
{
    public class ManagerGridDTO : GridDTO
    {
        [JsonIgnore]
        public const string DefaultFilter = "all";
        public string Status { get; set; } = DefaultFilter;
        //    public string Genre { get; set; } = DefaultFilter;
        //   public string rice { get; set; } = DefaultFilter;
    }
}
