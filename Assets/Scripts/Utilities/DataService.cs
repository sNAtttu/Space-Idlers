using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using System.Net;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Utilities
{
    public class DataService
    {

        private static readonly string HostUrl = "http://localhost:5000";

        public static Models.Player CreateUser(string username)
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string url = $"{HostUrl}/api/playerData";
            string response = webClient.UploadString(url, username);
            return JsonConvert.DeserializeObject<Models.Player>(response);
        }

        public static Models.Player GetUser(string username)
        {
            return null;
        }

        public static List<SpaceInvaderMatch> GetAllGamesForUser(string username)
        {
            throw new NotImplementedException("Teemu tekee tämän joskus. Tai Johannes");
        }

        public static SpaceInvaderMatch GetGameData(int id)
        {
            WebClient client = new WebClient();
            string jsonResponse = client.DownloadString($"https://idlepeli-wa.azurewebsites.net/api/SpaceInvaderDataGames/{id}");

            SpaceInvaderMatch data = JsonConvert.DeserializeObject<SpaceInvaderMatch>(jsonResponse);
            Debug.Log(data);
            return data;
        }

        public static void PostGameData(SpaceInvaderMatch gameData)
        {
            WebClient client = new WebClient();
            string serializedGameData = JsonConvert.SerializeObject(gameData);
            string response = client.UploadString("https://idlepeli-wa.azurewebsites.net/api/SpaceInvaderDataGames", serializedGameData);
            Debug.Log(response);
        }

        public static void SavePlayerDataLocally(PlayerLocalData data)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(data);
                File.WriteAllText($"{Path.Combine(Application.persistentDataPath, "playerData.json")}", jsonData);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

    }
}

