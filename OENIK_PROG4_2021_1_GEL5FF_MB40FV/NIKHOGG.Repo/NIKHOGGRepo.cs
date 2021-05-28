// <copyright file="NIKHOGGRepo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NIKHOGG.Repo
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using System.Windows;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using NIKHOGG.Elements;

    /// <summary>
    /// Implementation of the repository.
    /// </summary>
    public class NIKHOGGRepo : IStorageRepo
    {
        private string SAVE_PREFIX = "save_";

        /// <summary>
        /// Initializes a new instance of the <see cref="NIKHOGGRepo"/> class.
        /// </summary>
        public NIKHOGGRepo()
        {
            if (!Directory.Exists(@$"NIKHOGG"))
            {
                Directory.CreateDirectory(@$"NIKHOGG");
            }

            if (!Directory.Exists(@$"NIKHOGG\saves"))
            {
                Directory.CreateDirectory(@$"NIKHOGG\saves");
            }
        }

        /// <summary>
        /// Get saved games.
        /// </summary>
        /// <returns>List of saved games number.</returns>
        public List<int> GetSavedGames()
        {
            List<int> saveIds = new List<int>();
            string[] fileNames = Directory.GetFiles(@"NIKHOGG\saves");
            foreach (string name in fileNames)
            {
                // Example: save_22.txt 7(indexOf('.')) - 5(SAVE_PREFIX.Length) = 2
                if (name.StartsWith("save_"))
                {
                    saveIds.Add(int.Parse(name.Substring(5, name.IndexOf('.') - this.SAVE_PREFIX.Length)));
                }
            }

            return saveIds;
        }

        /// <summary>
        ///  Get top list.
        /// </summary>
        /// <returns>Top list item.</returns>
        public List<TopListItem> GetTopList()
        {
            List<TopListItem> result = new List<TopListItem>();

            try
            {
                StreamReader reader = new StreamReader(@$"NIKHOGG\top_list.json");
                JArray topList = JsonConvert.DeserializeObject<JArray>(reader.ReadToEnd());
                foreach (JObject item in topList)
                {
                    result.Add(new TopListItem((string)item.GetValue("name"), (double)item.GetValue("time")));
                }
            }
            catch (FileNotFoundException)
            {
                // Ignore
            }

            return result;
        }

        /// <summary>
        /// Load game method.
        /// </summary>
        /// <param name="id">The level number.</param>
        /// <returns>Saved game info.</returns>
        public SavedGameInfo LoadGame(int id)
        {
            SavedGameInfo savedGameInfo;
            try
            {
                savedGameInfo = new SavedGameInfo();
                StreamReader reader = new StreamReader(@$"NIKHOGG\saves\save_{id}.json");
                string json = reader.ReadToEnd();
                JObject datas = JsonConvert.DeserializeObject<JObject>(json);

                savedGameInfo.CurrentLevel = (int)datas.GetValue("current_lvl");
                savedGameInfo.ActualPlayer = (int)datas.GetValue("actual_player");
                savedGameInfo.CameraPosition = (double)datas.GetValue("camera_position");
                savedGameInfo.P1Weapon = (string)datas.GetValue("p1_weapon");
                savedGameInfo.P2Weapon = (string)datas.GetValue("p2_weapon");
                savedGameInfo.P1Position = new Point((int)datas.GetValue("p1_x"), (int)datas.GetValue("p1_y"));
                savedGameInfo.P2Position = new Point((int)datas.GetValue("p2_x"), (int)datas.GetValue("p2_y"));
                savedGameInfo.TimeInTenthsOfSec = (int)datas.GetValue("time");
            }
            catch (FileNotFoundException)
            {
                savedGameInfo = null;
            }

            return savedGameInfo;
        }

        /// <summary>
        /// Load level.
        /// </summary>
        /// <param name="stream">Stream.</param>
        /// <returns>Mappart items.</returns>
        public Level LoadLevel(Stream stream)
        {
            Level lvl = new Level();
            StreamReader reader = new StreamReader(stream);
            string json = reader.ReadToEnd();
            JArray array = JsonConvert.DeserializeObject<JArray>(json);
            foreach (JObject item in array)
            {
                string type = (string)item.GetValue("type");
                double y = (double)item.GetValue("y");
                double height = (double)item.GetValue("height");
                double x = (double)item.GetValue("x");
                double width = (double)item.GetValue("width");

                switch (type)
                {
                    case "floor": lvl.Map.Add(new Floor(y, height, x, width)); break;
                    case "ceiling": lvl.Map.Add(new Ceiling(y, height, x, width)); break;
                    case "neptun_lake": lvl.DeadlyMapParts.Add(new NeptunLake(y, height, x, width)); break;
                    case "finish": lvl.Finish = new Finish(y, height, x, width); break;
                }
            }

            return lvl;
        }

        /// <summary>
        /// Save game infos.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="savedGameInfo">The saved game infos.</param>
        public void SaveGame(int id, SavedGameInfo savedGameInfo)
        {
            JObject game = new JObject();
            game.Add(new JProperty("current_lvl", savedGameInfo.CurrentLevel));
            game.Add(new JProperty("actual_player", savedGameInfo.ActualPlayer));
            game.Add(new JProperty("camera_position", savedGameInfo.CameraPosition));
            game.Add(new JProperty("p1_weapon", savedGameInfo.P1Weapon));
            game.Add(new JProperty("p1_x", savedGameInfo.P1Position.X));
            game.Add(new JProperty("p1_y", savedGameInfo.P1Position.Y));
            game.Add(new JProperty("p2_weapon", savedGameInfo.P2Weapon));
            game.Add(new JProperty("p2_x", savedGameInfo.P2Position.X));
            game.Add(new JProperty("p2_y", savedGameInfo.P2Position.Y));
            game.Add(new JProperty("time", savedGameInfo.TimeInTenthsOfSec));

            string json = JsonConvert.SerializeObject(game);

            File.WriteAllText(@$"NIKHOGG\saves\save_{id}.json", json);
        }

        /// <summary>
        /// Top list method.
        /// </summary>
        /// <param name="toplist">Toplist.</param>
        public void ToTopList(List<TopListItem> toplist)
        {
            JArray topList = new JArray();
            foreach (TopListItem item in toplist.OrderBy(x => x.TimeInSeconds))
            {
                JObject entry = new JObject();
                entry.Add(new JProperty("name", item.Name));
                entry.Add(new JProperty("time", item.TimeInSeconds));
                topList.Add(entry);
            }

            string json = JsonConvert.SerializeObject(topList);
            File.WriteAllText(@$"NIKHOGG\top_list.json", json);
        }
    }
}
