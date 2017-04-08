using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Utilities
{
    public static class AccounGenerator
    {
        public static string GenereteCode()
        {
            return Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 10).ToUpper();
        }
    }
}
