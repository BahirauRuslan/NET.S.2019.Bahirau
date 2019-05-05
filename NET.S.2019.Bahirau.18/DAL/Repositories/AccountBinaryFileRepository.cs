using System.Linq;
using DAL.Interface.DTO;

namespace DAL.Repositories
{
    public class AccountBinaryFileRepository : AbstractBinaryFileRepository<DTOAccount>
    {
        public AccountBinaryFileRepository(string filePath) : base(filePath)
        {
        }

        public override void Update(DTOAccount item)
        {
            var oldItem = (from itm in Items where itm.Id == item.Id select itm).First();
            this.Remove(oldItem);
            this.Add(item);
        }
    }
}
