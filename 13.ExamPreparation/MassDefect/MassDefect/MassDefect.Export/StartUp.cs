using MassDefect.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDefect.Export
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new MassDefectContext();

            //JsonExport.ExportPlanetsWithNotAnomalyOrigins(context);
            //JsonExport.ExportPeopleNoVictims(context);
            //JsonExport.ExportTopAnomaly(context);
            //XmlExport.ExportAnomaliesXml(context);
        }
    }
}
