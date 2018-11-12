using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Xml;
using CLRSincroniza;
using Microsoft.SqlServer.Server;

public partial class Triggers
{
    [SqlTrigger(Name = "SqlTriggerUpdC_Semanas", Target = "C_Semanas", Event = "FOR INSERT, UPDATE, DELETE")]
    public static void SqlTriggerUpdC_Semanas()
    {
        DbHelper.GenerarXml(SqlContext.TriggerContext, "C_Semanas");
    }
}

