using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TinyBank.Types.Responses
{
    [DataContract]
    public class RegisterUserResponse
    {
        [DataMember(Name = "isRegistered")]
        [JsonPropertyName("isRegistered")]
        public bool IsRegistered { get; set; }
    }
}
