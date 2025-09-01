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

        public Task<List<UserXProgramId>> GetSpecificUserProgram(string UserId)    //Using this for now
        {
            string sql = "SELECT [ProgramId],[UserId],[Name] FROM [db_a94b6f_powerlift].[dbo].[UserXProgramId] where UserId= '" + UserId + "' ";
            return _db.LoadData<UserXProgramId, dynamic>(sql, new { });

        }
 
        public Task<List<ProgramDTO>> GetSpecificProgramId(int ProgramId)
        {
            string sql = "SELECT [ProgramID],[ProgramName],[WorkoutID] FROM [db_a94b6f_powerlift].[dbo].[Programs] WHERE ProgramID = '" + ProgramId + "' ";
            return _db.LoadData<ProgramDTO, dynamic>(sql, new { });

        }

        public Task InsertUserandProgram(UserXProgramId request)                //Using this for now 
        {
            string sql = @"INSERT INTO [dbo].[UserXProgramId] ([UserId],[Name]) Values (@UserId,@Name)";
            return _db.SaveData(sql, request);
        }

        public Task InsertWorkoutDetails(WorkoutDetails request)                //Using this for now 
        {
            string sql = @"INSERT INTO [dbo].[WorkoutDetails] ([Day],[WorkoutName],[SRRWeek1],[SRRWeek2],[SRRWeek3],[SRRWeek4],[ProgramName],[UserId],[workoutKey]) Values (@Day,@WorkoutName,@SRRWeek1,@SRRWeek2,@SRRWeek3,@SRRWeek4,@ProgramName,@UserId,NEWID())";
            return _db.SaveData(sql, request);
        }

        public Task<List<WorkoutDetails>> GetSpecificUserWorkouts(string UserId, string pname)    //Using this for now
        {
            string sql = "SELECT [Day],[WorkoutName],[SRRWeek1],[SRRWeek2],[SRRWeek3],[SRRWeek4],[ProgramName],[UserId] FROM [db_a94b6f_powerlift].[dbo].[WorkoutDetails] where UserId= '" + UserId + "' AND ProgramName = '" + pname + "'  "; 
            return _db.LoadData<WorkoutDetails, dynamic>(sql, new { });

        }

    }
}