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

        public List<string> ErrorMsg = new List<string>();
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
                Log.Information("Started reading TipList");
                tips = JsonConvert.DeserializeObject<List<TipsModel>>(_jsonFileService.ReadJsonFromFile(filepath));
                Log.Information("Finished reading TipList");
            }
            catch(FileNotFoundException e)
            {
                Log.Error(e.Message);
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return tips;
        }

         public List<string> AddTip(string NameTextField, string TipTextField, string LinkTextField, string NumberTextField, List<TipsModel> allTips)
        {
            try
            {
                if( DataValid (NameTextField, TipTextField, LinkTextField, NumberTextField))
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
                        ErrorMsg.Add("Success! Thank you for the new tip!");
                }
                else
                {
                    ErrorMsg.Clear();
                    ErrorMsg.Add("Correct your tip!");
                }
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}", e);
            }
            return ErrorMsg;
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


        public void Like(List<TipsModel> allTips, int nr, int clickLikeCount)
        {
            foreach(var tips in allTips)
            {
                if (tips.TipNumber == nr)
                { 
                    tips.TipLikes++; 
                }
            }
        }

         public void UnLike(List<TipsModel> allTips, int nr, int clickLikeCount)
        {
            foreach(var tips in allTips)
            {
                if (tips.TipNumber == nr)
                { 
                    tips.TipLikes--; 
                }
            }
        }

        public void Dislike(List<TipsModel> allTips, int nr, int clickDislikeCount)
        {
            foreach(var tips in allTips)
            {
                if (tips.TipNumber == nr)
                { 
                    tips.TipDislikes++; 
                }
            }
        }

        public void UnDislike(List<TipsModel> allTips, int nr, int clickDislikeCount)
        {
            foreach(var tips in allTips)
            {
                if (tips.TipNumber == nr)
                { 
                    tips.TipDislikes--; 
                }
            }
        }

         public bool DataValid (string NameTextField, string TipTextField, string LinkTextField, string NumberTextField)
        {
            ValidationService validate = new ValidationService();
            try
            {
                Log.Information("Starting to DataValid");
                if ( validate.EmptyFieldsPresent(NameTextField, TipTextField, LinkTextField, NumberTextField))
                {
                    Log.Information("Finished DataValid (empty fields present)");
                    return false;
                }
                if(!validate.NumberValid(NumberTextField))
                {
                    ErrorMsg.Add("invalid tip number (must be a number)");
                    Log.Information("Finished dataValid (invalid password)");
                    return false;
                }
                if(!validate.LinkValid(LinkTextField))
                {
                    ErrorMsg.Add("invalid link (must start with http/https)");
                    Log.Information("Finished dataValid (invalid link)");
                    return false;
                }
                Log.Information("Finished data validation DataValid success");
                return true;
            }
            catch (Exception e)
            {
                Log.Error("Exception caught:{0}",e);
                return false;
            }

        }
    }
}
