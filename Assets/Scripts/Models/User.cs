using System;
using Newtonsoft.Json;

namespace Models
{
    [JsonObject]
    public class User
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
    }
}

