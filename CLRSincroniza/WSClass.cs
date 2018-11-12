using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace CLRSincroniza
{
    public static class WSClass
    {
        private static HttpWebRequest CreateRequest(string SoapAction)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(WSConsts.URL);
            request.Headers.Add($"SOAPAction:{SoapAction}");
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Method = "POST";
            request.Accept = "text/xml";
            request.Timeout = WSConsts.TIMEOUT;

            return request;
        }

        private static XmlDocument CreateXmlSoapRequest(StringBuilder SoapBodyRequest)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
            sb.Append(@"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">");
            sb.Append(SoapBodyRequest.ToString());
            sb.Append("</soap:Envelope>");

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(sb.ToString());

            return doc;
        }

        public static string ExecAlmacenResponse(int AlmacenID, string Almacen, string Ubicacion, string rowguid)
        {
            var request = CreateRequest(WSConsts.SOAP_ACTION_C_ALMACEN);

            var xmlRequest = CreateXmlSoapRequest(WSBodys.AlmacenSoapBody(AlmacenID, Almacen, Ubicacion, rowguid));

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string ServiceResult = string.Empty;

            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    ServiceResult = rd.ReadToEnd();
                }
            }

            return ServiceResult;
        }

        public static string ExecAreaModuloResponse(int ModuloId, int AreaId, string rowguid)
        {
            var request = CreateRequest(WSConsts.SOAP_ACTION_C_AREA_MODULO);

            var xmlRequest = CreateXmlSoapRequest(WSBodys.AreaModuloSoapBody(ModuloId, AreaId, rowguid));

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string ServiceResult = string.Empty;

            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    ServiceResult = rd.ReadToEnd();
                }
            }

            return ServiceResult;
        }

        public static string ExecAreasResponse(int AreaID, string Descripcion, int Orden, double Bono, string rowguid)
        {
            var request = CreateRequest(WSConsts.SOAP_ACTION_C_AREAS);

            var xmlRequest = CreateXmlSoapRequest(WSBodys.AreasSoapBody(AreaID, Descripcion, Orden, Bono, rowguid));

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string ServiceResult = string.Empty;

            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    ServiceResult = rd.ReadToEnd();
                }
            }

            return ServiceResult;
        }

        public static string ExecBiHorarioResponse(int BihorarioId, DateTime HoraInicio, DateTime HoraFin, double CantHrsLab,
                                        DateTime HoraIniReal, DateTime HoraFinReal, DateTime HoraIniRealAnt, DateTime HoraFinRealAnt)
        {
            var request = CreateRequest(WSConsts.SOAP_ACTION_C_BIHORARIOS);

            var xmlRequest = CreateXmlSoapRequest(WSBodys.BiHorarioSoapBody(BihorarioId, HoraInicio, HoraFin, CantHrsLab, HoraIniReal, HoraFinReal, HoraIniRealAnt, HoraFinRealAnt));

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string ServiceResult = string.Empty;

            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    ServiceResult = rd.ReadToEnd();
                }
            }

            return ServiceResult;
        }

        public static string ExecArticulosResponse(double ArticuloId, double LineaId, double MonedaId, string Clave,
                                        string Descripcion, double Costo, string unidad, string Ubicacion, string rowGuid)
        {
            var request = CreateRequest(WSConsts.SOAP_ACTION_C_ACTICULOS);

            var xmlRequest = CreateXmlSoapRequest(WSBodys.ArticulosSoapBody(ArticuloId, LineaId, MonedaId, Clave, Descripcion, Costo, unidad, Ubicacion, rowGuid));

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string ServiceResult = string.Empty;

            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    ServiceResult = rd.ReadToEnd();
                }
            }

            return ServiceResult;
        }

        public static string ExecAreasRptEstatusResponse(int AreaOrdnId, int Orden, int OrdenDelantero, int OrdenTrasero)
        {
            var request = CreateRequest(WSConsts.SOAP_ACTION_C_AREA_RPT_ESTATUS);

            var xmlRequest = CreateXmlSoapRequest(WSBodys.AreasRptEstatusSoapBody(AreaOrdnId, Orden, OrdenDelantero, OrdenTrasero));

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string ServiceResult = string.Empty;

            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    ServiceResult = rd.ReadToEnd();
                }
            }

            return ServiceResult;
        }

        public static string ExecConceptosResponse(int ConceptoId, string Tipo, string Concepto, string RowGuid)
        {
            var request = CreateRequest(WSConsts.SOAP_ACTION_C_CONCEPTOS);

            var xmlRequest = CreateXmlSoapRequest(WSBodys.ConceptosSoapBody(ConceptoId, Tipo, Concepto, RowGuid));

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string ServiceResult = string.Empty;

            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    ServiceResult = rd.ReadToEnd();
                }
            }

            return ServiceResult;
        }

        public static string ExecConceptosPResponse(int ConceptoPId, string Descripcion, int Tipo, decimal Monto, string Formula, string RowGuid)
        {
            var request = CreateRequest(WSConsts.SOAP_ACTION_C_CONCEPTOSP);

            var xmlRequest = CreateXmlSoapRequest(WSBodys.ConceptosPSoapBody(ConceptoPId, Descripcion, Tipo, Monto, Formula, RowGuid));

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string ServiceResult = string.Empty;

            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    ServiceResult = rd.ReadToEnd();
                }
            }

            return ServiceResult;
        }

        public static string ExecEmpresaPResponse(int EmpresaId, int Dias, int PorMax, string RowGuid)
        {
            var request = CreateRequest(WSConsts.SOAP_ACTION_C_EMPRESAP);

            var xmlRequest = CreateXmlSoapRequest(WSBodys.EmpresaPSoapBody(EmpresaId, Dias, PorMax, RowGuid));

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string ServiceResult = string.Empty;

            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    ServiceResult = rd.ReadToEnd();
                }
            }

            return ServiceResult;
        }

        public static string ExecEmpresasResponse(int EmpresaId, string Nombre, string NombreBd, string Dirección, string Telefono, string Fax,
                        string Mail, string rfc, int Jornada, int Pago, double Porcentajeop, double Porcentajearea, int TotalPiezas, string RowGuid)
        {
            var request = CreateRequest(WSConsts.SOAP_ACTION_C_EMPRESAS);

            var xmlRequest = CreateXmlSoapRequest(WSBodys.EmpresasSoapBody(EmpresaId, Nombre, NombreBd, Dirección, Telefono, Fax,
                                    Mail, rfc, Jornada, Pago, Porcentajeop, Porcentajearea, TotalPiezas, RowGuid));

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string ServiceResult = string.Empty;

            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    ServiceResult = rd.ReadToEnd();
                }
            }

            return ServiceResult;
        }

        public static string ExecGrosorAgujasResponse(string Grosor, string RowGuid)
        {
            var request = CreateRequest(WSConsts.SOAP_ACTION_C_GROSORAGUJAS);

            var xmlRequest = CreateXmlSoapRequest(WSBodys.GrosorAgujasSoapBody(Grosor, RowGuid));

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string ServiceResult = string.Empty;

            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    ServiceResult = rd.ReadToEnd();
                }
            }

            return ServiceResult;
        }

        public static string ExecHilosResponse(int HiloId, string Clave, string Descripcion, string Calibre, string CveColor,
                                string Prov, string Marca, string Tipo, double Yardas, double Costo, int unidad, string RowGuid)
        {
            var request = CreateRequest(WSConsts.SOAP_ACTION_C_HILO);

            var xmlRequest = CreateXmlSoapRequest(WSBodys.HilosSoapBody(HiloId, Clave, Descripcion, Calibre, CveColor,
                                    Prov, Marca, Tipo, Yardas, Costo, unidad, RowGuid));

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string ServiceResult = string.Empty;

            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    ServiceResult = rd.ReadToEnd();
                }
            }

            return ServiceResult;
        }

        public static string ExecLineasResponse(decimal LineaId, string Descripcion, int ValidaSolomon,
            int ValidaCatalogo, string Catalogo, string RowGuid)
        {
            var request = CreateRequest(WSConsts.SOAP_ACTION_C_LINEAS);

            var xmlRequest = CreateXmlSoapRequest(WSBodys.LineasSoapBody(LineaId, Descripcion, ValidaSolomon, ValidaCatalogo,
                                    Catalogo, RowGuid));

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string ServiceResult = string.Empty;

            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    ServiceResult = rd.ReadToEnd();
                }
            }

            return ServiceResult;
        }

        public static string ExecMaquinariaResponse(int MaquinariaId, int TipoMaquinaId, string NoInventario,
                                                    string Descripcion, string Marca, string Modelo, string Serie, int Propiedad, int Ubicacion, int ModuloId,
                                                    string Observaciones, int Estatus, double Factor, double ConsumoArriba, double ConsumoAbajo, DateTime FechaAlta,
                                                    int Rentada, double Costo, decimal ProveedorId, string RowGuid)
        {
            var request = CreateRequest(WSConsts.SOAP_ACTION_C_MAQUINARIA);

            var xmlRequest = CreateXmlSoapRequest(WSBodys.MaquinariaSoapBody(MaquinariaId, TipoMaquinaId, NoInventario, Descripcion,
                                    Marca, Modelo, Serie, Propiedad, Ubicacion, ModuloId, Observaciones, Estatus, Factor, ConsumoArriba,
                                    ConsumoAbajo, FechaAlta, Rentada, Costo, ProveedorId, RowGuid));

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string ServiceResult = string.Empty;

            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    ServiceResult = rd.ReadToEnd();
                }
            }

            return ServiceResult;
        }

        public static string ExecMarcasResponse(string MarcaId, string Marca, string RowGuid)
        {
            var request = CreateRequest(WSConsts.SOAP_ACTION_C_MARCAS);

            var xmlRequest = CreateXmlSoapRequest(WSBodys.MarcasSoapBody(MarcaId, Marca, RowGuid));

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string ServiceResult = string.Empty;

            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    ServiceResult = rd.ReadToEnd();
                }
            }

            return ServiceResult;
        }

        public static string ExecMarcasAgujasResponse(string Marca, string RowGuid)
        {
            var request = CreateRequest(WSConsts.SOAP_ACTION_C_MARCASAGUJAS);

            var xmlRequest = CreateXmlSoapRequest(WSBodys.MarcasAgujasSoapBody(Marca, RowGuid));

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string ServiceResult = string.Empty;

            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    ServiceResult = rd.ReadToEnd();
                }
            }

            return ServiceResult;
        }

        public static string ExecModeloAgujasResponse(string Modelo, string RowGuid)
        {
            var request = CreateRequest(WSConsts.SOAP_ACTION_C_MODELOAGUJAS);

            var xmlRequest = CreateXmlSoapRequest(WSBodys.ModeloAgujasSoapBody(Modelo, RowGuid));

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string ServiceResult = string.Empty;

            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    ServiceResult = rd.ReadToEnd();
                }
            }

            return ServiceResult;
        }

        public static string ExecModulosResponse(int ModuloId, string Descripcion, decimal Bono, string RowGuid)
        {
            var request = CreateRequest(WSConsts.SOAP_ACTION_C_MODULOS);

            var xmlRequest = CreateXmlSoapRequest(WSBodys.ModulosSoapBody(ModuloId, Descripcion, Bono, RowGuid));

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string ServiceResult = string.Empty;

            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    ServiceResult = rd.ReadToEnd();
                }
            }

            return ServiceResult;
        }

        public static string ExecMonedasResponse(decimal MonedaId, string Descripcion, double TipoCambio, string RowGuid)
        {
            var request = CreateRequest(WSConsts.SOAP_ACTION_C_MODENAS);

            var xmlRequest = CreateXmlSoapRequest(WSBodys.MonedasSoapBody(MonedaId, Descripcion, TipoCambio, RowGuid));

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string ServiceResult = string.Empty;

            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    ServiceResult = rd.ReadToEnd();
                }
            }

            return ServiceResult;
        }

        public static string ExecOperacionHilosResponse(int OperacionId, int HiloId, int Indice, int Arriba, string RowGuid)
        {
            var request = CreateRequest(WSConsts.SOAP_ACTION_C_OPERACIONHILOS);
            
            var xmlRequest = CreateXmlSoapRequest(WSBodys.OperacionHilosSoapBody(OperacionId, HiloId, Indice, Arriba, RowGuid));

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string ServiceResult = string.Empty;

            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    ServiceResult = rd.ReadToEnd();
                }
            }

            return ServiceResult;
        }

        public static string ExecOperacionesResponse(int OperacionId, string NumOper, string Descripcion, int AreaId,
                            string TipoOper, double Tiempo, double Consumo, int TipoMaquinaId, double Produccion, double Costoop,
                            int Orden, int SueldoId, double Factor, double ConsumoArriba, double ConsumoAbajo, double Costura,
                            int Activo, string RowGuid)
        {
            var request = CreateRequest(WSConsts.SOAP_ACTION_C_OPERACIONES);

            var xmlRequest = CreateXmlSoapRequest(WSBodys.OperacionesSoapBody(OperacionId, NumOper, Descripcion, AreaId, TipoOper,
                                                Tiempo, Consumo, TipoMaquinaId, Produccion, Costoop, Orden, SueldoId, Factor,
                                                ConsumoArriba, ConsumoAbajo, Costura, Activo, RowGuid));

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string ServiceResult = string.Empty;

            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    ServiceResult = rd.ReadToEnd();
                }
            }

            return ServiceResult;
        }

        public static string ExecPantallasResponse(string Descripcion, int Indice, string Menu, string RowGuid)
        {
            var request = CreateRequest(WSConsts.SOAP_ACTION_C_PANTALLAS);

            var xmlRequest = CreateXmlSoapRequest(WSBodys.PantallasSoapBody(Descripcion, Indice, Menu, RowGuid));

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string ServiceResult = string.Empty;

            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    ServiceResult = rd.ReadToEnd();
                }
            }

            return ServiceResult;
        }

        public static string ExecParametrosResponse(int Jornada, decimal TipoCambio, string RowGuid)
        {
            var request = CreateRequest(WSConsts.SOAP_ACTION_C_PARAMETROS);

            var xmlRequest = CreateXmlSoapRequest(WSBodys.ParametrosSoapBody(Jornada, TipoCambio, RowGuid));

            using (Stream stream = request.GetRequestStream())
            {
                xmlRequest.Save(stream);
            }

            string ServiceResult = string.Empty;

            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    ServiceResult = rd.ReadToEnd();
                }
            }

            return ServiceResult;
        }
    }
}
