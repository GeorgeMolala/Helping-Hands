using Newtonsoft.Json;

namespace Helping_Hands.Data.GRID
{
    public class CareVisitGridDTO : GridDTO
    {
        [JsonIgnore]
        public const string DefaultFilter = "all";

        public string Period { get; set; } = DefaultFilter;
        public string ContractDate { get; set; } = DefaultFilter;

       // public string Nurse { get; set; } = DefaultFilter;
        public string EndDate { get; set; } = DefaultFilter;
        public string VisitStatus { get; set; } = DefaultFilter;

    }
}
