using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TinyBank.Types.Requests
{
    [DataContract]
    public class RegisterUserRequest : GenericRequest
    {
        [DataMember(Name = "nino")]
        [JsonPropertyName("nino")]
        public string Nino { get; set; }

        [DataMember(Name = "email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [DataMember(Name = "customerCategory")]
        [JsonPropertyName("customerCategory")]
        public int CustomerCategory { get; set; }
    }
}
