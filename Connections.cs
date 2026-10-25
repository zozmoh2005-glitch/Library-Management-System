using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Library
{
    internal class Connections
    {
        public const string sqlConStr = """
            Server=.;
            Database=dbEfLibrary;;
            Integrated Security=True;
            TrustServerCertificate=True;
            """;
    }
}
