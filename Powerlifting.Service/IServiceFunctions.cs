using Powerlifting.Service.Models;

//allows you to use interface to be used anywhere, to prevent redundant code 
namespace Powerlifting.Service
{
    //Interface class
    public interface IServiceFunctions
    {
        Task<List<UserXProgramId>> GetUserPrograms();

        Task<List<UserXProgramId>> GetSpecificUserProgram(string UserId);

        Task<List<ProgramDTO>> GetSpecificProgramId(int ProgramId);

        Task InsertUserandProgram(UserXProgramId request);
    }
}