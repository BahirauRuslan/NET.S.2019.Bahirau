using System;
using DAL.DB.Repositories;

namespace DAL.DB
{
    public class UnitOfWork : IDisposable
    {
        private readonly BankContext _bankContext = new BankContext();
        private bool disposed = false;
        private AccountDBRepository _accountDBRepository;
        private HolderDBRepository _holderDBRepository;

        public AccountDBRepository Accounts
        {
            get
            {
                if (_accountDBRepository == null)
                {
                    _accountDBRepository = new AccountDBRepository(_bankContext);
                }

                return _accountDBRepository;
            }
        }

        public HolderDBRepository Holders
        {
            get
            {
                if (_holderDBRepository == null)
                {
                    _holderDBRepository = new HolderDBRepository(_bankContext);
                }

                return _holderDBRepository;
            }
        }

        public void Save()
        {
            _bankContext.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _bankContext.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
