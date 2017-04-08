using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wedding.Import
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //JsonImport.ImportAgencies();
            //JsonImport.ImportPeople();
            //JsonImport.ImportWeddingAndInvitation();
            //XmlImport.ImportPresents();
            XmlImport.ImportVanues();
        }
    }
}
