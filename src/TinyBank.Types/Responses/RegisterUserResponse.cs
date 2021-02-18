using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TinyBank.Types.Responses
{
    [DataContract]
    public class RegisterUserResponse
    {
        [DataMember(Name = "isCreated")]
        [JsonPropertyName("isCreated")]
        public bool IsCreated { get; set; }
    }
}
