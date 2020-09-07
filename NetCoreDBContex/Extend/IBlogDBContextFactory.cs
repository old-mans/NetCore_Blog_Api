using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreDBContex.Extend
{
    public interface IBlogDBContextFactory
    {
        public BlogDBContext Context();
    }
}
