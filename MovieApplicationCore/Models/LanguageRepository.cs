using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplicationCore.Models
{
    public class LanguageRepository : ILanguageRepository
    {
        MovieDbContext _movieDbContext = null;
        public LanguageRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public List<SelectListItem> GetLanguages()
        {
            List<LanguageModel> languageList = _movieDbContext.LanguageModels.ToList();
            List<SelectListItem> selectLanguageListItems = new List<SelectListItem>();
            foreach (var item in languageList)
            {
                selectLanguageListItems.Add(new SelectListItem { Text = item.Language, Value = item.Id.ToString() });
            }
            return selectLanguageListItems;
        }
        public SelectListItem GetLanguageById(string id)
        {
            //select * from languaemodesl where id='2'
            IQueryable<LanguageModel> languageList = from result in _movieDbContext.LanguageModels
                                                     where result.Id == Convert.ToInt32(id)
                                                     select result;
            SelectListItem selectListItem = new SelectListItem();

            foreach (var item in languageList)
            {
                selectListItem.Text = item.Language;
                selectListItem.Value = item.Id.ToString();
            }
            return selectListItem;
        }
    }
}
