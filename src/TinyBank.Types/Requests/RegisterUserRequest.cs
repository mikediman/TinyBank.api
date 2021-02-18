using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TinyBank.Types.Requests
{
    [DataContract]
    public class RegisterUserRequest : GenericRequest
    {
        [DataMember(Name = "isExcel")]
        [JsonPropertyName("isExcel")]
        public bool IsExcel { get; set; }

        [DataMember(Name = "vatNumber")]
        [JsonPropertyName("vatNumber")]
        public string VatNumber { get; set; }

        [DataMember(Name = "email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [DataMember(Name = "customerCategory")]
        [JsonPropertyName("customerCategory")]
        public int CustomerCategory { get; set; }
    }
}
