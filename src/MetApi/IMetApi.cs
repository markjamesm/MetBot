using MetBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetBot
{
    public interface IMetApi
    {
        Task<CollectionItem> GetCollectionItemAsync(string objectNum);
    }
}
