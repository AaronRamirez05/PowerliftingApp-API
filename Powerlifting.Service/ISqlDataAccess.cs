using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//allows you to use interface to be used anywhere, to prevent redundant code 
namespace Powerlifting.Service
{
    //Interface class
    public interface ISqlDataAccess
    {
        string ConnectionStringName { get; set; }
        Task ExecuteQuery(string sql);
        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task SaveData<T>(string sql, T parameters);
    }
}
