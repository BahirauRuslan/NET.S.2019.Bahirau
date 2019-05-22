using System.Linq;
using DAL.Interface.DTO;

namespace DAL.Repositories
{
    public class HolderBinaryFileRepository : AbstractBinaryFileRepository<DTOHolder>
    {
        public HolderBinaryFileRepository(string filePath) : base(filePath)
        {
        }

        public override void Update(DTOHolder item)
        {
            var oldItem = (from itm in Items where itm.Id == item.Id select itm).First();
            this.Remove(oldItem);
            this.Add(item);
        }
    }
}
