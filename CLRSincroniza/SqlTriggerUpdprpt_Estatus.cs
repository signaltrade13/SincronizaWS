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
    [SqlTrigger(Name = "SqlTriggerUpdprpt_Estatus", Target = "rpt_Estatus", Event = "FOR INSERT, UPDATE, DELETE")]
    public static void SqlTriggerUpdprpt_Estatus()
    {
        DbHelper.GenerarXml(SqlContext.TriggerContext, "rpt_Estatus");
    }
}

