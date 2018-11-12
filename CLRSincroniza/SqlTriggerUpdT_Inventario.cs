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
    [SqlTrigger(Name = "SqlTriggerUpdT_Inventario", Target = "T_Inventario", Event = "FOR INSERT, UPDATE, DELETE")]
    public static void SqlTriggerUpdT_Inventario()
    {
        DbHelper.GenerarXml(SqlContext.TriggerContext, "T_Inventario");
    }
}

