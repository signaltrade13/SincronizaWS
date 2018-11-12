
using Microsoft.SqlServer.Server;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public static class DbHelper
{
    public static readonly string ROOT_FOLDER = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SQLSync");
    public static readonly string SVR_B_FOLDER = Path.Combine(ROOT_FOLDER, "SvrB");
    public static readonly string SVR_C_FOLDER = Path.Combine(ROOT_FOLDER, "SvrC");

    public static void CreateFoldersIfNotExists()
    {
        if (!Directory.Exists(ROOT_FOLDER))
        {
            DirectoryInfo di = new DirectoryInfo(ROOT_FOLDER);
            di.Create();
            di.Attributes |= (FileAttributes.Hidden);

            DirectoryInfo dB = new DirectoryInfo(Path.Combine(ROOT_FOLDER, "SvrB"));
            dB.Create();
            dB.Attributes |= (FileAttributes.Hidden);

            DirectoryInfo dC = new DirectoryInfo(Path.Combine(ROOT_FOLDER, "SvrC"));
            dC.Create();
            dC.Attributes |= (FileAttributes.Hidden);
        }
    }
    
    public static void GenerarXml(SqlTriggerContext ctx, string TableName)
    {
        var action = ctx.TriggerAction;
        var tablaRes = string.Empty;
        var prefix = string.Empty;

        switch (action)
        {
            case TriggerAction.Insert:
            case TriggerAction.Update:
                {
                    tablaRes = "INSERTED";
                    break;
                }
            case TriggerAction.Delete:
                {
                    prefix = "@";
                    tablaRes = "DELETED";
                    break;
                }
        }

        using (SqlConnection connection = new SqlConnection(@"context connection=true"))
        {
            connection.Open();
            SqlCommand command = new SqlCommand($@"SELECT * FROM {tablaRes};", connection);
            var reader = command.ExecuteReader(CommandBehavior.KeyInfo);

            var dt = new DataTable(TableName);
            dt.Load(reader);
            reader.Close();

            var ActionName = Enum.GetName(typeof(TriggerAction), action);
            var Name = $"{dt.TableName}.{prefix}{dt.Rows[0]["RowGuid"]}.{ActionName}.sync";

            CreateFoldersIfNotExists();

            dt.WriteXml(Path.Combine(SVR_B_FOLDER, Name), XmlWriteMode.WriteSchema);
            dt.WriteXml(Path.Combine(SVR_C_FOLDER, Name), XmlWriteMode.WriteSchema);
        }
    }    
}