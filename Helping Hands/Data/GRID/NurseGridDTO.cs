using Newtonsoft.Json;

namespace Helping_Hands.Data
{
    public class NurseGridDTO : GridDTO
    {
        [JsonIgnore]
        public const string DefaultFilter = "all";
        public string Suburb { get; set; } = DefaultFilter;

        //    public string Genre { get; set; } = DefaultFilter;
        //   public string rice { get; set; } = DefaultFilter;

    }

}

