namespace BLL.Interface.Interfaces
{
    public interface IHolderIdService
    {
        long PrimaryNumber { get; set; }

        long GenerateHolderId();
    }
}
