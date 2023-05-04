namespace MVCAssignment2.Services
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
        string GetUserEmail();
    }
}