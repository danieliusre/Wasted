using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Serilog;

namespace Wasted.Data
{
    public class TipsService
    {
        private readonly JsonFileService _jsonFileService;

        public TipsService(JsonFileService jsonFileService)
        {
            _jsonFileService = jsonFileService;
        }

        public List<TipsModel> GetTips()
        {
            var tips =  new List<TipsModel>();
            var filepath =  "TipsList.json";
            try 
            {
                Log.Information("Started reading RecipeProductList");
                tips = JsonConvert.DeserializeObject<List<TipsModel>>(_jsonFileService.ReadJsonFromFile(filepath));
                Log.Information("Finished reading RecipeProductList");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return tips;
        }

        //Funkcija kai paspausta submit
        /*public void AddUserData(string NameTextField, string TipTextField, string LinkTextField, int NumberTextField, List<TipsModel> allTips)
        {
            try
            {
                Log.Information("Starting to Registration service");
                if ( string.IsNullOrEmpty(NameTextField) || string.IsNullOrEmpty(TipTextField) || string.IsNullOrEmpty(LinkTextField) || NumberTextField != 0)
                {
                        allTips.Add(new TipsModel(){TipNumber = NumberTextField, TipName = NameTextField, Name = TipTextField, TipLikes = 0, TipDislikes = 0, Link = LinkTextField});
                        //funkcija rašanti į json failą
                }
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}", e);
            }
        }*/

        /*public void ReadTips(List<TipsModel> allTips)
        {
        System.IO.StreamReader TipsFile = new System.IO.StreamReader(@"Tips.txt");
        allTips.Clear();
            do
            {
                int numberOfTheTip = Int32.Parse(TipsFile.ReadLine());
                string nameOfTheTip = TipsFile.ReadLine();
                string tipName = TipsFile.ReadLine();
                int like = Int32.Parse(TipsFile.ReadLine());
                int dislike = Int32.Parse(TipsFile.ReadLine());
                string link = TipsFile.ReadLine();
                allTips.Add(new TipsModel(){TipNumber = numberOfTheTip, TipName = nameOfTheTip, Name = tipName, TipLikes = like, TipDislikes = dislike, Link = link});
            }while(TipsFile.ReadLine() != null);
        }*/

         public int AddTip(string NameTextField, string TipTextField, string LinkTextField, string NumberTextField, List<TipsModel> allTips)
        {
            try
            {
                Log.Information("Starting to Tips service");
                        allTips.Add(new TipsModel(){
                            TipNumber = Int32.Parse(NumberTextField),
                            TipName = NameTextField,
                            Name = TipTextField,
                            TipLikes = 0,
                            TipDislikes = 0,
                            Link = LinkTextField,
                        });
                        writeToFile("TipsList.json", allTips);
                    }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}", e);
            }
            return 0;
        }

        public void writeToFile(string filePath, List<TipsModel> allTips)
        {
            try
            {
                Log.Information("Starting to writeToFile(TipsList)");
                string json = JsonConvert.SerializeObject(allTips, Formatting.Indented);
                File.WriteAllText(filePath, json);
                Log.Information("Finished writing to file");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught {0}", e);
            }
        }

        public Task<List<TipsModel>> SaveTips(List<TipsModel> allTips)
        {
            var filePath = "TipsList.json";
            try 
            {
                Log.Information("Starting writing TipsList");
                _jsonFileService.WriteJsonToFile(JsonConvert.SerializeObject(allTips, Formatting.Indented),filePath);
                Log.Information("Finished writing TipsList");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return Task.FromResult(allTips);
        }


        public void Like(List<TipsModel> allTips, int number, int clickLikeCount)
        {
            foreach(var tips in allTips)
            {
                if (tips.TipNumber == 1)
                { 
                    tips.TipLikes++; 
                }
            }
        }

         public void UnLike(List<TipsModel> allTips, int number, int clickLikeCount)
        {
            foreach(var tips in allTips)
            {
                if (tips.TipNumber == 1)
                { 
                    tips.TipLikes--; 
                }
            }
        }

        public void Dislike(List<TipsModel> allTips, int number, int clickDislikeCount)
        {
            foreach(var tips in allTips)
            {
                if (tips.TipNumber == 1)
                { 
                    tips.TipDislikes++; 
                }
            }
        }

        public void UnDislike(List<TipsModel> allTips, int number, int clickDislikeCount)
        {
            foreach(var tips in allTips)
            {
                if (tips.TipNumber == 1)
                { 
                    tips.TipDislikes--; 
                }
            }
        }
    }
}
