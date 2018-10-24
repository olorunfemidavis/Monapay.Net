using System;

namespace Monapay.Net.Helpers
{
    public class Generator
    {
        public static string GenerateReference()
        {
            Guid id = Guid.NewGuid();
            return id.ToString().Replace("-", "");
        }
    }
}
