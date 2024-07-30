using Newtonsoft.Json;

namespace Helping_Hands.Data
{
    public class CareContractGridDTO : GridDTO
    {
        [JsonIgnore]
        public const string DefaultFilter = "all";
        public const string DefaultPeriod = "New";
        public string Nurse { get; set; } = DefaultFilter;

        public string Period { get; set; } = DefaultPeriod;

        public string ContractType { get; set; } = DefaultFilter;
        public string Patient { get; set; } = DefaultFilter;
        public string DateTime { get; set; } = DefaultFilter;
        //   public string rice { get; set; } = DefaultFilter;
    }
}
