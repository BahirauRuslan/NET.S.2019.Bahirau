using System.Linq;
using DAL.Interface.DTO;

namespace DAL.Fake.Repositories
{
    public class AccountFakeRepository : AbstractFakeRepository<DTOAccount>
    {
        public override void Update(DTOAccount item)
        {
            var oldItem = (from itm in Items where itm.Id == item.Id select itm).First();
            this.Remove(oldItem);
            this.Add(item);
        }
    }
}
