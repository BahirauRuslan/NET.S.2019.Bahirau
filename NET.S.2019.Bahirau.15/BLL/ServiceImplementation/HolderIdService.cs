using BLL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class HolderIdService : IHolderIdService
    {
        public long PrimaryNumber { get; set; } = 1;

        public long GenerateHolderId()
        {
            return PrimaryNumber++;
        }
    }
}
