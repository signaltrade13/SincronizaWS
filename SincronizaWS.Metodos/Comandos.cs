﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace SincronizaWS.Metodos
{
    public static class Comandos
    {
        static string _ConectionString;

        public static string ConectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_ConectionString))
                    return (Properties.Settings.Default.DBConnMagda1);
                else
                    return (_ConectionString);
            }
            set
            {
                _ConectionString = value;

            }           
                        
        }
        
        enum QMsg { Insertado, Actualizado, Deletado,Ejecutado};
        static Comandos()
        {


        }

        public static int VerificarData(SqlCommand cmd)
        {
            int n;

            using (SqlConnection conn = new SqlConnection(ConectionString))
            {
                cmd.Connection = conn;

                try
                {                    
                    conn.Open();
                    n = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
                catch (Exception ex)
                {
                    n = -1;
                    Console.WriteLine(ex.Message);
                }

                return (n);
            }

        }

        private static string ActualizarData(SqlCommand cmd)
        {
            using (SqlConnection conn = new SqlConnection(ConectionString))
            {
                cmd.Connection = conn;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return (QMsg.Ejecutado.ToString());
                }
                catch (Exception ex)
                {
                    return(ex.Message.ToString());
                }
            }

        }

        public static string EjectuaQuerys(SqlCommand cmdSelect, SqlCommand cmdInsert, SqlCommand cmdUpdate, SqlCommand cmdDelete)
        {
            string MsgEjecutaQuery;

            if (cmdDelete != null)
            {
                MsgEjecutaQuery = ActualizarData(cmdDelete);

                if (MsgEjecutaQuery == QMsg.Ejecutado.ToString())
                {
                    return (QMsg.Deletado.ToString());
                }
                else
                {
                    return (MsgEjecutaQuery);
                }
            }
            else
            {
                if (VerificarData(cmdSelect) > 0)
                {
                    MsgEjecutaQuery = ActualizarData(cmdUpdate);

                    if (MsgEjecutaQuery == QMsg.Ejecutado.ToString())
                    {
                        return (QMsg.Actualizado.ToString());
                    }
                    else
                    {
                        return (MsgEjecutaQuery);
                    }
                }
                else
                {
                    MsgEjecutaQuery = ActualizarData(cmdInsert);

                    if (MsgEjecutaQuery == QMsg.Ejecutado.ToString())
                    {
                        return (QMsg.Insertado.ToString());
                    }
                    else
                    {
                        return (MsgEjecutaQuery);
                    }
                }
            }
        } 


     }

}