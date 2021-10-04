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

        public Task<List<TipsModel>> GetTips()
        {
            var tips =  new List<TipsModel>();
            var filePath = "DB\\TipsList.txt";
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
    }
}
