using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using System.Net;
using Newtonsoft.Json;
using System;

namespace Utilities
{
    public class DataService : MonoBehaviour
    {
        public static User GetUser(string username)
        {
            return null;
        }

        public static List<GameData> GetAllGamesForUser(string username)
        {
            throw new NotImplementedException("Teemu tekee tämän joskus. Tai Johannes");
        }

        public static GameData GetGameData(int id)
        {
            WebClient client = new WebClient();
            string jsonResponse = client.DownloadString($"https://idlepeli-wa.azurewebsites.net/api/SpaceInvaderDataGames/{id}");

            GameData data = JsonConvert.DeserializeObject<GameData>(jsonResponse);
            Debug.Log(data);
            return data;
        }

        public static void PostGameData(GameData gameData)
        {
            WebClient client = new WebClient();
            string serializedGameData = JsonConvert.SerializeObject(gameData);
            string response = client.UploadString("https://idlepeli-wa.azurewebsites.net/api/SpaceInvaderDataGames", serializedGameData);
            Debug.Log(response);
        }

    }
}

