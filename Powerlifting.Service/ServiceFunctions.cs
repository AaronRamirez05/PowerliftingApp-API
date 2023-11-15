using Powerlifting.Service.Models;

//allows you to use interface to be used anywhere, to prevent redundant code 
namespace Powerlifting.Service
{
    //Implementation class
    public class ServiceFunctions : IServiceFunctions
    {
        private readonly ISqlDataAccess _db;
        public ServiceFunctions(ISqlDataAccess db)
        {
            _db = db;
        }
        public Task<List<UserXProgramId>> GetUserPrograms()
        {
            string sql = "SELECT [ProgramId],[UserId] FROM [db_a94b6f_powerlift].[dbo].[UserXProgramId]";
            return _db.LoadData<UserXProgramId, dynamic>(sql, new { });

        }

        public Task<List<UserXProgramId>> GetSpecificUserProgram(string UserId)
        {
            string sql = "SELECT [ProgramId],[UserId] FROM [db_a94b6f_powerlift].[dbo].[UserXProgramId] where UserId= '" + UserId + "' ";
            return _db.LoadData<UserXProgramId, dynamic>(sql, new { });

        }
 
        public Task<List<ProgramDTO>> GetSpecificProgramId(int ProgramId)
        {
            string sql = "SELECT [ProgramID],[ProgramName],[WorkoutID] FROM [db_a94b6f_powerlift].[dbo].[Programs] WHERE ProgramID = '" + ProgramId + "' ";
            return _db.LoadData<ProgramDTO, dynamic>(sql, new { });

        }

        public Task InsertUserandProgram(UserXProgramId request)
        {
            string sql = @"INSERT INTO [dbo].[UserXProgramId] ([UserId]) Values (@UserId)";
            return _db.SaveData(sql, request);
        }
    }
}