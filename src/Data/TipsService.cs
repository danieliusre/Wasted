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

        public Task<List<TipsModel>> GetTips()
        {
            var tips =  new List<TipsModel>();
            var filePath = "DB\\Tips.txt";
            try 
            {
                Log.Information("Starting to TipsList");
                tips = JsonConvert.DeserializeObject<List<TipsModel>>(_jsonFileService.ReadJsonFromFile(filePath));
                Log.Information("Finished reading Tipslist");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return Task.FromResult(tips);
        }

        public void ReadTips(List<TipsModel> allTips)
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
        }

        public void Like(List<TipsModel> allTips, int number, int clickLikeCount)
        {
            foreach(var tips in allTips)
            {
                if (tips.TipNumber == number)
                { 
                    if (clickLikeCount < 2)
                    {
                        Console.WriteLine(clickLikeCount);
                        tips.TipLikes++; 
                        clickLikeCount++;
                        Console.WriteLine(clickLikeCount);
                    }
                    else
                    {
                        if (tips.TipLikes != 0)
                        {
                        tips.TipLikes--;
                        clickLikeCount = 0;
                        }
                    }
                }
            }
        }

        public void Dislike(List<TipsModel> allTips, int number, int clickDislikeCount)
        {
            foreach(var tips in allTips)
            {
                if (tips.TipNumber == number)
                { 
                    if (clickDislikeCount < 2)
                    {
                        Console.WriteLine(clickDislikeCount);
                        tips.TipDislikes++; 
                        clickDislikeCount++;
                        Console.WriteLine(clickDislikeCount);
                    }
                    else
                    {
                        if (tips.TipDislikes != 0)
                        {
                        tips.TipDislikes--;
                        clickDislikeCount = 0;
                        }
                    }
                }
            }
        }
    }
}
