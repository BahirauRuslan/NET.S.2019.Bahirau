namespace BLL.Interface.Interfaces
{
    public interface IHolderIdService
    {
        long GenerateHolderId(string name, string surname);
    }
}
