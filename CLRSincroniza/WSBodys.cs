using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CLRSincroniza
{
    public static class WSBodys
    {
        public static StringBuilder AlmacenSoapBody(int AlmacenID, string Almacen, string Ubicacion, string rowguid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<soap:Body>");
            sb.Append($@"<SincronizarC_Almacen xmlns=""{WSConsts.URI}"">");
            sb.Append($@"<AlmacenId>{AlmacenID}</AlmacenId>");
            sb.Append($@"<Almacen>{Almacen}</Almacen>");
            sb.Append($@"<Ubicacion>{Ubicacion}</Ubicacion>");
            sb.Append($@"<RowGuid>{rowguid}</RowGuid>");
            sb.Append(@"</SincronizarC_Almacen>");
            sb.Append(@"</soap:Body>");

            return sb;
        }

        public static StringBuilder AreaModuloSoapBody(int ModuloId, int AreaId, string rowguid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<soap:Body>");
            sb.Append($@"<SincronizarC_AreaModulo xmlns=""{WSConsts.URI}"">");
            sb.Append($@"<ModuloId>{ModuloId}</ModuloId>");
            sb.Append($@"<AreaId>{AreaId}</AreaId>");
            sb.Append($@"<RowGuid>{rowguid}</RowGuid>");
            sb.Append(@"</SincronizarC_AreaModulo>");
            sb.Append(@"</soap:Body>");

            return sb;
        }

        public static StringBuilder AreasSoapBody(int AreaID, string Descripcion, int Orden, double Bono, string rowguid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<soap:Body>");
            sb.Append($@"<SincronizarC_Areas xmlns=""{WSConsts.URI}"">");
            sb.Append($@"<ModuloId>{AreaID}</ModuloId>");
            sb.Append($@"<Descripcion>{Descripcion}</Descripcion>");
            sb.Append($@"<Orden>{Orden}</Orden>");
            sb.Append($@"<Bono>{Bono}</Bono>");
            sb.Append($@"<RowGuid>{rowguid}</RowGuid>");
            sb.Append(@"</SincronizarC_Areas>");
            sb.Append(@"</soap:Body>");

            return sb;
        }

        public static StringBuilder BiHorarioSoapBody(int BihorarioId, DateTime HoraInicio, DateTime HoraFin, double CantHrsLab, 
                                        DateTime HoraIniReal, DateTime HoraFinReal, DateTime HoraIniRealAnt, DateTime HoraFinRealAnt)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<soap:Body>");
            sb.Append($@"<SincronizaC_Bihorarios xmlns=""{WSConsts.URI}"">");
            sb.Append($@"<BihorarioId>{BihorarioId}</BihorarioId>");
            sb.Append($@"<HoraInicio>{HoraInicio}</HoraInicio>");
            sb.Append($@"<HoraFin>{HoraFin}</HoraFin>");
            sb.Append($@"<CantHrsLab>{CantHrsLab}</CantHrsLab>");
            sb.Append($@"<HoraIniReal>{HoraIniReal}</HoraIniReal>");
            sb.Append($@"<HoraFinReal>{HoraFinReal}</HoraFinReal>");
            sb.Append($@"<HoraIniRealAnt>{HoraIniRealAnt}</HoraIniRealAnt>");
            sb.Append($@"<HoraFinRealAnt>{HoraFinRealAnt}</HoraFinRealAnt>");
            sb.Append(@"</SincronizaC_Bihorarios>");
            sb.Append(@"</soap:Body>");

            return sb;
        }

        public static StringBuilder ArticulosSoapBody(double ArticuloId, double LineaId, double MonedaId, string Clave,
                                        string Descripcion, double Costo, string unidad, string Ubicacion, string rowGuid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<soap:Body>");
            sb.Append($@"<SincronizaC_Articulos xmlns=""{WSConsts.URI}"">");
            sb.Append($@"<ArticuloId>{ArticuloId}</ArticuloId>");
            sb.Append($@"<LineaId>{LineaId}</LineaId>");
            sb.Append($@"<MonedaId>{MonedaId}</MonedaId>");
            sb.Append($@"<Clave>{Clave}</Clave>");
            sb.Append($@"<Descripcion>{Descripcion}</Descripcion>");
            sb.Append($@"<Costo>{Costo}</Costo>");
            sb.Append($@"<unidad>{unidad}</unidad>");
            sb.Append($@"<Ubicacion>{Ubicacion}</Ubicacion>");
            sb.Append($@"<RowGuid>{rowGuid}</RowGuid>");
            sb.Append(@"</SincronizaC_Articulos>");
            sb.Append(@"</soap:Body>");

            return sb;
        }

        public static StringBuilder AreasRptEstatusSoapBody(int AreaOrdnId, int Orden, int OrdenDelantero, int OrdenTrasero)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<soap:Body>");
            sb.Append($@"<SincronizarC_AreasRptEstatus xmlns=""{WSConsts.URI}"">");
            sb.Append($@"<AreaOrdnId>{AreaOrdnId}</AreaOrdnId>");
            sb.Append($@"<Orden>{Orden}</Orden>");
            sb.Append($@"<OrdenDelantero>{OrdenDelantero}</OrdenDelantero>");
            sb.Append($@"<OrdenTrasero>{OrdenTrasero}</OrdenTrasero>");
            sb.Append(@"</SincronizarC_AreasRptEstatus>");
            sb.Append(@"</soap:Body>");

            return sb;
        }

        public static StringBuilder ConceptosSoapBody(int ConceptoId, string Tipo, string Concepto, string RowGuid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<soap:Body>");
            sb.Append($@"<SincronizaC_Conceptos xmlns=""{WSConsts.URI}"">");
            sb.Append($@"<ConceptoId>{ConceptoId}</ConceptoId>");
            sb.Append($@"<Tipo>{Tipo}</Tipo>");
            sb.Append($@"<Concepto>{Concepto}</Concepto>");
            sb.Append($@"<RowGuid>{RowGuid}</RowGuid>");
            sb.Append(@"</SincronizaC_Conceptos>");
            sb.Append(@"</soap:Body>");

            return sb;
        }

        public static StringBuilder ConceptosPSoapBody(int ConceptoPId, string Descripcion, int Tipo, decimal Monto, string Formula, string RowGuid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<soap:Body>");
            sb.Append($@"<SincronizaC_ConceptosP xmlns=""{WSConsts.URI}"">");
            sb.Append($@"<ConceptoPId>{ConceptoPId}</ConceptoPId>");
            sb.Append($@"<Descripcion>{Descripcion}</Descripcion>");
            sb.Append($@"<Tipo>{Tipo}</Tipo>");
            sb.Append($@"<Monto>{Monto}</Monto>");
            sb.Append($@"<Formula>{Formula}</Formula>");
            sb.Append($@"<RowGuid>{RowGuid}</RowGuid>");
            sb.Append(@"</SincronizaC_ConceptosP>");
            sb.Append(@"</soap:Body>");

            return sb;
        }

        public static StringBuilder EmpresaPSoapBody(int EmpresaId, int Dias, int PorMax, string RowGuid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<soap:Body>");
            sb.Append($@"<SincronizaC_EmpresaP xmlns=""{WSConsts.URI}"">");
            sb.Append($@"<EmpresaId>{EmpresaId}</EmpresaId>");
            sb.Append($@"<Dias>{Dias}</Dias>");
            sb.Append($@"<PorMax>{PorMax}</PorMax>");
            sb.Append($@"<RowGuid>{RowGuid}</RowGuid>");
            sb.Append(@"</SincronizaC_EmpresaP>");
            sb.Append(@"</soap:Body>");

            return sb;
        }

        public static StringBuilder EmpresasSoapBody(int EmpresaId, string Nombre, string NombreBd, string Dirección, string Telefono, string Fax,
                        string Mail, string rfc, int Jornada, int Pago, double Porcentajeop, double Porcentajearea, int TotalPiezas, string RowGuid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<soap:Body>");
            sb.Append($@"<SincronizaC_Empresas xmlns=""{WSConsts.URI}"">");
            sb.Append($@"<EmpresaId>{EmpresaId}</EmpresaId>");
            sb.Append($@"<Nombre>{Nombre}</Nombre>");
            sb.Append($@"<NombreBd>{NombreBd}</NombreBd>");
            sb.Append($@"<Dirección>{Dirección}</Dirección>");
            sb.Append($@"<Fax>{Fax}</Fax>");
            sb.Append($@"<Mail>{Mail}</Mail>");
            sb.Append($@"<rfc>{rfc}</rfc>");
            sb.Append($@"<Jornada>{Jornada}</Jornada>");
            sb.Append($@"<Pago>{Pago}</Pago>");
            sb.Append($@"<Porcentajeop>{Porcentajeop}</Porcentajeop>");
            sb.Append($@"<Porcentajearea>{Porcentajearea}</Porcentajearea>");
            sb.Append($@"<TotalPiezas>{TotalPiezas}</TotalPiezas>");
            sb.Append($@"<RowGuid>{RowGuid}</RowGuid>");
            sb.Append(@"</SincronizaC_Empresas>");
            sb.Append(@"</soap:Body>");

            return sb;
        }

        public static StringBuilder GrosorAgujasSoapBody(string Grosor, string RowGuid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<soap:Body>");
            sb.Append($@"<SincronizaC_GrosorAgujas xmlns=""{WSConsts.URI}"">");
            sb.Append($@"<Grosor>{Grosor}</Grosor>");
            sb.Append($@"<RowGuid>{RowGuid}</RowGuid>");
            sb.Append(@"</SincronizaC_GrosorAgujas>");
            sb.Append(@"</soap:Body>");

            return sb;
        }

        public static StringBuilder HilosSoapBody(int HiloId, string Clave, string Descripcion, string Calibre, string CveColor,
                                string Prov, string Marca, string Tipo, double Yardas, double Costo, int unidad, string RowGuid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<soap:Body>");
            sb.Append($@"<SincronizaC_Hilos xmlns=""{WSConsts.URI}"">");
            sb.Append($@"<HiloId>{HiloId}</HiloId>");
            sb.Append($@"<Clave>{Clave}</Clave>");
            sb.Append($@"<Descripcion>{Descripcion}</Descripcion>");
            sb.Append($@"<Calibre>{Calibre}</Calibre>");
            sb.Append($@"<CveColor>{CveColor}</CveColor>");
            sb.Append($@"<Prov>{Prov}</Prov>");
            sb.Append($@"<Marca>{Marca}</Marca>");
            sb.Append($@"<Tipo>{Tipo}</Tipo>");
            sb.Append($@"<Yardas>{Yardas}</Yardas>");
            sb.Append($@"<Costo>{Costo}</Costo>");
            sb.Append($@"<unidad>{unidad}</unidad>");
            sb.Append($@"<RowGuid>{RowGuid}</RowGuid>");
            sb.Append(@"</SincronizaC_Hilos>");
            sb.Append(@"</soap:Body>");

            return sb;
        }

        public static StringBuilder LineasSoapBody(decimal LineaId, string Descripcion, int ValidaSolomon, 
            int ValidaCatalogo, string Catalogo, string RowGuid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<soap:Body>");
            sb.Append($@"<SincronizaC_Lineas xmlns=""{WSConsts.URI}"">");
            sb.Append($@"<LineaId>{LineaId}</LineaId>");
            sb.Append($@"<Descripcion>{Descripcion}</Descripcion>");
            sb.Append($@"<ValidaSolomon>{ValidaSolomon}</ValidaSolomon>");
            sb.Append($@"<ValidaCatalogo>{ValidaCatalogo}</ValidaCatalogo>");
            sb.Append($@"<Catalogo>{Catalogo}</Catalogo>");
            sb.Append($@"<RowGuid>{RowGuid}</RowGuid>");
            sb.Append(@"</SincronizaC_Lineas>");
            sb.Append(@"</soap:Body>");

            return sb;
        }

        public static StringBuilder MaquinariaSoapBody(int MaquinariaId, int TipoMaquinaId, string NoInventario,
            string Descripcion, string Marca, string Modelo, string Serie, int Propiedad, int Ubicacion, int ModuloId,
            string Observaciones, int Estatus, double Factor, double ConsumoArriba, double ConsumoAbajo, DateTime FechaAlta,
            int Rentada, double Costo, decimal ProveedorId, string RowGuid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<soap:Body>");
            sb.Append($@"<SincronizaC_Maquinaria xmlns=""{WSConsts.URI}"">");
            sb.Append($@"<MaquinariaId>{MaquinariaId}</MaquinariaId>");
            sb.Append($@"<TipoMaquinaId>{TipoMaquinaId}</TipoMaquinaId>");
            sb.Append($@"<NoInventario>{NoInventario}</NoInventario>");
            sb.Append($@"<Descripcion>{Descripcion}</Descripcion>");
            sb.Append($@"<Estatus>{Estatus}</Estatus>");
            sb.Append($@"<Factor>{Factor}</Factor>");
            sb.Append($@"<ConsumoArriba>{ConsumoArriba}</ConsumoArriba>");
            sb.Append($@"<ConsumoAbajo>{ConsumoAbajo}</ConsumoAbajo>");
            sb.Append($@"<FechaAlta>{FechaAlta}</FechaAlta>");
            sb.Append($@"<Rentada>{Rentada}</Rentada>");
            sb.Append($@"<Costo>{Costo}</Costo>");
            sb.Append($@"<ProveedorId>{ProveedorId}</ProveedorId>");
            sb.Append($@"<RowGuid>{RowGuid}</RowGuid>");
            sb.Append(@"</SincronizaC_Maquinaria>");
            sb.Append(@"</soap:Body>");

            return sb;
        }

        public static StringBuilder MarcasSoapBody(string MarcaId, string Marca, string RowGuid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<soap:Body>");
            sb.Append($@"<SincronizaC_Marcas xmlns=""{WSConsts.URI}"">");
            sb.Append($@"<MarcaId>{MarcaId}</MarcaId>");
            sb.Append($@"<Marca>{Marca}</Marca>");
            sb.Append($@"<RowGuid>{RowGuid}</RowGuid>");
            sb.Append(@"</SincronizaC_Marcas>");
            sb.Append(@"</soap:Body>");

            return sb;
        }

        public static StringBuilder MarcasAgujasSoapBody(string Marca, string RowGuid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<soap:Body>");
            sb.Append($@"<SincronizaC_MarcasAgujas xmlns=""{WSConsts.URI}"">");
            sb.Append($@"<Marca>{Marca}</Marca>");
            sb.Append($@"<RowGuid>{RowGuid}</RowGuid>");
            sb.Append(@"</SincronizaC_MarcasAgujas>");
            sb.Append(@"</soap:Body>");

            return sb;
        }

        public static StringBuilder ModeloAgujasSoapBody(string Modelo, string RowGuid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<soap:Body>");
            sb.Append($@"<SincronizaC_ModeloAgujas xmlns=""{WSConsts.URI}"">");
            sb.Append($@"<Modelo>{Modelo}</Modelo>");
            sb.Append($@"<RowGuid>{RowGuid}</RowGuid>");
            sb.Append(@"</SincronizaC_ModeloAgujas>");
            sb.Append(@"</soap:Body>");

            return sb;
        }

        public static StringBuilder ModulosSoapBody(int ModuloId, string Descripcion, decimal Bono, string RowGuid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<soap:Body>");
            sb.Append($@"<SincronizaC_Modulos xmlns=""{WSConsts.URI}"">");
            sb.Append($@"<ModuloId>{ModuloId}</ModuloId>");
            sb.Append($@"<Descripcion>{Descripcion}</Descripcion>");
            sb.Append($@"<Bono>{Bono}</Bono>");
            sb.Append($@"<RowGuid>{RowGuid}</RowGuid>");
            sb.Append(@"</SincronizaC_Modulos>");
            sb.Append(@"</soap:Body>");

            return sb;
        }

        public static StringBuilder MonedasSoapBody(decimal MonedaId, string Descripcion, double TipoCambio, string RowGuid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<soap:Body>");
            sb.Append($@"<SincronizaC_Monedas xmlns=""{WSConsts.URI}"">");
            sb.Append($@"<MonedaId>{MonedaId}</MonedaId>");
            sb.Append($@"<Descripcion>{Descripcion}</Descripcion>");
            sb.Append($@"<TipoCambio>{TipoCambio}</TipoCambio>");
            sb.Append($@"<RowGuid>{RowGuid}</RowGuid>");
            sb.Append(@"</SincronizaC_Monedas>");
            sb.Append(@"</soap:Body>");

            return sb;
        }

        public static StringBuilder OperacionHilosSoapBody(int OperacionId, int HiloId, int Indice, int Arriba, string RowGuid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<soap:Body>");
            sb.Append($@"<SincronizaC_OperacionHilos xmlns=""{WSConsts.URI}"">");
            sb.Append($@"<OperacionId>{OperacionId}</OperacionId>");
            sb.Append($@"<HiloId>{HiloId}</HiloId>");
            sb.Append($@"<Indice>{Indice}</Indice>");
            sb.Append($@"<Arriba>{Arriba}</Arriba>");
            sb.Append($@"<RowGuid>{RowGuid}</RowGuid>");
            sb.Append(@"</SincronizaC_OperacionHilos>");
            sb.Append(@"</soap:Body>");

            return sb;
        }

        public static StringBuilder OperacionesSoapBody(int OperacionId, string NumOper, string Descripcion, int AreaId,
                                    string TipoOper, double Tiempo, double Consumo, int TipoMaquinaId, double Produccion,
                                    double Costoop, int Orden, int SueldoId, double Factor, double ConsumoArriba, double ConsumoAbajo,
                                    double Costura, int Activo, string RowGuid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<soap:Body>");
            sb.Append($@"<SincronizaC_Operaciones xmlns=""{WSConsts.URI}"">");
            sb.Append($@"<NumOper>{NumOper}</NumOper>");
            sb.Append($@"<Descripcion>{Descripcion}</Descripcion>");
            sb.Append($@"<AreaId>{AreaId}</AreaId>");
            sb.Append($@"<TipoOper>{TipoOper}</TipoOper>");
            sb.Append($@"<Tiempo>{Tiempo}</Tiempo>");
            sb.Append($@"<Consumo>{Consumo}</Consumo>");
            sb.Append($@"<TipoMaquinaId>{TipoMaquinaId}</TipoMaquinaId>");
            sb.Append($@"<Produccion>{Produccion}</Produccion>");
            sb.Append($@"<Costoop>{Costoop}</Costoop>");
            sb.Append($@"<Orden>{Orden}</Orden>");
            sb.Append($@"<SueldoId>{SueldoId}</SueldoId>");
            sb.Append($@"<Factor>{Factor}</Factor>");
            sb.Append($@"<ConsumoArriba>{ConsumoArriba}</ConsumoArriba>");
            sb.Append($@"<ConsumoAbajo>{ConsumoAbajo}</ConsumoAbajo>");
            sb.Append($@"<Costura>{Costura}</Costura>");
            sb.Append($@"<Activo>{Activo}</Activo>");
            sb.Append($@"<RowGuid>{RowGuid}</RowGuid>");
            sb.Append(@"</SincronizaC_Operaciones>");
            sb.Append(@"</soap:Body>");

            return sb;
        }

        public static StringBuilder PantallasSoapBody(string Descripcion, int Indice, string Menu, string RowGuid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<soap:Body>");
            sb.Append($@"<SincronizaC_Pantallas xmlns=""{WSConsts.URI}"">");
            sb.Append($@"<Descripcion>{Descripcion}</Descripcion>");
            sb.Append($@"<Indice>{Indice}</Indice>");
            sb.Append($@"<Menu>{Menu}</Menu>");
            sb.Append($@"<RowGuid>{RowGuid}</RowGuid>");
            sb.Append(@"</SincronizaC_Pantallas>");
            sb.Append(@"</soap:Body>");

            return sb;
        }

        public static StringBuilder ParametrosSoapBody(int Jornada, decimal TipoCambio, string RowGuid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<soap:Body>");
            sb.Append($@"<SincronizaC_Parametros xmlns=""{WSConsts.URI}"">");
            sb.Append($@"<Jornada>{Jornada}</Jornada>");
            sb.Append($@"<TipoCambio>{TipoCambio}</TipoCambio>");
            sb.Append($@"<RowGuid>{RowGuid}</RowGuid>");
            sb.Append(@"</SincronizaC_Parametros>");
            sb.Append(@"</soap:Body>");

            return sb;
        }
    }

}
