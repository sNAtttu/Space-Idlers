using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    [JsonObject]
    public class PlayerLocalData
    {
        public Guid id;
        public string username;
    }
}

