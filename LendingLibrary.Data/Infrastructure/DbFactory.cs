using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingLibrary.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private LendingLibraryContext _dbContext;

        public LendingLibraryContext Init()
        {
            return _dbContext ?? (_dbContext = new LendingLibraryContext());
        }

        protected override void DisposeCore()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }
    }
}
