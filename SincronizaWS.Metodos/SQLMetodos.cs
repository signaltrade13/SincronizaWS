using System;
using System.Data.SqlClient;

namespace SincronizaWS.Metodos
{
    public static class SQLMetodos
    {
        static SQLMetodos()
        {

        }

        private static bool IsDelete(ref string RowGuid)
        {
            if (RowGuid.StartsWith("@"))          
            {
                RowGuid = RowGuid.Substring(1, RowGuid.Length - 1).ToString();
                return (true);
            }
            else
            {
               return (false);
            }
        }

        //C_Almacen
        public static string SincronizaC_Almacen(decimal AlmacenId, string Almacen, string Ubicacion, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_Almacen WHERE RowGuid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_Almacen (AlmacenID,Almacen,Ubicacion,RowGuid) VALUES (@AlmacenId,@Almacen,@Ubicacion,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("AlmacenId", AlmacenId);
            cmdInsert.Parameters.AddWithValue("Almacen", Almacen);
            cmdInsert.Parameters.AddWithValue("Ubicacion", Ubicacion);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_Almacen SET Almacen=@Almacen,Ubicacion=@Ubicacion WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Almacen", Almacen);
            cmdUpdate.Parameters.AddWithValue("Ubicacion", Ubicacion);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_Almacen WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;}
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);}

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate,cmdDelete));

        }

        //C_AreaModulo
        public static string SincronizaC_AreaModulo(int ModuloId, int? AreaId, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_AreaModulo WHERE RowGuid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_AreaModulo (ModuloId,AreaId,RowGuid) VALUES (@ModuloId,@AreaId,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("ModuloId", ModuloId);
            cmdInsert.Parameters.AddWithValue("AreaId", AreaId);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_AreaModulo SET AreaId=@AreaId WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("AreaId", AreaId);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_AreaModulo WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_Area 
        public static string SincronizaC_Areas(int AreaId, string Descripcion, int? Orden, decimal? Bono, string RowGuid)
        {

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_Areas WHERE RowGuid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_Areas (AreaId,Descripción,Orden,Bono,RowGuid) VALUES(@AreaId,@Descripcion,@Orden,@Bono,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("AreaId", AreaId);
            cmdInsert.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdInsert.Parameters.AddWithValue("Orden", Orden);
            cmdInsert.Parameters.AddWithValue("Bono", Bono);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_Areas SET  Descripción=@Descripcion,Orden=@Orden,Bono=@Bono WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdUpdate.Parameters.AddWithValue("Orden", Orden);
            cmdUpdate.Parameters.AddWithValue("Bono", Bono);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_Areas WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_AreasRptEstatus
        public static string SincronizaC_AreasRptEstatus(int AreaOrdnId, int? Orden, int? OrdenDelantero, int? OrdenTrasero,string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_AreasRptEstatus WHERE RowGuid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_AreasRptEstatus (AreaOrdnId,Orden,OrdenDelantero,OrdenTrasero,RowGuid) VALUES (@AreaOrdnId,@Orden,@OrdenDelantero,@OrdenTrasero,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("AreaOrdnId", AreaOrdnId);
            cmdInsert.Parameters.AddWithValue("Orden", Orden);
            cmdInsert.Parameters.AddWithValue("OrdenDelantero", OrdenDelantero);
            cmdInsert.Parameters.AddWithValue("OrdenTrasero", OrdenTrasero);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_AreasRptEstatus SET  Orden=@Orden,OrdenDelantero=@OrdenDelantero,OrdenTrasero=@OrdenTrasero WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Orden", Orden);
            cmdUpdate.Parameters.AddWithValue("OrdenDelantero", OrdenDelantero);
            cmdUpdate.Parameters.AddWithValue("OrdenTrasero", OrdenTrasero);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_AreasRptEstatus WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));
        }

        //C_Articulos

        public static string SincronizaC_Articulos(decimal ArticuloId, decimal? LineaId, decimal? MonedaId, string Clave, string Descripcion, decimal? Costo,
           string unidad, string Ubicacion, string RowGuid)
        {

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_Articulos WHERE RowGuid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_Articulos (ArticuloId,LineaId,MonedaId,Clave,Descripcion,Costo,unidad,Ubicacion,RowGuid) " +
            "VALUES (@ArticuloId,@LineaId,@MonedaId,@Clave,@Descripcion,@Costo,@unidad,@Ubicacion,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("ArticuloId", ArticuloId);
            cmdInsert.Parameters.AddWithValue("LineaId", LineaId);
            cmdInsert.Parameters.AddWithValue("MonedaId", MonedaId);
            cmdInsert.Parameters.AddWithValue("Clave", Clave);
            cmdInsert.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdInsert.Parameters.AddWithValue("Costo", Costo);
            cmdInsert.Parameters.AddWithValue("unidad", unidad);
            cmdInsert.Parameters.AddWithValue("Ubicacion", Ubicacion);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_Articulos SET  LineaId=@LineaId,MonedaId=@MonedaId,Clave=@Clave,Descripcion=@Descripcion,Costo=@Costo,unidad=@unidad,Ubicacion=@Ubicacion WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("ArticuloId", ArticuloId);
            cmdUpdate.Parameters.AddWithValue("LineaId", LineaId);
            cmdUpdate.Parameters.AddWithValue("MonedaId", MonedaId);
            cmdUpdate.Parameters.AddWithValue("Clave", Clave);
            cmdUpdate.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdUpdate.Parameters.AddWithValue("Costo", Costo);
            cmdUpdate.Parameters.AddWithValue("unidad", unidad);
            cmdUpdate.Parameters.AddWithValue("Ubicacion", Ubicacion);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_Articulos WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_Bihorarios
        public static string SincronizaC_Bihorarios(int BihorarioId, DateTime? HoraInicio, DateTime? HoraFin, decimal? CantHrsLab, DateTime? HoraIniReal,
           DateTime? HoraFinReal, DateTime? HoraIniRealAnt, DateTime? HoraFinRealAnt,string RowGuid )
        {

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_Bihorarios RowGuid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_Bihorarios (BihorarioID,HoraInicio,HoraFin,CantHrsLab,HoraIniReal,HoraFinReal,HoraIniRealAnt,HoraFinRealAnt,RowGuid)" +
            "VALUES (@BihorarioId,@HoraInicio,@HoraFin,@CantHrsLab,@HoraIniReal,@HoraFinReal,@HoraIniRealAnt,@HoraFinRealAnt,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("BihorarioId", BihorarioId);
            cmdInsert.Parameters.AddWithValue("HoraInicio", HoraInicio);
            cmdInsert.Parameters.AddWithValue("HoraFin", HoraFin);
            cmdInsert.Parameters.AddWithValue("CantHrsLab", CantHrsLab);
            cmdInsert.Parameters.AddWithValue("HoraIniReal", HoraIniReal);
            cmdInsert.Parameters.AddWithValue("HoraFinReal", HoraFinReal);
            cmdInsert.Parameters.AddWithValue("HoraIniRealAnt", HoraIniRealAnt);
            cmdInsert.Parameters.AddWithValue("HoraFinRealAnt", HoraFinRealAnt);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_Bihorarios SET HoraInicio=@HoraInicio,HoraFin=@HoraFin,CantHrsLab=@CantHrsLab,HoraIniReal=@HoraIniReal,HoraFinReal=@HoraFinReal " +
            ",HoraIniRealAnt=@HoraIniRealAnt,HoraFinRealAnt=@HoraFinRealAnt WHERE RowGuidId=@RowGuidId");
            cmdUpdate.Parameters.AddWithValue("BihorarioId", BihorarioId);
            cmdUpdate.Parameters.AddWithValue("HoraInicio", HoraInicio);
            cmdUpdate.Parameters.AddWithValue("HoraFin", HoraFin);
            cmdUpdate.Parameters.AddWithValue("CantHrsLab", CantHrsLab);
            cmdUpdate.Parameters.AddWithValue("HoraIniReal", HoraIniReal);
            cmdUpdate.Parameters.AddWithValue("HoraFinReal", HoraFinReal);
            cmdUpdate.Parameters.AddWithValue("HoraIniRealAnt", HoraIniRealAnt);
            cmdUpdate.Parameters.AddWithValue("HoraFinRealAnt", HoraFinRealAnt);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_Bihorarios WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_Conceptos
        public static string SincronizaC_Conceptos(int ConceptoId, string Tipo, string Concepto, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_Conceptos WHERE RowGuid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_Conceptos (ConceptoId,Tipo,Concepto,RowGuid) VALUES (@ConceptoId,@Tipo,@Concepto,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("ConceptoId", ConceptoId);
            cmdInsert.Parameters.AddWithValue("Tipo", Tipo);
            cmdInsert.Parameters.AddWithValue("Concepto", Concepto);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_Conceptos SET  Tipo=@Tipo,Concepto=@Concepto WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Tipo", Tipo);
            cmdUpdate.Parameters.AddWithValue("Concepto", Concepto);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_Conceptos WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_ConceptosP
        public static string SincronizaC_ConceptosP(int ConceptoPId, string Descripcion, int? Tipo, decimal? Monto, string Formula, string RowGuid)
        {

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_ConceptosP WHERE RowGuid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_ConceptosP (ConceptoPId,Descripción,Tipo,Monto,Formula,RowGuid) VALUES (@ConceptoPId,@Descripcion,@Tipo,@Monto,@Formula,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("ConceptoPId", ConceptoPId);
            cmdInsert.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdInsert.Parameters.AddWithValue("Tipo", Tipo);
            cmdInsert.Parameters.AddWithValue("Monto", Monto);
            cmdInsert.Parameters.AddWithValue("Formula", Formula);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_ConceptosP SET  Descripción=@Descripcion,Tipo=@Tipo,Monto=@Monto,Formula=@Formula WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdUpdate.Parameters.AddWithValue("Tipo", Tipo);
            cmdUpdate.Parameters.AddWithValue("Monto", Monto);
            cmdUpdate.Parameters.AddWithValue("Formula", Formula);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_ConceptosP WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_EmpresaP
        public static string SincronizaC_EmpresaP(int EmpresaId, int? Dias, int? PorMax, string RowGuid)
        {

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_EmpresaP WHERE RowGuid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_EmpresaP (EmpresaId,Dias,PorMax,RowGuid) VALUES (@EmpresaId,@Dias,@PorMax,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("EmpresaId", EmpresaId);
            cmdInsert.Parameters.AddWithValue("Dias", Dias);
            cmdInsert.Parameters.AddWithValue("PorMax", PorMax);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_EmpresaP SET  Dias=@Dias,PorMax=@PorMax WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Dias", Dias);
            cmdUpdate.Parameters.AddWithValue("PorMax", PorMax);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_EmpresaP WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_Empresas
        public static string SincronizaC_Empresas(int EmpresaId, string Nombre, string NombreBd, string Direccion, string Telefono, string Fax, string Mail,
                                                  string rfc, int? Jornada, int? Pago, decimal? Porcentajeop, decimal? Porcentajearea, int? TotalPiezas, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_Empresas WHERE RowGuid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_Empresas (EmpresaId,Nombre,NombreBd,Dirección,Telefono,Fax,Mail,rfc,Jornada,Pago,Porcentajeop, Porcentajearea,TotalPiezas,RowGuid) " +
            "VALUES (@EmpresaId,@Nombre,@NombreBd,@Direccion,@Telefono,@Fax,@Mail,@rfc,@Jornada,@Pago,@Porcentajeop,@Porcentajearea,@TotalPiezas,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("EmpresaId", EmpresaId);
            cmdInsert.Parameters.AddWithValue("Nombre", Nombre);
            cmdInsert.Parameters.AddWithValue("NombreBd", NombreBd);
            cmdInsert.Parameters.AddWithValue("Direccion",Direccion);
            cmdInsert.Parameters.AddWithValue("Telefono", Telefono);
            cmdInsert.Parameters.AddWithValue("Fax", Fax);
            cmdInsert.Parameters.AddWithValue("Mail", Mail);
            cmdInsert.Parameters.AddWithValue("rfc", rfc);
            cmdInsert.Parameters.AddWithValue("Jornada", Jornada);
            cmdInsert.Parameters.AddWithValue("Pago", Pago);
            cmdInsert.Parameters.AddWithValue("Porcentajeop", Porcentajeop);
            cmdInsert.Parameters.AddWithValue("Porcentajearea", Porcentajearea);
            cmdInsert.Parameters.AddWithValue("TotalPiezas", TotalPiezas);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_Empresas SET Nombre=@Nombre,NombreBd=@NombreBd,Dirección=@Direccion,Telefono=@Telefono,Fax=@Fax,Mail=@Mail,rfc=@rfc,Jornada=@Jornada," +
            "Pago=@Pago,Porcentajeop=@Porcentajeop,Porcentajearea=@Porcentajearea,TotalPiezas=@TotalPiezas WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Nombre", Nombre);
            cmdUpdate.Parameters.AddWithValue("NombreBd", NombreBd);
            cmdUpdate.Parameters.AddWithValue("Direccion",Direccion);
            cmdUpdate.Parameters.AddWithValue("Telefono", Telefono);
            cmdUpdate.Parameters.AddWithValue("Fax", Fax);
            cmdUpdate.Parameters.AddWithValue("Mail", Mail);
            cmdUpdate.Parameters.AddWithValue("rfc", rfc);
            cmdUpdate.Parameters.AddWithValue("Jornada", Jornada);
            cmdUpdate.Parameters.AddWithValue("Pago", Pago);
            cmdUpdate.Parameters.AddWithValue("Porcentajeop", Porcentajeop);
            cmdUpdate.Parameters.AddWithValue("Porcentajearea", Porcentajearea);
            cmdUpdate.Parameters.AddWithValue("TotalPiezas", TotalPiezas);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_Empresas WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_GrosorAgujas
        public static string SincronizaC_GrosorAgujas(string Grosor, string RowGuid)
        {
            //GrosorId Bloqueado para insertar                              

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_GrosorAgujas WHERE RowGuid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_GrosorAgujas (Grosor,RowGuid) VALUES (@Grosor,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("Grosor", Grosor);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_GrosorAgujas SET  Grosor=@Grosor WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Grosor", Grosor);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_GrosorAgujas WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_HHilos
        public static string SincronizaC_Hilos(int HiloId, string Clave, string Descripcion, string Calibre, string CveColor, string Prov, string Marca, string Tipo,
           decimal? Yardas, decimal? Costo, int? unidad, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_Hilos WHERE RowGuid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_Hilos(HiloId,Clave,Descripcion,Calibre,CveColor,Prov,Marca,Tipo,Yardas,Costo,unidad,RowGuid) " +
            "VALUES (@HiloId,@Clave,@Descripcion,@Calibre,@CveColor,@Prov,@Marca,@Tipo,@Yardas,@Costo,@unidad,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("HiloId", HiloId);
            cmdInsert.Parameters.AddWithValue("Clave", Clave);
            cmdInsert.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdInsert.Parameters.AddWithValue("Calibre", Calibre);
            cmdInsert.Parameters.AddWithValue("CveColor", CveColor);
            cmdInsert.Parameters.AddWithValue("Prov", Prov);
            cmdInsert.Parameters.AddWithValue("Marca", Marca);
            cmdInsert.Parameters.AddWithValue("Tipo", Tipo);
            cmdInsert.Parameters.AddWithValue("Yardas", Yardas);
            cmdInsert.Parameters.AddWithValue("Costo", Costo);
            cmdInsert.Parameters.AddWithValue("unidad", unidad);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_Hilos SET Clave=@Clave,Descripcion=@Descripcion,Calibre=@Calibre,CveColor= @CveColor,Prov=@Prov,Marca=@Marca," +
            "Tipo=@Tipo,Yardas=@Yardas,Costo=@Costo,unidad=@unidad WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Clave", Clave);
            cmdUpdate.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdUpdate.Parameters.AddWithValue("Calibre", Calibre);
            cmdUpdate.Parameters.AddWithValue("CveColor", CveColor);
            cmdUpdate.Parameters.AddWithValue("Prov", Prov);
            cmdUpdate.Parameters.AddWithValue("Marca", Marca);
            cmdUpdate.Parameters.AddWithValue("Tipo", Tipo);
            cmdUpdate.Parameters.AddWithValue("Yardas", Yardas);
            cmdUpdate.Parameters.AddWithValue("Costo", Costo);
            cmdUpdate.Parameters.AddWithValue("unidad", unidad);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_Hilos WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));
        }

        //C_Lineas
        public static string SincronizaC_Lineas(decimal LineaId, string Descripcion, int? ValidaSolomon, int? ValidaCatalogo, string Catalogo, string RowGuid)
        {

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_Lineas WHERE RowGuid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_Lineas (LineaId,Descripcion,ValidaSolomon,ValidaCatalogo,Catalogo,RowGuid) VALUES (@LineaId,@Descripcion,@ValidaSolomon,@ValidaCatalogo,@Catalogo,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("LineaId", LineaId);
            cmdInsert.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdInsert.Parameters.AddWithValue("ValidaSolomon", ValidaSolomon);
            cmdInsert.Parameters.AddWithValue("ValidaCatalogo", ValidaCatalogo);
            cmdInsert.Parameters.AddWithValue("Catalogo", Catalogo);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_Lineas SET Descripcion=@Descripcion,ValidaSolomon=@ValidaSolomon,ValidaCatalogo=@ValidaCatalogo,Catalogo=@Catalogo WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdUpdate.Parameters.AddWithValue("ValidaSolomon", ValidaSolomon);
            cmdUpdate.Parameters.AddWithValue("ValidaCatalogo", ValidaCatalogo);
            cmdUpdate.Parameters.AddWithValue("Catalogo", Catalogo);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_Lineas WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_Maquinaria
        public static string SincronizaC_Maquinaria(int MaquinariaId, int? TipoMaquinaId, string NoInventario, string Descripcion, string Marca, string Modelo, string Serie,
          int? Propiedad, int? Ubicacion, int? ModuloId, string Observaciones, int? Estatus, decimal? Factor, decimal? ConsumoArriba, decimal? ConsumoAbajo, DateTime? FechaAlta,
          int? Rentada, decimal? Costo, decimal? ProveedorId, string RowGuid)
        {

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_Maquinaria WHERE RowGuid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_Maquinaria (MaquinariaId,TipoMaquinaId,NoInventario,Descripción,Marca,Modelo,Serie,Propiedad,Ubicación,Moduloid," +
            "Observaciones,Estatus,Factor,ConsumoArriba,ConsumoAbajo,FechaAlta,Rentada,Costo,ProveedorId,RowGuid) VALUES(@MaquinariaId,@TipoMaquinaId,@NoInventario,@Descripcion,@Marca,@Modelo," +
            "@Serie,@Propiedad,@Ubicacion,@ModuloId,@Observaciones,@Estatus,@Factor,@ConsumoArriba,@ConsumoAbajo,@FechaAlta,@Rentada,@Costo,@ProveedorId,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("MaquinariaId", MaquinariaId);
            cmdInsert.Parameters.AddWithValue("TipoMaquinaId", TipoMaquinaId);
            cmdInsert.Parameters.AddWithValue("NoInventario", NoInventario);
            cmdInsert.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdInsert.Parameters.AddWithValue("Marca", Marca);
            cmdInsert.Parameters.AddWithValue("Modelo", Modelo);
            cmdInsert.Parameters.AddWithValue("Serie", Serie);
            cmdInsert.Parameters.AddWithValue("Propiedad", Propiedad);
            cmdInsert.Parameters.AddWithValue("Ubicacion", Ubicacion);
            cmdInsert.Parameters.AddWithValue("ModuloId", ModuloId);
            cmdInsert.Parameters.AddWithValue("Observaciones", Observaciones);
            cmdInsert.Parameters.AddWithValue("Estatus", Estatus);
            cmdInsert.Parameters.AddWithValue("Factor", Factor);
            cmdInsert.Parameters.AddWithValue("ConsumoArriba", ConsumoArriba);
            cmdInsert.Parameters.AddWithValue("ConsumoAbajo", ConsumoAbajo);
            cmdInsert.Parameters.AddWithValue("FechaAlta", FechaAlta);
            cmdInsert.Parameters.AddWithValue("Rentada", Rentada);
            cmdInsert.Parameters.AddWithValue("Costo", Costo);
            cmdInsert.Parameters.AddWithValue("ProveedorId", ProveedorId);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_Maquinaria SET TipoMaquinaId=@TipoMaquinaId,NoInventario=@NoInventario,Descripción=@Descripcion,Marca=@Marca,Modelo=@Modelo," +
            "Serie=@Serie,Propiedad=@Propiedad,Ubicación=@Ubicacion,ModuloId=@ModuloId,Observaciones=@Observaciones,Estatus=@Estatus,Factor=@Factor,ConsumoArriba=@ConsumoArriba,ConsumoAbajo=@ConsumoAbajo," +
            "FechaAlta=@FechaAlta,Rentada=@Rentada,Costo=@Costo,ProveedorId=@ProveedorId WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("TipoMaquinaId", TipoMaquinaId);
            cmdUpdate.Parameters.AddWithValue("NoInventario", NoInventario);
            cmdUpdate.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdUpdate.Parameters.AddWithValue("Marca", Marca);
            cmdUpdate.Parameters.AddWithValue("Modelo", Modelo);
            cmdUpdate.Parameters.AddWithValue("Serie", Serie);
            cmdUpdate.Parameters.AddWithValue("Propiedad", Propiedad);
            cmdUpdate.Parameters.AddWithValue("Ubicacion", Ubicacion);
            cmdUpdate.Parameters.AddWithValue("ModuloId", ModuloId);
            cmdUpdate.Parameters.AddWithValue("Observaciones", Observaciones);
            cmdUpdate.Parameters.AddWithValue("Estatus", Estatus);
            cmdUpdate.Parameters.AddWithValue("Factor", Factor);
            cmdUpdate.Parameters.AddWithValue("ConsumoArriba", ConsumoArriba);
            cmdUpdate.Parameters.AddWithValue("ConsumoAbajo", ConsumoAbajo);
            cmdUpdate.Parameters.AddWithValue("FechaAlta", FechaAlta);
            cmdUpdate.Parameters.AddWithValue("Rentada", Rentada);
            cmdUpdate.Parameters.AddWithValue("Costo", Costo);
            cmdUpdate.Parameters.AddWithValue("ProveedorId", ProveedorId);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_Maquinaria WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_Marcas
        public static string SincronizaC_Marcas(string MarcaId, string Marca, string RowGuid)
        {
            //IdMarcas Bloqueado para Insercion           

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_Marcas WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_Marcas(MarcaId,Marca,RowGuid) VALUES(@MarcaId,@Marca,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("MarcaId", MarcaId);
            cmdInsert.Parameters.AddWithValue("Marca", Marca);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_Marcas SET Marca=@Marca WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Marca", Marca);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_Marcas WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_MarcasAgujas
        public static string SincronizaC_MarcasAgujas(string Marca, string RowGuid)
        {
            //IdMarcas Bloqueado para Insercion           

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_MarcasAgujas WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_MarcasAgujas(Marca,RowGuid) VALUES(@Marca,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("Marca", Marca);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_MarcasAgujas SET Marca=@Marca WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Marca", Marca);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_MarcasAgujas WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_ModeloAguja
        public static string SincronizaC_ModeloAguja(string Modelo, string RowGuid)
        {
            //IdModelo Bloqueado para Insercion                    

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_ModeloAguja WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_ModeloAguja(Modelo,RowGuid) VALUES(@Modelo,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("Modelo", Modelo);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_ModeloAguja SET Modelo=@Modelo WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Modelo", Modelo);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_ModeloAguja WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }


        //C_Modulos
        public static string SincronizaC_Modulos(int ModuloId, string Descripcion, decimal? Bono, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_Modulos WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_Modulos(ModuloId,Descripción,Bono,RowGuid) VALUES(@ModuloId,@Descripcion,@Bono,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("ModuloId", ModuloId);
            cmdInsert.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdInsert.Parameters.AddWithValue("Bono", Bono);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_Modulos SET Descripción=@Descripcion,Bono=@Bono WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdUpdate.Parameters.AddWithValue("Bono", Bono);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_Modulos WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }


            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }


        //C_Monedas
        public static string SincronizaC_Monedas(decimal MonedaId, string Descripcion, decimal? TipoCambio, string RowGuid)
        {

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_Monedas WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_Monedas(MonedaId,Descripción,TipoCambio,RowGuid) VALUES(@MonedaId,@Descripcion,@TipoCambio,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("MonedaId", MonedaId);
            cmdInsert.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdInsert.Parameters.AddWithValue("TipoCambio", TipoCambio);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_Monedas SET Descripción=@Descripcion,TipoCambio=@TipoCambio WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdUpdate.Parameters.AddWithValue("TipoCambio", TipoCambio);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_Monedas WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_Operaciones
        public static string SincronizaC_Operaciones(int OperacionId, string NumOper, string Descripcion, int? AreaId, string TipoOper, decimal? Tiempo, decimal? Consumo, int? TipoMaquinaId,
                         decimal? Produccion, decimal? Costoop, int? Orden, int? SueldoId, decimal? Factor, decimal? ConsumoArriba, decimal? ConsumoAbajo, decimal? Costura, int? Activo, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_Operaciones WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_Operaciones(OperacionId,NumOper,Descripción,AreaId,TipoOper,Tiempo,Consumo,TipoMaquinaId,Produccion,Costoop,Orden,SueldoId,Factor,ConsumoArriba,ConsumoAbajo,Costura,Activo,RowGuid) " +
           "VALUES(@OperacionId,@NumOper,@Descripcion,@AreaId,@TipoOper,@Tiempo,@Consumo,@TipoMaquinaId,@Produccion,@Costoop,@Orden,@SueldoId,@Factor,@ConsumoArriba,@ConsumoAbajo,@Costura,@Activo,@RowGuid)");

            cmdInsert.Parameters.AddWithValue("OperacionId", OperacionId);
            cmdInsert.Parameters.AddWithValue("NumOper", NumOper);
            cmdInsert.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdInsert.Parameters.AddWithValue("AreaId", AreaId);
            cmdInsert.Parameters.AddWithValue("TipoOper", TipoOper);
            cmdInsert.Parameters.AddWithValue("Tiempo", Tiempo);
            cmdInsert.Parameters.AddWithValue("Consumo", Consumo);
            cmdInsert.Parameters.AddWithValue("TipoMaquinaId", TipoMaquinaId);
            cmdInsert.Parameters.AddWithValue("Produccion", Produccion);
            cmdInsert.Parameters.AddWithValue("Costoop", Costoop);
            cmdInsert.Parameters.AddWithValue("Orden", Orden);
            cmdInsert.Parameters.AddWithValue("SueldoId", SueldoId);
            cmdInsert.Parameters.AddWithValue("Factor", Factor);
            cmdInsert.Parameters.AddWithValue("ConsumoArriba", ConsumoAbajo);
            cmdInsert.Parameters.AddWithValue("ConsumoAbajo", ConsumoAbajo);
            cmdInsert.Parameters.AddWithValue("Costura", Costura);
            cmdInsert.Parameters.AddWithValue("Activo", Activo);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_Operaciones SET NumOper=@NumOper,Descripción=@Descripcion,AreaId=@AreaId,TipoOper=@TipoOper,Tiempo=@Tiempo,Consumo=@Consumo,TipoMaquinaId=@TipoMaquinaId," +
            "Produccion=@Produccion,Costoop=@Costoop,Orden=@Orden,SueldoId=@SueldoId,Factor=@Factor,ConsumoArriba=@ConsumoArriba,ConsumoAbajo=@ConsumoAbajo,Costura=@Costura,Activo=@Activo WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("NumOper", NumOper);
            cmdUpdate.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdUpdate.Parameters.AddWithValue("AreaId", AreaId);
            cmdUpdate.Parameters.AddWithValue("TipoOper", TipoOper);
            cmdUpdate.Parameters.AddWithValue("Tiempo", Tiempo);
            cmdUpdate.Parameters.AddWithValue("Consumo", Consumo);
            cmdUpdate.Parameters.AddWithValue("TipoMaquinaId", TipoMaquinaId);
            cmdUpdate.Parameters.AddWithValue("Produccion", Produccion);
            cmdUpdate.Parameters.AddWithValue("Costoop", Costoop);
            cmdUpdate.Parameters.AddWithValue("Orden", Orden);
            cmdUpdate.Parameters.AddWithValue("SueldoId", SueldoId);
            cmdUpdate.Parameters.AddWithValue("Factor", Factor);
            cmdUpdate.Parameters.AddWithValue("ConsumoArriba", ConsumoAbajo);
            cmdUpdate.Parameters.AddWithValue("ConsumoAbajo", ConsumoAbajo);
            cmdUpdate.Parameters.AddWithValue("Costura", Costura);
            cmdUpdate.Parameters.AddWithValue("Activo", Activo);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_Operaciones WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_OperacionHilos
        public static string SincronizaC_OperacionHilos(int OperacionId, int? HiloId, int? Indice, int? Arriba, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_OperacionHilos WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO  C_OperacionHilos(OperacionId,HiloId,Indice,Arriba,RowGuid) VALUES(@OperacionId,@HiloId,@Indice,@Arriba,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("OperacionId", OperacionId);
            cmdInsert.Parameters.AddWithValue("HiloId", HiloId);
            cmdInsert.Parameters.AddWithValue("Indice", Indice);
            cmdInsert.Parameters.AddWithValue("Arriba", Arriba);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_OperacionHilos SET HiloId=@HiloId,Indice=@Indice,Arriba=@Arriba WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("HiloId", HiloId);
            cmdUpdate.Parameters.AddWithValue("Indice", Indice);
            cmdUpdate.Parameters.AddWithValue("Arriba", Arriba);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_OperacionHilos WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_Pantallas
        public static string SincronizaC_Pantallas(string Descripcion, int? Indice, string Menu, string RowGuid)
        {
            //PantallaId Bloqueado para Edicion            

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_Pantallas WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_Pantallas(Descripción,Indice,Menu,RowGuid) VALUES(@Descripcion,@Indice,@Menu,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdInsert.Parameters.AddWithValue("Indice", Indice);
            cmdInsert.Parameters.AddWithValue("Menu", Menu);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_Pantallas SET Descripción=@Descripcion,Indice=@Indice,Menu=@Menu WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdUpdate.Parameters.AddWithValue("Indice", Indice);
            cmdUpdate.Parameters.AddWithValue("Menu", Menu);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_Pantallas WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_Personal 

        public static string SincronizaC_Personal(int PersonalId, int? ModuloId, int? SueldoId, int? AreaId, int? OperacionId, string Numero, string ApellidoP, string ApellidoM,
                            string Nombre, string Calle, string NumeroExt, string Colonia, string Poblacion, string Ciudad, string Cp, string Telefono, string Emergencia,
                            string TelEmergencia, string Rfc, int? Estatus, DateTime? FecNac, decimal? Dias, decimal? PuestoId, string RowGuid)
        {

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_Personal WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_Personal(PersonalId,ModuloId,SueldoId,AreaId,OperacionId,Numero,ApellidoP,ApellidoM,Nombre,Calle,NumeroExt,Colonia,Poblacion, Ciudad, Cp, Telefono, Emergencia, TelEmergencia, Rfc, Estatus, FecNac, Dias, PuestoId, RowGuid) " +
            "VALUES (@PersonalId,@ModuloId,@SueldoId,@AreaId,@OperacionId,@Numero,@ApellidoP, @ApellidoM,@Nombre,@Calle,@NumeroExt,@Colonia,@Poblacion,@Ciudad,@Cp,@Telefono,@Emergencia,@TelEmergencia,@Rfc,@Estatus,@FecNac,@Dias,@PuestoId,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("PersonalId", PersonalId);
            cmdInsert.Parameters.AddWithValue("ModuloId", ModuloId);
            cmdInsert.Parameters.AddWithValue("SueldoId", SueldoId);
            cmdInsert.Parameters.AddWithValue("AreaId", AreaId);
            cmdInsert.Parameters.AddWithValue("OperacionId", OperacionId);
            cmdInsert.Parameters.AddWithValue("Numero", Numero);
            cmdInsert.Parameters.AddWithValue("ApellidoP", ApellidoP);
            cmdInsert.Parameters.AddWithValue("ApellidoM", ApellidoM);
            cmdInsert.Parameters.AddWithValue("Nombre", Nombre);
            cmdInsert.Parameters.AddWithValue("Calle", Calle);
            cmdInsert.Parameters.AddWithValue("NumeroExt", Numero);
            cmdInsert.Parameters.AddWithValue("Colonia", Colonia);
            cmdInsert.Parameters.AddWithValue("Poblacion", Poblacion);
            cmdInsert.Parameters.AddWithValue("Ciudad", Ciudad);
            cmdInsert.Parameters.AddWithValue("Cp", Cp);
            cmdInsert.Parameters.AddWithValue("Telefono", Telefono);
            cmdInsert.Parameters.AddWithValue("Emergencia", Emergencia);
            cmdInsert.Parameters.AddWithValue("TelEmergencia", TelEmergencia);
            cmdInsert.Parameters.AddWithValue("Rfc", Rfc);
            cmdInsert.Parameters.AddWithValue("Estatus", Estatus);
            cmdInsert.Parameters.AddWithValue("FecNac", FecNac);
            cmdInsert.Parameters.AddWithValue("Dias", Dias);
            cmdInsert.Parameters.AddWithValue("PuestoId", PuestoId);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_Personal SET ModuloId=@ModuloId,SueldoId=@ModuloId,AreaId=@AreaId,OperacionId=@OperacionId,Numero=@Numero,ApellidoP=@ApellidoP,ApellidoM=@ApellidoM," +
            "Nombre=@Nombre,Calle=@Calle,NumeroExt=@NumeroExt,Colonia=@Colonia,Poblacion= @Poblacion,Ciudad=@Ciudad,Cp=@Cp,Telefono=@Telefono," +
            "Emergencia=@Emergencia,TelEmergencia=@TelEmergencia,Rfc=@Rfc,Estatus=@Estatus,FecNac=@FecNac,Dias=@Dias,PuestoId=@PuestoId WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("ModuloId", ModuloId);
            cmdUpdate.Parameters.AddWithValue("SueldoId", SueldoId);
            cmdUpdate.Parameters.AddWithValue("AreaId", AreaId);
            cmdUpdate.Parameters.AddWithValue("OperacionId", OperacionId);
            cmdUpdate.Parameters.AddWithValue("Numero", Numero);
            cmdUpdate.Parameters.AddWithValue("ApellidoP", ApellidoP);
            cmdUpdate.Parameters.AddWithValue("ApellidoM", ApellidoM);
            cmdUpdate.Parameters.AddWithValue("Nombre", Nombre);
            cmdUpdate.Parameters.AddWithValue("Calle", Calle);
            cmdUpdate.Parameters.AddWithValue("NumeroExt", Numero);
            cmdUpdate.Parameters.AddWithValue("Colonia", Colonia);
            cmdUpdate.Parameters.AddWithValue("Poblacion", Poblacion);
            cmdUpdate.Parameters.AddWithValue("Ciudad", Ciudad);
            cmdUpdate.Parameters.AddWithValue("Cp", Cp);
            cmdUpdate.Parameters.AddWithValue("Telefono", Telefono);
            cmdUpdate.Parameters.AddWithValue("Emergencia", Emergencia);
            cmdUpdate.Parameters.AddWithValue("TelEmergencia", TelEmergencia);
            cmdUpdate.Parameters.AddWithValue("Rfc", Rfc);
            cmdUpdate.Parameters.AddWithValue("Estatus", Estatus);
            cmdUpdate.Parameters.AddWithValue("FecNac", FecNac);
            cmdUpdate.Parameters.AddWithValue("Dias", Dias);
            cmdUpdate.Parameters.AddWithValue("PuestoId", PuestoId);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_Personal WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_PersonalFechas
        public static string SincronizaC_PersonalFechas(int PersonalId, int? Tipo, DateTime? Fecha, string RowGuid)
        {

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_PersonalFechas WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_PersonalFechas(PersonalId,Tipo,Fecha,RowGuid) VALUES(@PersonalId,@Tipo,@Fecha,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("PersonalId", PersonalId);
            cmdInsert.Parameters.AddWithValue("Tipo", Tipo);
            cmdInsert.Parameters.AddWithValue("Fecha", Fecha);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_PersonalFechas SET Tipo=@Tipo,Fecha=@Fecha) WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Tipo", Tipo);
            cmdUpdate.Parameters.AddWithValue("Fecha", Fecha);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_PersonalFechas WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_Proveedores
        public static string SincronizaC_Proveedores(string Descripcion, string RowGuid)
        {
            //ProveedorId Bloqueado para edicion         

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_Proveedores WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_Proveedores (Descripción,RowGuid) VALUES (@Descripcion,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_Proveedores SET Descripción=@Descripcion WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_Proveedores WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_Puestos
        public static string SincronizaC_Puestos(decimal PuestoId, string Puesto, string RowGuid)
        {

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_Puestos WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_Puestos (PuestoId,Puesto,RowGuid) VALUES(@PuestoId,@Puesto,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("PuestoId", PuestoId);
            cmdInsert.Parameters.AddWithValue("Puesto", Puesto);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_Puestos SET Puesto=@Puesto WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Puesto", Puesto);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_Puestos WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_PuntaAgujas
        public static string SincronizaC_PuntasAgujas(string Punta, string RowGuid)
        {
            //Campo PuntaId Bloqueado para edicion            

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_PuntasAgujas WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_PuntasAgujas (Punta,RowGuid) VALUES (@Punta,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("Punta", Punta);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_PuntasAgujas SET Punta=@Punta WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Punta", Punta);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_PuntasAgujas WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_Refacciones 
        public static string SincronizaC_Refacciones(decimal RefaccionId, string Clave, string Descripcion, decimal? MonedaId, decimal? Costo, string RowGuid)
        {

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_Refacciones WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_Refacciones (RefaccionId,Clave,Descripcion,MonedaId,Costo,RowGuid) VALUES (@RefaccionId,@Clave,@Descripcion,@MonedaId,@Costo,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("RefaccionId", RefaccionId);
            cmdInsert.Parameters.AddWithValue("Clave", Clave);
            cmdInsert.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdInsert.Parameters.AddWithValue("MonedaId", MonedaId);
            cmdInsert.Parameters.AddWithValue("Costo", Costo);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_Refacciones SET Clave=@Clave,Descripcion=@Descripcion,MonedaId=@MonedaId,Costo=@Costo WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Clave", Clave);
            cmdUpdate.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdUpdate.Parameters.AddWithValue("MonedaId", MonedaId);
            cmdUpdate.Parameters.AddWithValue("Costo", Costo);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_Refacciones WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_Semanas
        public static string SincronizaC_Semanas(int SemanaId, DateTime? FechaInicio, DateTime? FechaFinal,string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_Semanas WHERE RowGuid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("SemanaId", SemanaId);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_Semanas(SemanaId,FechaInicio,FechaFinal,RowGuid) VALUES (@SemanaId,@FechaInicio,@FechaFinal,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("SemanaId", SemanaId);
            cmdInsert.Parameters.AddWithValue("FechaInicio", FechaInicio);
            cmdInsert.Parameters.AddWithValue("FechaFinal", FechaFinal);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_Semanas SET FechaInicio=@FechaInicio,FechaFinal=@FechaFinal) WHERE RowGuidId@RowGuidId");
            cmdUpdate.Parameters.AddWithValue("FechaInicio", FechaInicio);
            cmdUpdate.Parameters.AddWithValue("FechaFinal", FechaFinal);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_Semanas WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }


            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_Sueldos
        public static string SincronizaC_Sueldos(int SueldoId, string Categoria, decimal? Monto, decimal? Bono, string RowGuid)
        {

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_Sueldos WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_Sueldos (SueldoId,Categoria,Monto,Bono,RowGuid) VALUES(@SueldoId,@Categoria,@Monto,@Bono,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("SueldoId", SueldoId);
            cmdInsert.Parameters.AddWithValue("Categoria", Categoria);
            cmdInsert.Parameters.AddWithValue("Monto", Monto);
            cmdInsert.Parameters.AddWithValue("Bono", Bono);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_Sueldos  SET Categoria=@Categoria,Monto=@Monto,Bono=@Bono WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Categoria", Categoria);
            cmdUpdate.Parameters.AddWithValue("Monto", Monto);
            cmdUpdate.Parameters.AddWithValue("Bono", Bono);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_Sueldos WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }


        //C_Tallas
        public static string SincronizaC_Tallas(decimal TallaId, string Largo, string Ancho, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_Tallas WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_Tallas (TallaId,Largo,Ancho,RowGuid) VALUES (@TallaId,@Largo,@Ancho,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("TallaId", TallaId);
            cmdInsert.Parameters.AddWithValue("Largo", Largo);
            cmdInsert.Parameters.AddWithValue("Ancho", Ancho);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_Tallas  SET Largo=@Largo,Ancho=@Ancho WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Largo", Largo);
            cmdUpdate.Parameters.AddWithValue("Ancho", Ancho);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_Tallas WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }


            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_TiposMaquina
        public static string SincronizaC_TiposMaquina(int TipoMaquinaId, string Descripcion, decimal? Factor, decimal? ConsumoArriba, decimal? ConsumoAbajo, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_TiposMaquina WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_TiposMaquina (TipoMaquinaId,Descripción,Factor,ConsumoArriba,ConsumoAbajo,RowGuid) VALUES (@TipoMaquinaId,@Descripcion,@Factor,@ConsumoArriba,@ConsumoAbajo,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("TipoMaquinaId", TipoMaquinaId);
            cmdInsert.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdInsert.Parameters.AddWithValue("Factor", Factor);
            cmdInsert.Parameters.AddWithValue("ConsumoArriba", ConsumoArriba);
            cmdInsert.Parameters.AddWithValue("ConsumoAbajo", ConsumoAbajo);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_TiposMaquina  SET Descripción=@Descripcion,Factor=@Factor,ConsumoArriba=@ConsumoArriba,ConsumoAbajo=@ConsumoAbajo WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdUpdate.Parameters.AddWithValue("Factor", Factor);
            cmdUpdate.Parameters.AddWithValue("ConsumoArriba", ConsumoArriba);
            cmdUpdate.Parameters.AddWithValue("ConsumoAbajo", ConsumoAbajo);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_TiposMaquina WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_TiposRegAguja
        public static string SincronizaC_TiposRegAguja(int ReAguja, string TipoReg, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_TiposRegAguja WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_TiposRegAguja (ReAguja,TipoReg,RowGuid) VALUES (@ReAguja,@TipoReg,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("ReAguja", ReAguja);
            cmdInsert.Parameters.AddWithValue("TipoReg", TipoReg);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_TiposRegAguja  SET TipoReg=@TipoReg  WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("TipoReg", TipoReg);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_TiposRegAguja WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //C_Usuaruios
        public static string SincronizaC_Usuarios(int UsuarioId, string Usuario, string Contrasena, string Nombre, int? Activo, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM C_Usuarios WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO C_Usuarios (UsuarioId,Usuario,Contraseña,Nombre,Activo,RowGuid) VALUES (@UsuarioId,@Usuario,@Contrasena,@Nombre,@Activo,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("UsuarioId", UsuarioId);
            cmdInsert.Parameters.AddWithValue("Usuario", Usuario);
            cmdInsert.Parameters.AddWithValue("Contrasena", Contrasena);
            cmdInsert.Parameters.AddWithValue("Nombre", Nombre);
            cmdInsert.Parameters.AddWithValue("Activo", Activo);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE C_Usuarios  SET Usuario=@Usuario,Contraseña=@Contrasena,Nombre=@Nombre,Activo=@Activo WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Usuario", Usuario);
            cmdUpdate.Parameters.AddWithValue("Contrasena", Contrasena);
            cmdUpdate.Parameters.AddWithValue("Nombre", Nombre);
            cmdUpdate.Parameters.AddWithValue("Activo", Activo);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM C_Usuarios WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //Parametros
        public static string SincronizaParametros(int Jornada, decimal? TipoCambio, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM Parametros WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO Parametros (Jornada,TipoCambio,RowGuid) VALUES (@Jornada,@TipoCambio,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("Jornada", Jornada);
            cmdInsert.Parameters.AddWithValue("TipoCambio", TipoCambio);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE Parametros  SET TipoCambio=@TipoCambio WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Jornada", Jornada);
            cmdUpdate.Parameters.AddWithValue("TipoCambio", TipoCambio);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM Parametros WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //rpt_Status
        public static string Sincronizarpt_Estatus(int OrdenId, int? Cantidad, int? UsuarioId, string Descripcion, int? OrdenArea, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM rpt_Estatus WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO rpt_Estatus(OrdenId,Cantidad,UsuarioId,Descripcion,OrdenArea,RowGuid) VALUES (@OrdenId,@Cantidad,@UsuarioId,@Descripcion,@OrdenArea,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("OrdenId", OrdenId);
            cmdInsert.Parameters.AddWithValue("Cantidad", Cantidad);
            cmdInsert.Parameters.AddWithValue("UsuarioId", UsuarioId);
            cmdInsert.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdInsert.Parameters.AddWithValue("OrdenArea", OrdenArea);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE rpt_Estatus  SET Cantidad=@Cantidad,UsuarioId=@UsuarioId,Descripcion=@Descripcion,OrdenArea=@OrdenArea WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Cantidad", Cantidad);
            cmdUpdate.Parameters.AddWithValue("UsuarioId", UsuarioId);
            cmdUpdate.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdUpdate.Parameters.AddWithValue("OrdenArea", OrdenArea);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM rpt_Estatus WHERE RowGuid=@RowGuid");
            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //T_Agujas
        public static string SincronizaT_Agujas(decimal Folio, int? MaquinariaId, decimal? MarcaId, decimal? ModeloId, decimal? GrosorId, decimal? PuntaId, string Motivo,
            DateTime? Fecha, string Observaciones, int? Tipo, int? cancelado, DateTime? FechaCancel, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_Agujas WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_Agujas(Folio,MaquinariaId,MarcaId,ModeloId,GrosorId,PuntaId,Motivo,Fecha,Observaciones,Tipo,cancelado,FechaCancel,RowGuid)" +
            "VALUES (@Folio,@MaquinariaId,@MarcaId,@ModeloId,@GrosorId,@PuntaId,@Motivo,@Fecha,@Observaciones,@Tipo,@cancelado,@FechaCancel,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("Folio", Folio);
            cmdInsert.Parameters.AddWithValue("MaquinariaId", MaquinariaId);
            cmdInsert.Parameters.AddWithValue("MarcaId", MarcaId);
            cmdInsert.Parameters.AddWithValue("ModeloId", ModeloId);
            cmdInsert.Parameters.AddWithValue("GrosorId", GrosorId);
            cmdInsert.Parameters.AddWithValue("PuntaId", PuntaId);
            cmdInsert.Parameters.AddWithValue("Motivo", Motivo);
            cmdInsert.Parameters.AddWithValue("Fecha", Fecha);
            cmdInsert.Parameters.AddWithValue("Observaciones", Observaciones);
            cmdInsert.Parameters.AddWithValue("Tipo", Tipo);
            cmdInsert.Parameters.AddWithValue("cancelado", cancelado);
            cmdInsert.Parameters.AddWithValue("FechaCancel", FechaCancel);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_Agujas SET  MarcaId=@MarcaId,ModeloId=@ModeloId,GrosorId=@GrosorId,PuntaId=@PuntaId,Motivo=@Motivo,Fecha=@Fecha,Observaciones=@Observaciones,Tipo=@Tipo," +
            "cancelado=@cancelado,FechaCancel=@FechaCancel WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("MaquinariaId", MaquinariaId);
            cmdUpdate.Parameters.AddWithValue("MarcaId", MarcaId);
            cmdUpdate.Parameters.AddWithValue("ModeloId", ModeloId);
            cmdUpdate.Parameters.AddWithValue("GrosorId", GrosorId);
            cmdUpdate.Parameters.AddWithValue("PuntaId", PuntaId);
            cmdUpdate.Parameters.AddWithValue("Motivo", Motivo);
            cmdUpdate.Parameters.AddWithValue("Fecha", Fecha);
            cmdUpdate.Parameters.AddWithValue("Observaciones", Observaciones);
            cmdUpdate.Parameters.AddWithValue("Tipo", Tipo);
            cmdUpdate.Parameters.AddWithValue("cancelado", cancelado);
            cmdUpdate.Parameters.AddWithValue("FechaCancel", FechaCancel);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_Agujas WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //T_Balanceo
        public static string SincronizaT_Balanceo(decimal BalanceoId, decimal? EstiloId, DateTime? Fecha, string Observaciones, int? MinTurno, int? Produccion, decimal? porcentaje, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_Balanceo WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_Balanceo(BalanceoId,EstiloId,Fecha,Observaciones,MinTurno,Produccion,porcentaje,RowGuid) " +
            "VALUES(@BalanceoId,@EstiloId,@Fecha,@Observaciones,@MinTurno,@Produccion,@porcentaje,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("BalanceoId", BalanceoId);
            cmdInsert.Parameters.AddWithValue("EstiloId", EstiloId);
            cmdInsert.Parameters.AddWithValue("Fecha", Fecha);
            cmdInsert.Parameters.AddWithValue("Observaciones", Observaciones);
            cmdInsert.Parameters.AddWithValue("MinTurno", MinTurno);
            cmdInsert.Parameters.AddWithValue("Produccion", Produccion);
            cmdInsert.Parameters.AddWithValue("porcentaje", porcentaje);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_Balanceo SET  EstidloId=@EstiloId,Fecha=@Fecha,Observaciones=@Observaciones,MinTurno=@MinTurno,Produccion=@Produccion,Porcentaje=@porcentaje WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("EstiloId", EstiloId);
            cmdUpdate.Parameters.AddWithValue("Fecha", Fecha);
            cmdUpdate.Parameters.AddWithValue("Observaciones", Observaciones);
            cmdUpdate.Parameters.AddWithValue("MinTurno", MinTurno);
            cmdUpdate.Parameters.AddWithValue("Produccion", Produccion);
            cmdUpdate.Parameters.AddWithValue("porcentaje", porcentaje);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_Balanceo WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //T_BalanceoMaq
        public static string SincronizaT_BalanceoMaq(decimal BalanceoId, decimal? Renglon, int? TipoMaquinaId, int? Cantidad, int? Invent, int? Dif, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_BalanceoMaq WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_BalanceoMaq(BalanceoId,Renglon,TipoMaquinaId,Cantidad,Invent,Dif,RowGuid) VALUES (@BalanceoId,@Renglon,@TipoMaquinaId,@Cantidad,@Invent,@Dif,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("BalanceoId", BalanceoId);
            cmdInsert.Parameters.AddWithValue("Renglon", Renglon);
            cmdInsert.Parameters.AddWithValue("TipoMaquinaId", TipoMaquinaId);
            cmdInsert.Parameters.AddWithValue("Cantidad", Cantidad);
            cmdInsert.Parameters.AddWithValue("Invent", Invent);
            cmdInsert.Parameters.AddWithValue("Dif", Dif);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_BalanceoMaq SET Renglon=@Renglon,TipoMaquinaId=@TipoMaquinaId,Cantidad=@Cantidad,Invent=@Invent,Dif=@Dif WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Renglon", Renglon);
            cmdUpdate.Parameters.AddWithValue("TipoMaquinaId", TipoMaquinaId);
            cmdUpdate.Parameters.AddWithValue("Cantidad", Cantidad);
            cmdUpdate.Parameters.AddWithValue("Invent", Invent);
            cmdUpdate.Parameters.AddWithValue("Dif", Dif);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_BalanceoMaq WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));


        }

        //T_BalanceOpDet
        public static string SincronizaT_BalanceoOpDet(decimal BalanceoId, int? OperacionId, int? Renglon, decimal? std, decimal? stda, decimal? prodh, decimal? prodt, decimal? tiempon,
            decimal operariost, int? operariorr, decimal? mintd, decimal? desocu, int? maquinas, int? Manuales, int? asistente, int? bultero, int? sup, string RowGuid)
        {

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_BalanceoOpDet WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_BalanceoOpDet(BalanceoId,OperacionId,Renglon,std,stda,prodh,prodt,tiempon,operariost,operariorr,mintd,desocu,maquinas,Manuales,asistente,bultero,sup,rowguid) " +
            "VALUES(@BalanceoId,@OperacionId,@Renglon,@std,@stda,@prodh,@prodt,@tiempon,@operariost,@operariorr,@mintd,@desocu,@maquinas,@Manuales,@asistente,@bultero,@sup,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("BalanceoId", BalanceoId);
            cmdInsert.Parameters.AddWithValue("OperacionId", OperacionId);
            cmdInsert.Parameters.AddWithValue("Renglon", Renglon);
            cmdInsert.Parameters.AddWithValue("std", std);
            cmdInsert.Parameters.AddWithValue("stda", stda);
            cmdInsert.Parameters.AddWithValue("prodh", prodh);
            cmdInsert.Parameters.AddWithValue("prodt", prodt);
            cmdInsert.Parameters.AddWithValue("tiempon", tiempon);
            cmdInsert.Parameters.AddWithValue("operariost", operariost);
            cmdInsert.Parameters.AddWithValue("operariorr", operariorr);
            cmdInsert.Parameters.AddWithValue("mintd", mintd);
            cmdInsert.Parameters.AddWithValue("desocu", desocu);
            cmdInsert.Parameters.AddWithValue("maquinas", maquinas);
            cmdInsert.Parameters.AddWithValue("Manuales", Manuales);
            cmdInsert.Parameters.AddWithValue("asistente", asistente);
            cmdInsert.Parameters.AddWithValue("bultero", bultero);
            cmdInsert.Parameters.AddWithValue("sup", sup);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_BalanceoOpDet SET OperacionId=@OperacionId,Renglon=@Renglon,std=@std,stda=@stda,prodh=@prodh,prodt=@prodt,tiempon=@tiempon,operariost=@operariost,operariorr=@operariorr," +
            "mintd=@mintd,desocu=@desocu,maquinas=@maquinas,manuales=@Manuales,asistente=@asistente,bultero=@bultero,sup=@sup WHERE rowguid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("OperacionId", OperacionId);
            cmdUpdate.Parameters.AddWithValue("Renglon", Renglon);
            cmdUpdate.Parameters.AddWithValue("std", std);
            cmdUpdate.Parameters.AddWithValue("stda", stda);
            cmdUpdate.Parameters.AddWithValue("prodh", prodh);
            cmdUpdate.Parameters.AddWithValue("prodt", prodt);
            cmdUpdate.Parameters.AddWithValue("tiempon", tiempon);
            cmdUpdate.Parameters.AddWithValue("operariost", operariost);
            cmdUpdate.Parameters.AddWithValue("operariorr", operariorr);
            cmdUpdate.Parameters.AddWithValue("mintd", mintd);
            cmdUpdate.Parameters.AddWithValue("desocu", desocu);
            cmdUpdate.Parameters.AddWithValue("maquinas", maquinas);
            cmdUpdate.Parameters.AddWithValue("Manuales", Manuales);
            cmdUpdate.Parameters.AddWithValue("asistente", asistente);
            cmdUpdate.Parameters.AddWithValue("bultero", bultero);
            cmdUpdate.Parameters.AddWithValue("sup", sup);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_BalanceoOpDet WHERE RowGuid=@RowGuid");
            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        public static string SincronizaT_BalanceoOtros(decimal BalanceoId, decimal? renglon, string Descripcion, decimal? cant, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_BalanceoOtros WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_BalanceoOtros (BalanceoId,renglon,Descripcion,cant,RowGuid) VALUES(@BalanceoId,@renglon,@Descripcion,@cant,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("BalanceoId", BalanceoId);
            cmdInsert.Parameters.AddWithValue("renglon", renglon);
            cmdInsert.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdInsert.Parameters.AddWithValue("cant", cant);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_BalanceoOtros SET renglon=@renglon,Descripcion=@Descripcion,cant=@Cant WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("renglon", renglon);
            cmdUpdate.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdUpdate.Parameters.AddWithValue("cant", cant);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_BalanceoOtros WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //T_BalanceoStaf
        public static string SincronizaT_BalanceoStaf(decimal BalanceoId, decimal? renglon, string Descripcion, decimal? cant, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_BalanceoStaf WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_BalanceoStaf(BalanceoId,renglon,Descripcion,cant,RowGuid) VALUES (@BalanceoId,@renglon,@Descripcion,@cant,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("BalanceoId", BalanceoId);
            cmdInsert.Parameters.AddWithValue("renglon", renglon);
            cmdInsert.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdInsert.Parameters.AddWithValue("cant", cant);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_BalanceoStaf SET renglon=@renglon,Descripcion=@Descripcion,cant=@Cant WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("renglon", renglon);
            cmdUpdate.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdUpdate.Parameters.AddWithValue("cant", cant);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_BalanceoStaf WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }


        //T_Bitacora
        public static string SincronizaT_Bitacora(decimal BitacoraId, int? UsuarioId, DateTime? Fecha, DateTime? Hora, string Descripcion, string RowGuid)
        {

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_Bitacora WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_Bitacora(BitacoraId,UsuarioId,Fecha,Hora,Descripción,RowGuid) VALUES (@BitacoraId,@UsuarioId,@Fecha,@Hora,@Descripcion,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("BitacoraId", BitacoraId);
            cmdInsert.Parameters.AddWithValue("UsuarioId", UsuarioId);
            cmdInsert.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdInsert.Parameters.AddWithValue("Fecha", Fecha);
            cmdInsert.Parameters.AddWithValue("Hora", Hora);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_Bitacora SET UsuarioId=@UsuarioId,Fecha=@Fecha,Hora=@Hora,Descripción=@Descripcion WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("UsuarioId", UsuarioId);
            cmdUpdate.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdUpdate.Parameters.AddWithValue("Fecha", Fecha);
            cmdUpdate.Parameters.AddWithValue("Hora", Hora);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_Bitacora WHERE RowGuid=@RowGuid");
            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));


        }

        //T_Bultos
        public static string SincronizaT_Bultos(decimal BultoId, decimal? NoBulto, string Serie, int? OrdenId, int? Cantidad, DateTime? FechaEnt, decimal? TallaId, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_Bultos WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_Bultos(BultoId,NoBulto,Serie,OrdenId,Cantidad,FechaEnt,TallaId,RowGuid) VALUES (@BultoId,@NoBulto,@Serie,@OrdenId,@Cantidad,@FechaEnt,@TallaId,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("BultoId", BultoId);
            cmdInsert.Parameters.AddWithValue("NoBulto", NoBulto);
            cmdInsert.Parameters.AddWithValue("Serie", Serie);
            cmdInsert.Parameters.AddWithValue("OrdenId", OrdenId);
            cmdInsert.Parameters.AddWithValue("Cantidad", Cantidad);
            cmdInsert.Parameters.AddWithValue("FechaEnt", FechaEnt);
            cmdInsert.Parameters.AddWithValue("TallaId", TallaId);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_Bultos SET NoBulto=@NoBulto,Serie=@Serie,OrdenId=@OrdenId,Cantidad=@Cantidad,FechaEnt=@FechaEnt,Tallaid=@TallaId WHERE RowGuid=@RowGuid");

            cmdUpdate.Parameters.AddWithValue("NoBulto", NoBulto);
            cmdUpdate.Parameters.AddWithValue("Serie", Serie);
            cmdUpdate.Parameters.AddWithValue("OrdenId", OrdenId);
            cmdUpdate.Parameters.AddWithValue("Cantidad", Cantidad);
            cmdUpdate.Parameters.AddWithValue("FechaEnt", FechaEnt);
            cmdUpdate.Parameters.AddWithValue("TallaId", TallaId);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_Bultos WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //T_CostosMonedas
        public static string SincronizaT_CostosMonedas(decimal ArticuloId, decimal? AlmacenId, decimal? MonedaId, decimal? Existencia, decimal? EntradaUnidad, decimal? EntradaValor,
            decimal SalidaUnidad, decimal? SalidaValor, decimal? ExtDum, decimal? CostoPromedio, decimal? CostoReposicion, string RowGuid)
        {

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_CostosMonedas WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_CostosMonedas (ArticuloId,AlmacenId,MonedaId,Existencia,EntradaUnidad,EntradaValor,SalidaUnidad,SalidaValor,ExtDum,CostoPromedio,CostoReposicion,RowGuid) " +
            "VALUES (@ArticuloId,@AlmacenId,@MonedaId,@Existencia,@EntradaUnidad,@EntradaValor,@SalidaUnidad,@SalidaValor,@ExtDum,@CostoPromedio,@CostoReposicion,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("ArticuloId", ArticuloId);
            cmdInsert.Parameters.AddWithValue("AlmacenId", AlmacenId);
            cmdInsert.Parameters.AddWithValue("MonedaId", MonedaId);
            cmdInsert.Parameters.AddWithValue("Existencia", Existencia);
            cmdInsert.Parameters.AddWithValue("EntradaUnidad", EntradaUnidad);
            cmdInsert.Parameters.AddWithValue("EntradaValor", EntradaValor);
            cmdInsert.Parameters.AddWithValue("SalidaUnidad", SalidaUnidad);
            cmdInsert.Parameters.AddWithValue("SalidaValor", SalidaValor);
            cmdInsert.Parameters.AddWithValue("ExtDum", ExtDum);
            cmdInsert.Parameters.AddWithValue("CostoPromedio", CostoPromedio);
            cmdInsert.Parameters.AddWithValue("CostoReposicion", CostoReposicion);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_CostosMonedas SET AlmacenId=@AlmacenId,MonedaId=@MonedaId,Existencia=@Existencia,EntradaUnidad=@EntradaUnidad,EntradaValor=@EntradaValor,SalidaUnidad=@SalidaUnidad," +
            "SalidaValor=@SalidaValor,ExtDum=@ExtDum,CostoPromedio=@CostoPromedio,CostoReposicion=@CostoReposicion WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("AlmacenId", AlmacenId);
            cmdUpdate.Parameters.AddWithValue("MonedaId", MonedaId);
            cmdUpdate.Parameters.AddWithValue("Existencia", Existencia);
            cmdUpdate.Parameters.AddWithValue("EntradaUnidad", EntradaUnidad);
            cmdUpdate.Parameters.AddWithValue("EntradaValor", EntradaValor);
            cmdUpdate.Parameters.AddWithValue("SalidaUnidad", SalidaUnidad);
            cmdUpdate.Parameters.AddWithValue("SalidaValor", SalidaValor);
            cmdUpdate.Parameters.AddWithValue("ExtDum", ExtDum);
            cmdUpdate.Parameters.AddWithValue("CostoPromedio", CostoPromedio);
            cmdUpdate.Parameters.AddWithValue("CostoReposicion", CostoReposicion);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_CostosMonedas WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //T_Cotizacion
        public static string SincronizaT_Cotizacion(decimal CotizacionId, decimal? EstiloId, string Observaciones, DateTime? FechaCreacion, DateTime? FechaModificacion, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_Cotizacion WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_Cotizacion(CotizacionId,EstiloId,Observaciones,FechaCreacion,FechaModificacion,RowGuid) " +
            "VALUES(@CotizacionId,@EstiloId,@Observaciones,@FechaCreacion,@FechaModificacion,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("CotizacionId",CotizacionId);
            cmdInsert.Parameters.AddWithValue("EstiloId",EstiloId);
            cmdInsert.Parameters.AddWithValue("Observaciones",Observaciones);
            cmdInsert.Parameters.AddWithValue("FechaCreacion",FechaCreacion);
            cmdInsert.Parameters.AddWithValue("FechaModificacion",FechaModificacion);
            cmdInsert.Parameters.AddWithValue("RowGuid",RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_Cotizacion SET EstiloId=@EstiloId,Observaciones=@Observaciones,FechaCreacion=@FechaCreacion,FechaModificacion=@FechaModificacion " +
            "WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("EstiloId", EstiloId);
            cmdUpdate.Parameters.AddWithValue("Observaciones", Observaciones);
            cmdUpdate.Parameters.AddWithValue("FechaCreacion", FechaCreacion);
            cmdUpdate.Parameters.AddWithValue("FechaModificacion", FechaModificacion);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_Cotizacion WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));


        }

        //T_CotizacionDet
        public static string SincronizaT_CotizacionDet(decimal CotizacionId, decimal? Renglon, int? Equivalencia,int? HiloId, string Aplic, string Cod, decimal? Metros,decimal? Costo, 
           decimal? Total, decimal? TotalConos ,decimal? MtsCono, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_CotizacionDet WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_CotizacionDet (CotizacionId,Renglon,Equivalencia,HiloId,Aplic,Cod,Metros,Costo,Total,TotalConos,MtsCono,RowGuid) " +
           "VALUES(@CotizacionId,@Renglon,@Equivalencia,@HiloId,@Aplic,@Cod,@Metros,@Costo,@Total,@TotalConos,@MtsCono,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("CotizacionId",CotizacionId);
            cmdInsert.Parameters.AddWithValue("Renglon",Renglon);
            cmdInsert.Parameters.AddWithValue("Equivalencia",Equivalencia);
            cmdInsert.Parameters.AddWithValue("HiloId",HiloId);
            cmdInsert.Parameters.AddWithValue("Aplic",Aplic);
            cmdInsert.Parameters.AddWithValue("Cod",Cod);
            cmdInsert.Parameters.AddWithValue("Metros",Metros);
            cmdInsert.Parameters.AddWithValue("Costo",Costo);
            cmdInsert.Parameters.AddWithValue("Total",Total);
            cmdInsert.Parameters.AddWithValue("TotalConos",TotalConos);
            cmdInsert.Parameters.AddWithValue("MtsCono",MtsCono);
            cmdInsert.Parameters.AddWithValue("RowGuid",RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_CotizacionDet SET Renglon=@Renglon,Equivalencia=@Equivalencia,HiloId=@HiloId,Aplic=@Aplic,Cod=@Cod,Metros=@Metros,Costo=@Costo,Total=@Total," +
            "TotalConos=@TotalConos,MtsCono=@MtsCono WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Renglon", Renglon);
            cmdUpdate.Parameters.AddWithValue("Equivalencia", Equivalencia);
            cmdUpdate.Parameters.AddWithValue("HiloId", HiloId);
            cmdUpdate.Parameters.AddWithValue("Aplic", Aplic);
            cmdUpdate.Parameters.AddWithValue("Cod", Cod);
            cmdUpdate.Parameters.AddWithValue("Metros", Metros);
            cmdUpdate.Parameters.AddWithValue("Costo", Costo);
            cmdUpdate.Parameters.AddWithValue("Total", Total);
            cmdUpdate.Parameters.AddWithValue("TotalConos", TotalConos);
            cmdUpdate.Parameters.AddWithValue("MtsCono", MtsCono);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_CotizacionDet WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //T_Estilos
        public static string SincronizaT_Estilos(decimal EstiloId, string Num, string Descripcion, DateTime? FechaAlta, int? Inactivo, DateTime? FechaBaja, string Linea, string Division,
          string Cliente, string Observacion, int? num_metadia, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_Estilos WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_Estilos (EstiloId,Num,Descripcion,FechaAlta,Inactivo,FechaBaja,Linea,Division,Cliente,Observacion,num_metadia,RowGuid) " +
            "VALUES(@EstiloId,@Num,@Descripcion,@FechaAlta,@Inactivo,@FechaBaja,@Linea,@Division,@Cliente,@Observacion,@num_metadia,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("EstiloId",EstiloId);
            cmdInsert.Parameters.AddWithValue("Num",Num);
            cmdInsert.Parameters.AddWithValue("Descripcion",Descripcion);
            cmdInsert.Parameters.AddWithValue("FechaAlta",FechaAlta);
            cmdInsert.Parameters.AddWithValue("Inactivo",Inactivo);
            cmdInsert.Parameters.AddWithValue("FechaBaja",FechaBaja);
            cmdInsert.Parameters.AddWithValue("Linea",Linea);
            cmdInsert.Parameters.AddWithValue("Division",Division);
            cmdInsert.Parameters.AddWithValue("Cliente",Cliente);
            cmdInsert.Parameters.AddWithValue("Observacion",Observacion);
            cmdInsert.Parameters.AddWithValue("num_metadia",num_metadia);
            cmdInsert.Parameters.AddWithValue("RowGuid",RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_Estilos  SET Num=@Num,Descripcion=@Descripcion,FechaAlta=@FechaAlta,Inactivo=@Inactivo,FechaBaja=@FechaBaja,Linea=@Linea,Division=@Division," +
            "Cliente=@Cliente,Observacion=@Observacion,num_metadia=@num_metadia WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Num", Num);
            cmdUpdate.Parameters.AddWithValue("Descripcion", Descripcion);
            cmdUpdate.Parameters.AddWithValue("FechaAlta", FechaAlta);
            cmdUpdate.Parameters.AddWithValue("Inactivo", Inactivo);
            cmdUpdate.Parameters.AddWithValue("FechaBaja", FechaBaja);
            cmdUpdate.Parameters.AddWithValue("Linea", Linea);
            cmdUpdate.Parameters.AddWithValue("Division", Division);
            cmdUpdate.Parameters.AddWithValue("Cliente", Cliente);
            cmdUpdate.Parameters.AddWithValue("Observacion", Observacion);
            cmdUpdate.Parameters.AddWithValue("num_metadia", num_metadia);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_Estilos WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //T_EstilosDet
        public static string SincronizaT_EstilosDet(decimal EstiloId, decimal? Renglon, int? OperacionId, int? Orden, int? Act, int? OrdenRpt, string Lado, string Etapa, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_EstilosDet WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_EstilosDet(EstiloId,Renglon,OperacionId,Orden,Act,OrdenRpt,Lado,Etapa,RowGuid)" +
            "VALUES(@EstiloId,@Renglon,@OperacionId,@Orden,@Act,@OrdenRpt,@Lado,@Etapa,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("EstiloId",EstiloId);
            cmdInsert.Parameters.AddWithValue("Renglon",Renglon);
            cmdInsert.Parameters.AddWithValue("OperacionId",OperacionId);
            cmdInsert.Parameters.AddWithValue("Orden",Orden);
            cmdInsert.Parameters.AddWithValue("Act",Act);
            cmdInsert.Parameters.AddWithValue("OrdenRpt",OrdenRpt);
            cmdInsert.Parameters.AddWithValue("Lado",Lado);
            cmdInsert.Parameters.AddWithValue("Etapa",Etapa);
            cmdInsert.Parameters.AddWithValue("RowGuid",RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_EstilosDet  SET  Renglon=@Renglon,OperacionId=@OperacionId,Orden=@Orden,Act=@Act,OrdenRpt=@OrdenRpt,Lado=@Lado,Etapa=@Etapa " +
            "WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Renglon", Renglon);
            cmdUpdate.Parameters.AddWithValue("OperacionId", OperacionId);
            cmdUpdate.Parameters.AddWithValue("Orden", Orden);
            cmdUpdate.Parameters.AddWithValue("Act", Act);
            cmdUpdate.Parameters.AddWithValue("OrdenRpt", OrdenRpt);
            cmdUpdate.Parameters.AddWithValue("Lado", Lado);
            cmdUpdate.Parameters.AddWithValue("Etapa", Etapa);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_EstilosDet WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //T_EstilosDetTeor
        public static string SincronizaT_EstilosDetTeor(decimal EstiloId, decimal? Renglon, int? OperacionId, int? Orden, int? Act, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_EstilosDetTeor WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_EstilosDetTeor(EstiloId,Renglon,OperacionId,Orden,Act,RowGuid)" +
            "VALUES(@EstiloId,@Renglon,@OperacionId,@Orden,@Act,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("EstiloId", EstiloId);
            cmdInsert.Parameters.AddWithValue("Renglon", Renglon);
            cmdInsert.Parameters.AddWithValue("OperacionId", OperacionId);
            cmdInsert.Parameters.AddWithValue("Orden", Orden);
            cmdInsert.Parameters.AddWithValue("Act", Act);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_EstilosDetTeor SET Renglon=@Renglon,OperacionId=@OperacionId,Orden=@Orden,Act=@Act WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Renglon", Renglon);
            cmdUpdate.Parameters.AddWithValue("OperacionId", OperacionId);
            cmdUpdate.Parameters.AddWithValue("Orden", Orden);
            cmdUpdate.Parameters.AddWithValue("Act", Act);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_EstilosDetTeor WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }


        //T_EstilosHilosDet
        public static string SincronizaT_EstilosHilosDet(decimal EstiloId, decimal? Renglon, int? Orden, int? HiloId, int? Arriba, int? Act, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_EstilosHilosDet WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_EstilosHilosDet(EstiloId,Renglon,Orden,HiloId,Arriba,Act,RowGuid)" +
            "VALUES(@EstiloId,@Renglon,@Orden,@HiloId,@Arriba,@Act,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("EstiloId", EstiloId);
            cmdInsert.Parameters.AddWithValue("Renglon", Renglon);
            cmdInsert.Parameters.AddWithValue("Orden", Orden);
            cmdInsert.Parameters.AddWithValue("HiloId", HiloId);
            cmdInsert.Parameters.AddWithValue("Arriba", Arriba);
            cmdInsert.Parameters.AddWithValue("Act", Act);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_EstilosHilosDet SET Renglon=@Renglon,Orden=@Orden,HiloId=@HiloId,Arriba=@Arriba,Act=@Act WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Renglon", Renglon);
            cmdUpdate.Parameters.AddWithValue("Orden", Orden);
            cmdUpdate.Parameters.AddWithValue("HiloId", HiloId);
            cmdUpdate.Parameters.AddWithValue("Arriba", Arriba);
            cmdUpdate.Parameters.AddWithValue("Act", Act);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_EstilosHilosDet WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }


        //T_EstilosHilosDetTeor
        public static string SincronizaT_EstilosHilosDetTeor(decimal EstiloId, decimal? Renglon, int? Orden, int? HiloId, int? Arriba, int? Act, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_EstilosHilosDetTeor WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_EstilosHilosDetTeor(EstiloId,Renglon,Orden,HiloId,Arriba,Act,RowGuid)" +
            "VALUES(@EstiloId,@Renglon,@Orden,@HiloId,@Arriba,@Act,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("EstiloId", EstiloId);
            cmdInsert.Parameters.AddWithValue("Renglon", Renglon);
            cmdInsert.Parameters.AddWithValue("Orden", Orden);
            cmdInsert.Parameters.AddWithValue("HiloId", HiloId);
            cmdInsert.Parameters.AddWithValue("Arriba", Arriba);
            cmdInsert.Parameters.AddWithValue("Act", Act);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_EstilosHilosDetTeor SET Renglon=@Renglon,Orden=@Orden,HiloId=@HiloId,Arriba=@Arriba,Act=@Act WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Renglon", Renglon);
            cmdUpdate.Parameters.AddWithValue("Orden", Orden);
            cmdUpdate.Parameters.AddWithValue("HiloId", HiloId);
            cmdUpdate.Parameters.AddWithValue("Arriba", Arriba);
            cmdUpdate.Parameters.AddWithValue("Act", Act);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_EstilosHilosDetTeor WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }


        //T_EstilosMarcas
        public static string SincronizaT_EstilosMarcas(int EstiloId, string MarcaId , string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_EstilosMarcas WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_EstilosMarcas(EstiloId,MarcaId,RowGuid)" +
            "VALUES(@EstiloId,@MarcaId,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("EstiloId", EstiloId);
            cmdInsert.Parameters.AddWithValue("MarcaId", MarcaId);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_EstilosMarcas SET MarcaId=@MarcaId WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("MarcaId",MarcaId);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_EstilosMarcas WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //T_EtiqFecPag
        public static string SincronizaT_EtiqFecPag(decimal EtiquetaId, DateTime? FechaPago, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_EtiqFecPag WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_EtiqFecPag(EtiquetaId,FechaPago,RowGuid) VALUES(@EtiquetaId, @FechaPago, @RowGuid)");
            cmdInsert.Parameters.AddWithValue("EtiquetaId", EtiquetaId);
            cmdInsert.Parameters.AddWithValue("FechaPago", FechaPago);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_EtiqFecPag SET FechaPago=@FechaPago WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("FechaPago", FechaPago);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_EtiqFecPag WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }


        //T_Etiquetas
        public static string SincronizaT_Etiquetas(decimal EtiquetaId,decimal? BultoId,int? OperacionId ,int? EstiloId,int? Renglon, int? PersonalId, DateTime? Fecha, DateTime? Hora,
                decimal? HojaId, int? Escaneada, int? Cancelada, string RowGuid)
        {

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_Etiquetas WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_Etiquetas(EtiquetaId,BultoId,OperacionId,EstiloId,Renglon,PersonalId,Fecha,Hora,HojaId,Escaneada,Cancelada,RowGuid)" +
            "VALUES(@EtiquetaId,@BultoId,@OperacionId,@EstiloId,@Renglon,@PersonalId,@Fecha,@Hora,@HojaId,@Escaneada,@Cancelada,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("EtiquetaId",EtiquetaId);
             cmdInsert.Parameters.AddWithValue("BultoId",BultoId);
             cmdInsert.Parameters.AddWithValue("OperacionId",OperacionId);
             cmdInsert.Parameters.AddWithValue("EstiloId",EstiloId);
             cmdInsert.Parameters.AddWithValue("Renglon",Renglon);
             cmdInsert.Parameters.AddWithValue("PersonalId",PersonalId);
             cmdInsert.Parameters.AddWithValue("Fecha",Fecha);
             cmdInsert.Parameters.AddWithValue("Hora",Hora);
             cmdInsert.Parameters.AddWithValue("HojaId",HojaId);
             cmdInsert.Parameters.AddWithValue("Escaneada",Escaneada);
             cmdInsert.Parameters.AddWithValue("Cancelada",Cancelada);
             cmdInsert.Parameters.AddWithValue("RowGuid",RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_Etiquetas SET BultoId=@BultoId,OperacionId=@OperacionId,EstiloId=@EstiloId,Renglon=@Renglon,PersonalId=@PersonalId,Fecha=@Fecha," +
            "Hora=@Hora,HojaId=@HojaId,Escaneada=@Escaneada,Cancelada=@Cancelada WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("BultoId", BultoId);
            cmdUpdate.Parameters.AddWithValue("OperacionId", OperacionId);
            cmdUpdate.Parameters.AddWithValue("EstiloId", EstiloId);
            cmdUpdate.Parameters.AddWithValue("Renglon", Renglon);
            cmdUpdate.Parameters.AddWithValue("PersonalId", PersonalId);
            cmdUpdate.Parameters.AddWithValue("Fecha", Fecha);
            cmdUpdate.Parameters.AddWithValue("Hora", Hora);
            cmdUpdate.Parameters.AddWithValue("HojaId", HojaId);
            cmdUpdate.Parameters.AddWithValue("Escaneada", Escaneada);
            cmdUpdate.Parameters.AddWithValue("Cancelada", Cancelada);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_Etiquetas WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //T_Folios
        public static string SincronizaT_Folios(decimal Folio, string Tipo, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_Folios WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_Folios(Folio,Tipo,RowGuid) VALUES(@Folio,@Tipo,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("Folio", Folio);
            cmdInsert.Parameters.AddWithValue("Tipo", Tipo);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_Folios SET Folio=@Folio WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Folio", Folio);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_Folios WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //T_HojasControl
        public static string SincronizaT_HojasControl(decimal HojaId, int? PersonalId,DateTime? Fecha, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_HojasControl WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_HojasControl(HojaId,PersonalId,Fecha,RowGuid) VALUES(@HojaId,@PersonalId,@Fecha,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("HojaId", HojaId);
            cmdInsert.Parameters.AddWithValue("PersonalId", PersonalId);
            cmdInsert.Parameters.AddWithValue("Fecha", Fecha);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_HojasControl SET HojaId=@HojaId, Fecha=@Fecha WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("HojaId", HojaId);
            cmdUpdate.Parameters.AddWithValue("Fecha", Fecha);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_HojasControl WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }


        //T_Inventario
        public static string SincronizaT_Inventario(decimal ArticuloId, decimal? AlmacenId, decimal? Existencia, decimal? EntradaUnidad, decimal? EntradaValor, decimal? SalidaUnidad, decimal? SalidaValor, decimal? ExtDum,
                decimal CostoPromedio, decimal? CostoReposicion, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_Inventario WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_Inventario(ArticuloId,AlmacenId,Existencia,EntradaUnidad,EntradaValor,SalidaUnidad,SalidaValor,ExtDum,CostoPromedio,CostoReposicion,RowGuid)" +
            "VALUES(@ArticuloId,@AlmacenId,@Existencia,@EntradaUnidad,@EntradaValor,@SalidaUnidad,@SalidaValor,@ExtDum,@CostoPromedio,@CostoReposicion,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("ArticuloId", ArticuloId);
            cmdInsert.Parameters.AddWithValue("AlmacenId", AlmacenId);
            cmdInsert.Parameters.AddWithValue("Existencia", Existencia);
            cmdInsert.Parameters.AddWithValue("EntradaUnidad", EntradaUnidad);
            cmdInsert.Parameters.AddWithValue("EntradaValor", EntradaValor);
            cmdInsert.Parameters.AddWithValue("SalidaUnidad", SalidaUnidad);
            cmdInsert.Parameters.AddWithValue("SalidaValor", SalidaValor);
            cmdInsert.Parameters.AddWithValue("ExtDum", ExtDum);
            cmdInsert.Parameters.AddWithValue("CostoPromedio", CostoPromedio);
            cmdInsert.Parameters.AddWithValue("CostoReposicion", CostoReposicion);            
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_Inventario SET AlmacenId=@AlmacenId,Existencia=@Existencia,EntradaUnidad=@EntradaUnidad,EntradaValor=@EntradaValor, " +
            "SalidaUnidad=@SalidaUnidad,SalidaValor=@SalidaValor,ExtDum=@ExtDum,CostoPromedio=@CostoPromedio,CostoReposicion=@CostoReposicion WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("AlmacenId", AlmacenId);
            cmdUpdate.Parameters.AddWithValue("Existencia", Existencia);
            cmdUpdate.Parameters.AddWithValue("EntradaUnidad", EntradaUnidad);
            cmdUpdate.Parameters.AddWithValue("EntradaValor", EntradaValor);
            cmdUpdate.Parameters.AddWithValue("SalidaUnidad", SalidaUnidad);
            cmdUpdate.Parameters.AddWithValue("SalidaValor", SalidaValor);
            cmdUpdate.Parameters.AddWithValue("ExtDum", ExtDum);
            cmdUpdate.Parameters.AddWithValue("CostoPromedio", CostoPromedio);
            cmdUpdate.Parameters.AddWithValue("CostoReposicion", CostoReposicion);            
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_Inventario WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }


        //T_MantoMaq
        public static string SincronizaT_MantoMaq(decimal MantoId, int? MaquinariaId, string Fecha, string Motivo, decimal? Total, int? Tipo,int? Cancelado, decimal? MotCancelado,
                DateTime? FechaCancel, decimal? MonedaId, decimal? TipoCambio, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_MantoMaq WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_MantoMaq(MantoId,MaquinariaId,Fecha,Motivo,Total,Tipo,Cancelado,MotCancelado,FechaCancel,MonedaId,TipoCambio,RowGuid)" +
            "VALUES(@MantoId,@MaquinariaId,@Fecha,@Motivo,@Total,@Tipo,@Cancelado,@MotCancelado,@FechaCancel,@MonedaId,@TipoCambio,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("MantoId", MantoId);
            cmdInsert.Parameters.AddWithValue("MaquinariaId", MaquinariaId);
            cmdInsert.Parameters.AddWithValue("Fecha", Fecha);
            cmdInsert.Parameters.AddWithValue("Motivo", Motivo);
            cmdInsert.Parameters.AddWithValue("Total", Total);
            cmdInsert.Parameters.AddWithValue("Tipo", Tipo);
            cmdInsert.Parameters.AddWithValue("Cancelado", Cancelado);
            cmdInsert.Parameters.AddWithValue("MotCancelado", MotCancelado);
            cmdInsert.Parameters.AddWithValue("FechaCancel", FechaCancel);
            cmdInsert.Parameters.AddWithValue("MonedaId", MonedaId);
            cmdInsert.Parameters.AddWithValue("TipoCambio", TipoCambio);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_MantoMaq SET MaquinariaId=@MaquinariaId,Fecha=@Fecha,Motivo=@Motivo,Total=@Total,Tipo=@Tipo,Cancelado=@Cancelado," +
            "MotCancelado=@MotCancelado,FechaCancel=@FechaCancel,MonedaId=@MonedaId,TipoCambio=@TipoCambio WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("MaquinariaId", MaquinariaId);
            cmdUpdate.Parameters.AddWithValue("Fecha",Fecha);
            cmdUpdate.Parameters.AddWithValue("Motivo", Motivo);
            cmdUpdate.Parameters.AddWithValue("Total", Total);
            cmdUpdate.Parameters.AddWithValue("Tipo", Tipo);
            cmdUpdate.Parameters.AddWithValue("Cancelado", Cancelado);
            cmdUpdate.Parameters.AddWithValue("MotCancelado", MotCancelado);
            cmdUpdate.Parameters.AddWithValue("FechaCancel", FechaCancel);
            cmdUpdate.Parameters.AddWithValue("MonedaId", MonedaId);
            cmdUpdate.Parameters.AddWithValue("TipoCambio", TipoCambio);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_MantoMaq WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }


        //T_MantoMaqDet
        public static string SincronizaT_MantoMaqDet(decimal MantoId, int? Renglon, decimal? Cantidad, decimal? RefaccionId, decimal? Costo, decimal? CostoPesos, decimal? TipoCambio, 
            string Observacion, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_MantoMaqDet WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_MantoMaqDet(MantoId,Renglon,Cantidad,RefaccionId,Costo,CostoPesos,TipoCambio,Observacion,RowGuid)" +
            "VALUES(@MantoId,@Renglon,@Cantidad,@RefaccionId,@Costo,@CostoPesos,@TipoCambio,@Observacion,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("MantoId", MantoId);
            cmdInsert.Parameters.AddWithValue("Renglon", Renglon);
            cmdInsert.Parameters.AddWithValue("Cantidad", Cantidad);
            cmdInsert.Parameters.AddWithValue("RefaccionId", RefaccionId);
            cmdInsert.Parameters.AddWithValue("Costo", Costo);
            cmdInsert.Parameters.AddWithValue("CostoPesos", CostoPesos);
            cmdInsert.Parameters.AddWithValue("TipoCambio", TipoCambio);
            cmdInsert.Parameters.AddWithValue("Observacion", Observacion);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_MantoMaqDet SET Renglon=@Renglon,Cantidad=@Cantidad,RefaccionId=@RefaccionId,Costo=@Costo,CostoPesos=@CostoPesos,TipoCambio=@TipoCambio," +
            "Observacion=@Observacion WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Renglon", Renglon);
            cmdUpdate.Parameters.AddWithValue("Cantidad", Cantidad);
            cmdUpdate.Parameters.AddWithValue("RefaccionId", RefaccionId);
            cmdUpdate.Parameters.AddWithValue("Costo", Costo);
            cmdUpdate.Parameters.AddWithValue("CostoPesos", CostoPesos);
            cmdUpdate.Parameters.AddWithValue("TipoCambio", TipoCambio);
            cmdUpdate.Parameters.AddWithValue("Observacion", Observacion);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_MantoMaqDet WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }



        //T_MovimientosAlm
        public static string SincronizaT_MovimientosAlm(decimal MovimientoId, string Tipo, decimal? AlmacenId, DateTime? Fecha, string Referencia, decimal? TotalU, decimal? TotalC, decimal? MonedaId,
                decimal? TotalCDef, int? Cancelado,int? Aplicado, decimal? TipoCambio, string RowGuid)
        {

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_MovimientosAlm WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_MovimientosAlm(MovimientoId,Tipo,AlmacenId,Fecha,Referencia,TotalU,TotalC,MonedaId,TotalCDef,Cancelado,Aplicado,TipoCambio,RowGuid)" +
            "VALUES(@MovimientoId,@Tipo,@AlmacenId,@Fecha,@Referencia,@TotalU,@TotalC,@MonedaId,@TotalCDef,@Cancelado,@Aplicado,@TipoCambio,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("MovimientoId", MovimientoId);
            cmdInsert.Parameters.AddWithValue("Tipo", Tipo);
            cmdInsert.Parameters.AddWithValue("AlmacenId", AlmacenId);
            cmdInsert.Parameters.AddWithValue("Fecha", Fecha);
            cmdInsert.Parameters.AddWithValue("Referencia", Referencia);
            cmdInsert.Parameters.AddWithValue("TotalU", TotalU);
            cmdInsert.Parameters.AddWithValue("TotalC", TotalC);
            cmdInsert.Parameters.AddWithValue("MonedaId", MonedaId);
            cmdInsert.Parameters.AddWithValue("TotalCDef", TotalCDef);
            cmdInsert.Parameters.AddWithValue("Cancelado", Cancelado);
            cmdInsert.Parameters.AddWithValue("Aplicado", Aplicado);
            cmdInsert.Parameters.AddWithValue("TipoCambio", TipoCambio);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_MovimientosAlm SET Tipo=@Tipo,AlmacenId=@AlmacenId,Fecha=@Fecha,Referencia=@Referencia,TotalU=@TotalU,TotalC=@TotalC," +
            "MonedaId=@MonedaId,TotalCDef=@TotalCDef,Cancelado=@Cancelado,Aplicado=@Aplicado,TipoCambio=@TipoCambio WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Tipo", Tipo);
            cmdUpdate.Parameters.AddWithValue("AlmacenId", AlmacenId);
            cmdUpdate.Parameters.AddWithValue("Fecha", Fecha);
            cmdUpdate.Parameters.AddWithValue("Referencia", Referencia);
            cmdUpdate.Parameters.AddWithValue("TotalU", TotalU);
            cmdUpdate.Parameters.AddWithValue("TotalC", TotalC);
            cmdUpdate.Parameters.AddWithValue("MonedaId", MonedaId);
            cmdUpdate.Parameters.AddWithValue("TotalCDef", TotalCDef);
            cmdUpdate.Parameters.AddWithValue("Cancelado", Cancelado);
            cmdUpdate.Parameters.AddWithValue("Aplicado", Aplicado);
            cmdUpdate.Parameters.AddWithValue("TipoCambio", TipoCambio);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_MovimientosAlm WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }


        //T_MovimientosAlmacenDet
        public static string SincronizaT_MovimientosAlmacenDet(decimal MovimientoId, string Tipo, decimal? Renglon, decimal? ArticuloId, decimal? Cantidad, decimal? Costo, decimal? Importe,string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_MovimientosAlmacenDet WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_MovimientosAlmacenDet(MovimientoId,Tipo,Renglon,ArticuloId,Cantidad,Costo,Importe,RowGuid)" +
            "VALUES(@MovimientoId,@Tipo,@Renglon,@ArticuloId,@Cantidad,@Costo,@Importe,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("MovimientoId", MovimientoId);
            cmdInsert.Parameters.AddWithValue("Tipo", Tipo);
            cmdInsert.Parameters.AddWithValue("Renglon", Renglon);
            cmdInsert.Parameters.AddWithValue("ArticuloId", ArticuloId);
            cmdInsert.Parameters.AddWithValue("Cantidad", Cantidad);
            cmdInsert.Parameters.AddWithValue("Costo", Costo);
            cmdInsert.Parameters.AddWithValue("Importe", Importe);            
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_MovimientosAlmacenDet SET Tipo=@Tipo,Renglon=@Renglon,ArticuloId=@ArticuloId,Cantidad=@Cantidad, " +
            "Costo=@Costo,Importe=@Importe WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Tipo", Tipo);
            cmdUpdate.Parameters.AddWithValue("Renglon", Renglon);
            cmdUpdate.Parameters.AddWithValue("ArticuloId", ArticuloId);
            cmdUpdate.Parameters.AddWithValue("Cantidad", Cantidad);
            cmdUpdate.Parameters.AddWithValue("Costo", Costo);
            cmdUpdate.Parameters.AddWithValue("Importe", Importe);            
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_MovimientosAlmacenDet WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //T_MovimientosMaquinaria
        public static string SincronizaT_MovimientosMaquinaria(int MovimientoId, int? MaquinariaId, int? ConceptoId, DateTime? Fecha, int? Origen, int? Destino, string Entrega, string Recibe,
          string Autoriza, string Transportista, string Observaciones,int? Cancelado, DateTime? FechaCancel, string Motivo, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_MovimientosMaquinaria WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_MovimientosMaquinaria (MovimientoId,MaquinariaId,ConceptoId,Fecha,Origen,Destino,Entrega,Recibe,Autoriza,Transportista,Observaciones," +
            "Cancelado,FechaCancel,Motivo,RowGuid) VALUES(@MovimientoId,@MaquinariaId,@ConceptoId,@Fecha,@Origen,@Destino,@Entrega,@Recibe,@Autoriza,@Transportista,@Observaciones," +
            "@Cancelado,@FechaCancel,@Motivo,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("MovimientoId", MovimientoId);
            cmdInsert.Parameters.AddWithValue("MaquinariaId", MaquinariaId);
            cmdInsert.Parameters.AddWithValue("ConceptoId", ConceptoId);
            cmdInsert.Parameters.AddWithValue("Fecha", Fecha);
            cmdInsert.Parameters.AddWithValue("Origen", Origen);
            cmdInsert.Parameters.AddWithValue("Destino", Destino);
            cmdInsert.Parameters.AddWithValue("Entrega", Entrega);
            cmdInsert.Parameters.AddWithValue("Recibe", Recibe);
            cmdInsert.Parameters.AddWithValue("Autoriza", Autoriza);
            cmdInsert.Parameters.AddWithValue("Transportista", Transportista);
            cmdInsert.Parameters.AddWithValue("Observaciones", Observaciones);
            cmdInsert.Parameters.AddWithValue("Cancelado", Cancelado);            
            cmdInsert.Parameters.AddWithValue("FechaCancel", FechaCancel);
            cmdInsert.Parameters.AddWithValue("Motivo", Motivo);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_MovimientosMaquinaria  SET MaquinariaId=@MaquinariaId,ConceptoId=@ConceptoId,Fecha=@Fecha,Origen=@Origen,Destino=@Destino,Entrega=@Entrega,Recibe=@Recibe," +
            "Autoriza=@Autoriza,Transportista=@Transportista,Observaciones=@Observaciones,Cancelado=@Cancelado,FechaCancel=@FechaCancel,Motivo=@Motivo WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("MaquinariaId", MaquinariaId);
            cmdUpdate.Parameters.AddWithValue("ConceptoId", ConceptoId);
            cmdUpdate.Parameters.AddWithValue("Fecha", Fecha);
            cmdUpdate.Parameters.AddWithValue("Origen", Origen);
            cmdUpdate.Parameters.AddWithValue("Destino", Destino);
            cmdUpdate.Parameters.AddWithValue("Entrega", Entrega);
            cmdUpdate.Parameters.AddWithValue("Recibe", Recibe);
            cmdUpdate.Parameters.AddWithValue("Autoriza", Autoriza);
            cmdUpdate.Parameters.AddWithValue("Transportista", Transportista);
            cmdUpdate.Parameters.AddWithValue("Observaciones", Observaciones);
            cmdUpdate.Parameters.AddWithValue("Cancelado", Cancelado);
            cmdUpdate.Parameters.AddWithValue("FechaCancel", FechaCancel);
            cmdUpdate.Parameters.AddWithValue("Motivo", Motivo);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_MovimientosMaquinaria WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }


        //T_Nomina
        public static string SincronizaT_Nomina(decimal NominaId, string Semana, DateTime? FechaInicio, DateTime? FechaFin, DateTime? Fecha, decimal? TotalNomina, int? Cancelado,
          string Motivo, DateTime? FechaCancel, decimal? BalanceoId, string RowGuid)
        {

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_Nomina WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_Nomina (NominaId,Semana,FechaInicio,FechaFin,Fecha,TotalNomina,Cancelado,Motivo,FechaCancel,BalanceoId,RowGuid) " +
            "VALUES(@NominaId,@Semana,@FechaInicio,@FechaFin,@Fecha,@TotalNomina,@Cancelado,@Motivo,@FechaCancel,@BalanceoId,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("NominaId", NominaId);            
            cmdInsert.Parameters.AddWithValue("Semana", Semana);
            cmdInsert.Parameters.AddWithValue("FechaInicio", FechaInicio);
            cmdInsert.Parameters.AddWithValue("FechaFin", FechaFin);
            cmdInsert.Parameters.AddWithValue("Fecha", Fecha);
            cmdInsert.Parameters.AddWithValue("TotalNomina", TotalNomina);
            cmdInsert.Parameters.AddWithValue("Cancelado", Cancelado);
            cmdInsert.Parameters.AddWithValue("Motivo", Motivo);
            cmdInsert.Parameters.AddWithValue("FechaCancel", FechaCancel);
            cmdInsert.Parameters.AddWithValue("BalanceoId", BalanceoId);            
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_Nomina  SET Semana=@Semana,FechaInicio=@FechaInicio,FechaFin=@FechaFin,Fecha=@Fecha,TotalNomina=@TotalNomina,Cancelado=@Cancelado," +
            "Motivo=@Motivo,FechaCancel=@FechaCancel,BalanceoId=@BalanceoId WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Semana", Semana);
            cmdUpdate.Parameters.AddWithValue("FechaInicio", FechaInicio);
            cmdUpdate.Parameters.AddWithValue("FechaFin", FechaFin);
            cmdUpdate.Parameters.AddWithValue("Fecha", Fecha);
            cmdUpdate.Parameters.AddWithValue("TotalNomina", TotalNomina);
            cmdUpdate.Parameters.AddWithValue("Cancelado", Cancelado);
            cmdUpdate.Parameters.AddWithValue("Motivo", Motivo);
            cmdUpdate.Parameters.AddWithValue("FechaCancel", FechaCancel);
            cmdUpdate.Parameters.AddWithValue("BalanceoId", BalanceoId);            
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_Nomina WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //T_NominaDet
        public static string SincronizaT_NominaDet(decimal NominaId, decimal? Renglon, int? PersonalId, int? ConceptoPid, decimal? Importe, decimal? Cantidad, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_NominaDet WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_NominaDet(NominaId,Renglon,PersonalId,ConceptoPid,Importe,Cantidad,RowGuid) VALUES(@NominaId,@Renglon,@PersonalId,@ConceptoPid,@Importe,@Cantidad,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("NominaId", NominaId); 
            cmdInsert.Parameters.AddWithValue("Renglon", Renglon);
            cmdInsert.Parameters.AddWithValue("PersonalId", PersonalId);
            cmdInsert.Parameters.AddWithValue("ConceptoPid", ConceptoPid);
            cmdInsert.Parameters.AddWithValue("Importe", Importe);
            cmdInsert.Parameters.AddWithValue("Cantidad", Cantidad);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_NominaDet SET Renglon=@Renglon,PersonalId=@PersonalId,ConceptoPid=@ConceptoPid,Importe=@Importe,Cantidad=@Cantidad WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Renglon", Renglon);
            cmdUpdate.Parameters.AddWithValue("PersonalId", PersonalId);
            cmdUpdate.Parameters.AddWithValue("ConceptoPid",ConceptoPid);
            cmdUpdate.Parameters.AddWithValue("Importe", Importe);
            cmdUpdate.Parameters.AddWithValue("Cantidad", Cantidad);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_NominaDet WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));


        }


        //T_OrdenesProduccion
        public static string SincronizaT_OrdenesProduccion(int OrdenId, string NoOrden, string NoPo, string OV, DateTime? FechaAlta, decimal? EstiloId, DateTime? FechaCierre,
            DateTime? FechaCancel, int? Cancelado, string Motivo, string Planta, string Tela,DateTime? FechaCorte, int? Total, int? id_periodo, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_OrdenesProduccion WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_OrdenesProduccion(OrdenId,NoOrden,NoPo,OV,FechaAlta,EstiloId,FechaCierre,FechaCancel,Cancelado, " +
            "Motivo,Planta,Tela,FechaCorte,Total,id_periodo,RowGuid) VALUES(@OrdenId,@NoOrden,@NoPo,@OV,@FechaAlta,@EstiloId,@FechaCierre,@FechaCancel,@Cancelado,@Motivo,@Planta," +
            "@Tela,@FechaCorte,@Total,@id_periodo,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("OrdenId", OrdenId);
            cmdInsert.Parameters.AddWithValue("NoOrden", NoOrden);
            cmdInsert.Parameters.AddWithValue("NoPo", NoPo);
            cmdInsert.Parameters.AddWithValue("OV", OV);
            cmdInsert.Parameters.AddWithValue("FechaAlta", FechaAlta);
            cmdInsert.Parameters.AddWithValue("EstiloId", EstiloId);
            cmdInsert.Parameters.AddWithValue("FechaCierre", FechaCierre);            
            cmdInsert.Parameters.AddWithValue("FechaCancel",FechaCancel);
            cmdInsert.Parameters.AddWithValue("Cancelado",Cancelado);
            cmdInsert.Parameters.AddWithValue("Motivo",Motivo);
            cmdInsert.Parameters.AddWithValue("Planta",Planta);
            cmdInsert.Parameters.AddWithValue("Tela",Tela);
            cmdInsert.Parameters.AddWithValue("FechaCorte",FechaCorte);
            cmdInsert.Parameters.AddWithValue("Total",Total);
            cmdInsert.Parameters.AddWithValue("id_periodo",id_periodo);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_OrdenesProduccion SET NoOrden=@NoOrden,NoPo=@NoPo,OV=@OV,FechaAlta=@FechaAlta,EstiloId=@EstiloId,FechaCierre=@FechaCierre," +
            "FechaCancel=@FechaCancel,Cancelado=@Cancelado,Motivo=@Motivo,Planta=@Planta,Tela=@Tela,FechaCorte=@FechaCorte,Total=@Total,id_periodo=@id_periodo WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("NoOrden", NoOrden);
            cmdUpdate.Parameters.AddWithValue("NoPo", NoPo);
            cmdUpdate.Parameters.AddWithValue("OV", OV);
            cmdUpdate.Parameters.AddWithValue("FechaAlta", FechaAlta);
            cmdUpdate.Parameters.AddWithValue("EstiloId", EstiloId);
            cmdUpdate.Parameters.AddWithValue("FechaCierre", FechaCierre);            
            cmdUpdate.Parameters.AddWithValue("FechaCancel",FechaCancel);
            cmdUpdate.Parameters.AddWithValue("Cancelado",Cancelado);
            cmdUpdate.Parameters.AddWithValue("Motivo", Motivo);
            cmdUpdate.Parameters.AddWithValue("Planta", Planta);
            cmdUpdate.Parameters.AddWithValue("Tela", Tela);
            cmdUpdate.Parameters.AddWithValue("FechaCorte", FechaCorte);
            cmdUpdate.Parameters.AddWithValue("Total", Total);
            cmdUpdate.Parameters.AddWithValue("id_periodo", id_periodo);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_OrdenesProduccion WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //T_OrdEnPlanta
        public static string SincronizaT_OrdEnPlanta(decimal OrdenId, int? Cantidad, DateTime? Fecha, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_OrdEnPlanta WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_OrdEnPlanta(OrdenId,Cantidad,Fecha,RowGuid) VALUES(@OrdenId,@Cantidad,@Fecha,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("OrdenId", OrdenId);
            cmdInsert.Parameters.AddWithValue("Cantidad", Cantidad);
            cmdInsert.Parameters.AddWithValue("Fecha", Fecha);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_OrdEnPlanta SET OrdenId=@OrdenId,Fecha=@Fecha WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("OrdenId", OrdenId);
            cmdUpdate.Parameters.AddWithValue("Fecha", Fecha);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_OrdEnPlanta WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }


            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }


        //T_OrdenProduccionDet
        public static string SincronizaT_OrdenProduccionDet(int OrdenId, int? Renglon, decimal? TallaId, int? NoBultos, int? NPiezasXBulto, string Serie, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_OrdenProduccionDet WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_OrdenProduccionDet(OrdenId,Renglon,TallaId,NoBultos,NPiezasXBulto,Serie,RowGuid) VALUES(@OrdenId,@Renglon,@TallaId,@NoBultos,@NPiezasXBulto,@Serie,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("OrdenId", OrdenId);
            cmdInsert.Parameters.AddWithValue("Renglon", Renglon);
            cmdInsert.Parameters.AddWithValue("TallaId", TallaId);
            cmdInsert.Parameters.AddWithValue("NoBultos", NoBultos);
            cmdInsert.Parameters.AddWithValue("NPiezasXBulto", NPiezasXBulto);
            cmdInsert.Parameters.AddWithValue("Serie", Serie);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_OrdenProduccionDet SET Renglon=@Renglon,TallaId=@TallaId,NoBultos=@NoBultos,NPiezasXBulto=@NPiezasXBulto,Serie=@Serie WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Renglon", Renglon);
            cmdUpdate.Parameters.AddWithValue("TallaId", TallaId);
            cmdUpdate.Parameters.AddWithValue("NoBultos", NoBultos);
            cmdUpdate.Parameters.AddWithValue("NPiezasXBulto", NPiezasXBulto);
            cmdUpdate.Parameters.AddWithValue("Serie", Serie);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_OrdenProduccionDet WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //T_OrdOrdenesProduccion
        public static string SincronizaT_OrdOrdenesProduccion(int OrdenId, int? Orden, string Periodo, int? Auditoria, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_OrdOrdenesProduccion WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_OrdOrdenesProduccion(OrdenId,Orden,Periodo,Auditoria,RowGuid) VALUES(@OrdenId,@Orden,@Periodo,@Auditoria,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("OrdenId", OrdenId);
            cmdInsert.Parameters.AddWithValue("Orden", Orden);
            cmdInsert.Parameters.AddWithValue("Periodo", Periodo);
            cmdInsert.Parameters.AddWithValue("Auditoria", Auditoria);            
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_OrdOrdenesProduccion SET Orden=@Orden,Periodo=@Periodo,Auditoria=@Auditoria WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Orden", Auditoria);
            cmdUpdate.Parameters.AddWithValue("Periodo", Periodo);
            cmdUpdate.Parameters.AddWithValue("Auditoria", Auditoria);            
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_OrdOrdenesProduccion WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //T_Perfil
        public static string SincronizaT_Perfil(int UsuarioId, int? PantallaId, int? Alta, int? Baja, int? Cambio, int? Consulta, int? Depurar,
                int Firma, int? Imprimir, string RowGuid)
        {
            //PerfilId es explicito en la base de datos

            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_Perfil WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_Perfil(UsuarioId,PantallaId,Alta,Baja,Cambio,Consulta,Depurar,Firma,Imprimir,RowGuid)" +
            "VALUES(@UsuarioId,@PantallaId,@Alta,@Baja,@Cambio,@Consulta,@Depurar,@Firma,@Imprimir,@RowGuid)");            
            cmdInsert.Parameters.AddWithValue("UsuarioId", UsuarioId);
            cmdInsert.Parameters.AddWithValue("PantallaId", PantallaId);
            cmdInsert.Parameters.AddWithValue("Alta", Alta);
            cmdInsert.Parameters.AddWithValue("Baja", Baja);
            cmdInsert.Parameters.AddWithValue("Cambio", Cambio);
            cmdInsert.Parameters.AddWithValue("Consulta", Consulta);
            cmdInsert.Parameters.AddWithValue("Depurar", Depurar);
            cmdInsert.Parameters.AddWithValue("Firma", Firma);
            cmdInsert.Parameters.AddWithValue("Imprimir", Imprimir);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_Perfil SET UsuarioId=@UsuarioId,PantallaId=@PantallaId,Alta=@Alta,Baja=@Baja,Cambio=@Cambio,Consulta=@Consulta," +
            "Depurar=@Depurar,Firma=@Firma,Imprimir=@Imprimir WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("UsuarioId", UsuarioId);
            cmdUpdate.Parameters.AddWithValue("PantallaId", PantallaId);
            cmdUpdate.Parameters.AddWithValue("Alta", Alta);
            cmdUpdate.Parameters.AddWithValue("Baja", Baja);
            cmdUpdate.Parameters.AddWithValue("Cambio", Cambio);
            cmdUpdate.Parameters.AddWithValue("Consulta", Consulta);
            cmdUpdate.Parameters.AddWithValue("Depurar", Depurar);
            cmdUpdate.Parameters.AddWithValue("Firma", Firma);
            cmdUpdate.Parameters.AddWithValue("Imprimir", Imprimir);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_Perfil WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }


        //T_PersonalConceptos
        public static string SincronizaT_PersonalConceptos(int ConceptoPid, int? PersonalId, decimal? Importe, int? Cantidad, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_PersonalConceptos WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_PersonalConceptos(ConceptoPid,PersonalId,Importe,Cantidad,RowGuid) " +
            "VALUES(@ConceptoPid,@PersonalId,@Importe,@Cantidad,@RowGuid)");            
            cmdInsert.Parameters.AddWithValue("ConceptoPid", ConceptoPid);
            cmdInsert.Parameters.AddWithValue("Importe", Importe);
            cmdInsert.Parameters.AddWithValue("PersonalId", PersonalId);
            cmdInsert.Parameters.AddWithValue("Cantidad", Cantidad);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_PersonalConceptos SET ConceptoPid=@ConceptoPid,PersonalId=@PersonalId,Importe=@Importe,Cantidad=@Cantidad WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("ConceptoPid", Cantidad);
            cmdUpdate.Parameters.AddWithValue("Importe", Importe);
            cmdUpdate.Parameters.AddWithValue("Cantidad", Cantidad);
            cmdUpdate.Parameters.AddWithValue("PersonalId", PersonalId);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_PersonalConceptos WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }

        //T_PersonalFaltas
        public static string SincronizaT_PersonalFaltas(int PersonalId, string Tipo, DateTime? Fecha, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_PersonalFaltas WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_PersonalFaltas(PersonalId,Tipo,Fecha,RowGuid) VALUES(@PersonalId,@Tipo,@Fecha,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("PersonalId", PersonalId);
            cmdInsert.Parameters.AddWithValue("Tipo", Tipo);
            cmdInsert.Parameters.AddWithValue("Fecha", Fecha);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_PersonalFaltas SET Tipo=@Tipo,Fecha=@Fecha WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("Tipo", Tipo);
            cmdUpdate.Parameters.AddWithValue("Fecha", Fecha);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_PersonalFaltas WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));

        }


        //T_PersonalFechas
        public static string SincronizaT_PersonalFechas(int PersonalId, string Tipo, DateTime? Fecha, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_PersonalFechas WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_PersonalFechas(PersonalId,Tipo,Fecha,RowGuid) VALUES(@PersonalId,@Tipo,@Fecha,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("PersonalId", PersonalId);
            cmdInsert.Parameters.AddWithValue("Tipo", Tipo);
            cmdInsert.Parameters.AddWithValue("Fecha", Fecha);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_PersonalFechas SET Tipo=@Tipo,Fecha=@Fecha WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("TipoId", Tipo);
            cmdUpdate.Parameters.AddWithValue("Fecha", Fecha);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_PersonalFechas WHERE RowGuid=@RowGuid");
            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));


        }

        //T_RegistroCorte
        public static string SincronizaT_RegistroCorte(int Id, int? BihorarioId, DateTime? Fecha, int? OrdenId, int? piezas, string RowGuid)
        {
            RowGuid = string.IsNullOrEmpty(RowGuid) ? Guid.NewGuid().ToString() : RowGuid;

            SqlCommand cmdSelect = new SqlCommand("SELECT COUNT(*) FROM T_RegistroCorte WHERE rowguid=@RowGuid");
            cmdSelect.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO T_RegistroCorte(Id,BihorarioId,Fecha,OrdenId,piezas,RowGuid) VALUES(@Id,@BihorarioId,@Fecha,@OrdenId,@piezas,@RowGuid)");
            cmdInsert.Parameters.AddWithValue("Id", Id);
            cmdInsert.Parameters.AddWithValue("BihorarioId", BihorarioId);
            cmdInsert.Parameters.AddWithValue("Fecha", Fecha);
            cmdInsert.Parameters.AddWithValue("OrdenId",OrdenId);
            cmdInsert.Parameters.AddWithValue("piezas", piezas);
            cmdInsert.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdUpdate = new SqlCommand("UPDATE T_RegistroCorte SET BihorarioId=@BihorarioId,Fecha=@Fecha,OrdenId=@OrdenId,piezas=@piezas WHERE RowGuid=@RowGuid");
            cmdUpdate.Parameters.AddWithValue("BihorarioId", BihorarioId);
            cmdUpdate.Parameters.AddWithValue("Fecha", Fecha);
            cmdUpdate.Parameters.AddWithValue("OrdenId",OrdenId);
            cmdUpdate.Parameters.AddWithValue("piezas", piezas);
            cmdUpdate.Parameters.AddWithValue("RowGuid", RowGuid);

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM T_RegistroCorte WHERE RowGuid=@RowGuid");

            if (IsDelete(ref RowGuid) == false)
            {
                cmdDelete = null;
            }
            else
            {
                cmdDelete.Parameters.AddWithValue("RowGuid", RowGuid);
            }

            return (Comandos.EjectuaQuerys(cmdSelect, cmdInsert, cmdUpdate, cmdDelete));


        }


        //***FIN***//



    }

}












 
 