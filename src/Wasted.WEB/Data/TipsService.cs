using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Serilog;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Wasted.Data
{
    public class TipsService
    {
        public List<string> ErrorMsg = new List<string>();
        private readonly HttpHelper _httpHelper;

        public TipsService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }
        public async Task<List<Tip>> GetTips()
        {
            var tips =  new List<Tip>();
            try 
            {
                Log.Information("Started reading TipList");
                tips =  new List<Tip>(await _httpHelper.GetList<Tip>("tip"));
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
        public async Task<int> AddTip(Tip tips)
        {
            try 
            {
                Log.Information("Starting to add tip: {0}", tips.Name);
                var id =  await _httpHelper.Post<Tip>(tips,"tip");
                Log.Information("Finished adding tip: {0}", tips.Name);
                return id;
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return default(int);
            
        }
        public void DeleteTip(int tipId)
        {
            try 
            {
                Log.Information("Starting to delete tip id: {0}", tipId);
                _httpHelper.Delete(tipId,"tip");
                Log.Information("Finished reading Tiplist");
                
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
        }
        public void Like(List<Tip> allTips, int nr, int clickLikeCount)
        {
            foreach(var tips in allTips)
            {
                if (tips.TipId == nr)
                { 
                    tips.TipLikes++; 
                }
            }
        }

         public void UnLike(List<Tip> allTips, int nr, int clickLikeCount)
        {
            foreach(var tips in allTips)
            {
                if (tips.TipId == nr)
                { 
                    tips.TipLikes--; 
                }
            }
        }

        public void Dislike(List<Tip> allTips, int nr, int clickDislikeCount)
        {
            foreach(var tips in allTips)
            {
                if (tips.TipId == nr)
                { 
                    tips.TipDislikes++; 
                }
            }
        }

        public void UnDislike(List<Tip> allTips, int nr, int clickDislikeCount)
        {
            foreach(var tips in allTips)
            {
                if (tips.TipId == nr)
                { 
                    tips.TipDislikes--; 
                }
            }
        }

        public void Approve(List<Tip> allTips, int nr)
        {
            foreach(var tips in allTips)
            {
                if (tips.TipId == nr)
                { 
                    tips.AdminApproved = true; 
                }
            }
        }

         public bool DataValid (string NameTextField, string TipTextField, string LinkTextField)
        {
            ValidationService validate = new ValidationService();
            try
            {
                Log.Information("Starting to DataValid");
                if ( validate.EmptyFieldsPresent(NameTextField, TipTextField, LinkTextField,  LinkTextField))
                {
                    Log.Information("Finished DataValid (empty fields present)");
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
