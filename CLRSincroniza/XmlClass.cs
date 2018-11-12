using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace CLRSincroniza
{
    public static class XmlClass
    {
        public const string DEFAULT_FOLDER_XML = @"C:\images\C99";

        public static void SaveXmlAlmacen(int AlmacenID, string Almacen, string Ubicacion, string rowguid)
        {
            XmlDocument doc = new XmlDocument();
            var ele = doc.CreateElement("C_Almacen");
            doc.AppendChild(ele);

            var pro1 = doc.CreateElement("AlmacenID");
            pro1.InnerText = AlmacenID.ToString();
            ele.AppendChild(pro1);

            var pro2 = doc.CreateElement("Almacen");
            pro2.InnerText = Almacen;
            ele.AppendChild(pro2);

            var pro3 = doc.CreateElement("Ubicacion");
            pro3.InnerText = Ubicacion;
            ele.AppendChild(pro3);

            var pro4 = doc.CreateElement("rowguid");
            pro4.InnerText = rowguid;
            ele.AppendChild(pro4);

            doc.Save(Path.Combine(XmlClass.DEFAULT_FOLDER_XML, "C_Almacen_" + rowguid + ".xml"));
        }

        public static void SaveXmlAreaModulo(int ModuloID, int AreaID, string rowguid)
        {
            XmlDocument doc = new XmlDocument();
            var ele = doc.CreateElement("C_AreaModulo");
            doc.AppendChild(ele);

            var pro1 = doc.CreateElement("AlmacenID");
            pro1.InnerText = ModuloID.ToString();
            ele.AppendChild(pro1);

            var pro2 = doc.CreateElement("AreaID");
            pro2.InnerText = AreaID.ToString();
            ele.AppendChild(pro2);

            var pro4 = doc.CreateElement("rowguid");
            pro4.InnerText = rowguid;
            ele.AppendChild(pro4);

            doc.Save(Path.Combine(XmlClass.DEFAULT_FOLDER_XML, "C_AreaModulo_" + rowguid + ".xml"));
        }

        public static void SaveXmlAreas(int AreaID, string Descripcion, int Orden, double Bono, string rowguid)
        {
            XmlDocument doc = new XmlDocument();
            var ele = doc.CreateElement("C_Areas");
            doc.AppendChild(ele);

            var pro1 = doc.CreateElement("AreaID");
            pro1.InnerText = AreaID.ToString();
            ele.AppendChild(pro1);

            var pro2 = doc.CreateElement("Descripcion");
            pro2.InnerText = Descripcion;
            ele.AppendChild(pro2);

            var pro3 = doc.CreateElement("Orden");
            pro3.InnerText = Orden.ToString();
            ele.AppendChild(pro3);

            var pro4 = doc.CreateElement("Bono");
            pro4.InnerText = Bono.ToString();
            ele.AppendChild(pro4);

            var pro5 = doc.CreateElement("rowguid");
            pro5.InnerText = rowguid;
            ele.AppendChild(pro5);

            doc.Save(Path.Combine(XmlClass.DEFAULT_FOLDER_XML, "C_Areas_" + rowguid + ".xml"));
        }

        public static void SaveXmlBiHorario(int BihorarioId, DateTime HoraInicio, DateTime HoraFin, double CantHrsLab,
                                        DateTime HoraIniReal, DateTime HoraFinReal, DateTime HoraIniRealAnt, DateTime HoraFinRealAnt)
        {
            XmlDocument doc = new XmlDocument();
            var ele = doc.CreateElement("C_Bihorarios");
            doc.AppendChild(ele);

            var pro1 = doc.CreateElement("BihorarioID");
            pro1.InnerText = BihorarioId.ToString();
            ele.AppendChild(pro1);

            var pro2 = doc.CreateElement("HoraInicio");
            pro2.InnerText = HoraInicio.ToString();
            ele.AppendChild(pro2);

            var pro3 = doc.CreateElement("HoraFin");
            pro3.InnerText = HoraFin.ToString();
            ele.AppendChild(pro3);

            var pro4 = doc.CreateElement("CantHrsLab");
            pro4.InnerText = CantHrsLab.ToString();
            ele.AppendChild(pro4);

            var pro5 = doc.CreateElement("HoraIniReal");
            pro5.InnerText = HoraIniReal.ToString();
            ele.AppendChild(pro5);

            var pro6 = doc.CreateElement("HoraFinReal");
            pro6.InnerText = HoraFinReal.ToString();
            ele.AppendChild(pro6);

            var pro7 = doc.CreateElement("HoraIniRealAnt");
            pro7.InnerText = HoraIniRealAnt.ToString();
            ele.AppendChild(pro7);

            var pro8 = doc.CreateElement("HoraFinRealAnt");
            pro8.InnerText = HoraFinRealAnt.ToString();
            ele.AppendChild(pro8);

            doc.Save(Path.Combine(XmlClass.DEFAULT_FOLDER_XML, "C_Bihorarios_" + BihorarioId + ".xml"));
        }

        public static void SaveXmlActiculos(double ArticuloId, double LineaId, double MonedaId, string Clave,
                                        string Descripcion, double Costo, string unidad, string Ubicacion, string rowGuid)
        {
            XmlDocument doc = new XmlDocument();
            var ele = doc.CreateElement("C_Articulos");
            doc.AppendChild(ele);

            var pro1 = doc.CreateElement("ArticuloId");
            pro1.InnerText = ArticuloId.ToString();
            ele.AppendChild(pro1);

            var pro2 = doc.CreateElement("LineaId");
            pro2.InnerText = LineaId.ToString();
            ele.AppendChild(pro2);

            var pro3 = doc.CreateElement("MonedaId");
            pro3.InnerText = MonedaId.ToString();
            ele.AppendChild(pro3);

            var pro4 = doc.CreateElement("Clave");
            pro4.InnerText = Clave;
            ele.AppendChild(pro4);

            var pro5 = doc.CreateElement("Descripcion");
            pro5.InnerText = Descripcion;
            ele.AppendChild(pro5);

            var pro6 = doc.CreateElement("Costo");
            pro6.InnerText = Costo.ToString();
            ele.AppendChild(pro6);

            var pro7 = doc.CreateElement("unidad");
            pro7.InnerText = unidad;
            ele.AppendChild(pro7);

            var pro8 = doc.CreateElement("Ubicacion");
            pro8.InnerText = Ubicacion;
            ele.AppendChild(pro8);

            var pro9 = doc.CreateElement("rowGuid");
            pro9.InnerText = rowGuid;
            ele.AppendChild(pro9);

            doc.Save(Path.Combine(XmlClass.DEFAULT_FOLDER_XML, "C_Articulos_" + ArticuloId + ".xml"));
        }

        public static void SaveXmlAreasRptEstatus(int AreaOrdnId, int Orden, int OrdenDelantero, int OrdenTrasero)
        {
            XmlDocument doc = new XmlDocument();
            var ele = doc.CreateElement("C_AreasRptEstatus");
            doc.AppendChild(ele);

            var pro1 = doc.CreateElement("AreaOrdnId");
            pro1.InnerText = AreaOrdnId.ToString();
            ele.AppendChild(pro1);

            var pro2 = doc.CreateElement("Orden");
            pro2.InnerText = Orden.ToString();
            ele.AppendChild(pro2);

            var pro3 = doc.CreateElement("OrdenDelantero");
            pro3.InnerText = OrdenDelantero.ToString();
            ele.AppendChild(pro3);

            var pro4 = doc.CreateElement("OrdenTrasero");
            pro4.InnerText = OrdenTrasero.ToString();
            ele.AppendChild(pro4);

            doc.Save(Path.Combine(XmlClass.DEFAULT_FOLDER_XML, "C_AreasRptEstatus_" + AreaOrdnId + ".xml"));
        }

        public static void SaveXmlConceptos(int ConceptoId, string Tipo, string Concepto, string RowGuid)
        {
            XmlDocument doc = new XmlDocument();
            var ele = doc.CreateElement("C_Conceptos");
            doc.AppendChild(ele);

            var pro1 = doc.CreateElement("ConceptoId");
            pro1.InnerText = ConceptoId.ToString();
            ele.AppendChild(pro1);

            var pro2 = doc.CreateElement("Tipo");
            pro2.InnerText = Tipo;
            ele.AppendChild(pro2);

            var pro3 = doc.CreateElement("Concepto");
            pro3.InnerText = Concepto;
            ele.AppendChild(pro3);

            var pro4 = doc.CreateElement("RowGuid");
            pro4.InnerText = RowGuid;
            ele.AppendChild(pro4);

            doc.Save(Path.Combine(XmlClass.DEFAULT_FOLDER_XML, "C_Conceptos" + RowGuid + ".xml"));
        }

        public static void SaveXmlConceptosP(int ConceptoPId, string Descripcion, int Tipo, decimal Monto, string Formula, string RowGuid)
        {
            XmlDocument doc = new XmlDocument();
            var ele = doc.CreateElement("C_ConceptosP");
            doc.AppendChild(ele);

            var pro1 = doc.CreateElement("ConceptoId");
            pro1.InnerText = ConceptoPId.ToString();
            ele.AppendChild(pro1);

            var pro2 = doc.CreateElement("Tipo");
            pro2.InnerText = Tipo.ToString();
            ele.AppendChild(pro2);

            var pro3 = doc.CreateElement("Monto");
            pro3.InnerText = Monto.ToString();
            ele.AppendChild(pro3);

            var pro4 = doc.CreateElement("Formula");
            pro4.InnerText = Formula;
            ele.AppendChild(pro4);

            var pro5 = doc.CreateElement("RowGuid");
            pro5.InnerText = RowGuid;
            ele.AppendChild(pro5);

            doc.Save(Path.Combine(XmlClass.DEFAULT_FOLDER_XML, "C_ConceptosP" + RowGuid + ".xml"));
        }

        public static void SaveXmlEmpresaP(int EmpresaId, int Dias, int PorMax, string RowGuid)
        {
            XmlDocument doc = new XmlDocument();
            var ele = doc.CreateElement("C_EmpresaP");
            doc.AppendChild(ele);

            var pro1 = doc.CreateElement("EmpresaId");
            pro1.InnerText = EmpresaId.ToString();
            ele.AppendChild(pro1);

            var pro2 = doc.CreateElement("Dias");
            pro2.InnerText = Dias.ToString();
            ele.AppendChild(pro2);

            var pro3 = doc.CreateElement("PorMax");
            pro3.InnerText = PorMax.ToString();
            ele.AppendChild(pro3);

            var pro4 = doc.CreateElement("RowGuid");
            pro4.InnerText = RowGuid;
            ele.AppendChild(pro4);

            doc.Save(Path.Combine(XmlClass.DEFAULT_FOLDER_XML, "C_EmpresaP" + RowGuid + ".xml"));
        }

        public static void SaveXmlEmpresas(int EmpresaId, string Nombre, string NombreBd, string Dirección, string Telefono, string Fax,
                        string Mail, string rfc, int Jornada, int Pago, double Porcentajeop, double Porcentajearea, int TotalPiezas, string RowGuid)
        {
            XmlDocument doc = new XmlDocument();
            var ele = doc.CreateElement("C_Empresas");
            doc.AppendChild(ele);

            var pro1 = doc.CreateElement("EmpresaId");
            pro1.InnerText = EmpresaId.ToString();
            ele.AppendChild(pro1);

            var pro2 = doc.CreateElement("Nombre");
            pro2.InnerText = Nombre;
            ele.AppendChild(pro2);

            var pro3 = doc.CreateElement("NombreBd");
            pro3.InnerText = NombreBd;
            ele.AppendChild(pro3);

            var pro4 = doc.CreateElement("Dirección");
            pro4.InnerText = Dirección;
            ele.AppendChild(pro4);

            var pro5 = doc.CreateElement("Telefono");
            pro5.InnerText = Telefono;
            ele.AppendChild(pro5);

            var pro6 = doc.CreateElement("Fax");
            pro6.InnerText = Fax;
            ele.AppendChild(pro6);

            var pro7 = doc.CreateElement("Mail");
            pro7.InnerText = Mail;
            ele.AppendChild(pro7);

            var pro8 = doc.CreateElement("rfc");
            pro8.InnerText = rfc;
            ele.AppendChild(pro8);

            var pro9 = doc.CreateElement("Jornada");
            pro9.InnerText = Jornada.ToString();
            ele.AppendChild(pro9);

            var pro10 = doc.CreateElement("Pago");
            pro10.InnerText = Pago.ToString();
            ele.AppendChild(pro10);

            var pro11 = doc.CreateElement("Porcentajeop");
            pro11.InnerText = Porcentajeop.ToString();
            ele.AppendChild(pro11);

            var pro12 = doc.CreateElement("Porcentajearea");
            pro12.InnerText = Porcentajearea.ToString();
            ele.AppendChild(pro12);

            var pro13 = doc.CreateElement("TotalPiezas");
            pro13.InnerText = TotalPiezas.ToString();
            ele.AppendChild(pro13);

            var pro14 = doc.CreateElement("RowGuid");
            pro14.InnerText = RowGuid;
            ele.AppendChild(pro14);

            doc.Save(Path.Combine(XmlClass.DEFAULT_FOLDER_XML, "C_Empresas" + RowGuid + ".xml"));
        }

        public static void SaveXmlGrosorAgujas(string Grosor, string RowGuid)
        {
            XmlDocument doc = new XmlDocument();
            var ele = doc.CreateElement("C_GrosorAgujas");
            doc.AppendChild(ele);

            var pro1 = doc.CreateElement("Grosor");
            pro1.InnerText = Grosor;
            ele.AppendChild(pro1);

            var pro2 = doc.CreateElement("RowGuid");
            pro2.InnerText = RowGuid;
            ele.AppendChild(pro2);

            doc.Save(Path.Combine(XmlClass.DEFAULT_FOLDER_XML, "C_GrosorAgujas" + RowGuid + ".xml"));
        }

        public static void SaveXmlHilos(int HiloId, string Clave, string Descripcion, string Calibre, string CveColor,
                                string Prov, string Marca, string Tipo, double Yardas, double Costo, int unidad, string RowGuid)
        {
            XmlDocument doc = new XmlDocument();
            var ele = doc.CreateElement("C_Hilos");
            doc.AppendChild(ele);

            var pro1 = doc.CreateElement("HiloId");
            pro1.InnerText = HiloId.ToString();
            ele.AppendChild(pro1);

            var pro2 = doc.CreateElement("Clave");
            pro2.InnerText = Clave;
            ele.AppendChild(pro2);

            var pro3 = doc.CreateElement("Descripcion");
            pro3.InnerText = Descripcion;
            ele.AppendChild(pro3);

            var pro4 = doc.CreateElement("Calibre");
            pro4.InnerText = Calibre;
            ele.AppendChild(pro4);

            var pro5 = doc.CreateElement("CveColor");
            pro5.InnerText = CveColor;
            ele.AppendChild(pro5);

            var pro6 = doc.CreateElement("Prov");
            pro6.InnerText = Prov;
            ele.AppendChild(pro6);

            var pro7 = doc.CreateElement("Marca");
            pro7.InnerText = Marca;
            ele.AppendChild(pro7);

            var pro8 = doc.CreateElement("Tipo");
            pro8.InnerText = Tipo;
            ele.AppendChild(pro8);

            var pro9 = doc.CreateElement("Yardas");
            pro9.InnerText = Yardas.ToString();
            ele.AppendChild(pro9);

            var pro10 = doc.CreateElement("Costo");
            pro10.InnerText = Costo.ToString();
            ele.AppendChild(pro10);

            var pro11 = doc.CreateElement("unidad");
            pro11.InnerText = unidad.ToString();
            ele.AppendChild(pro11);

            var pro12 = doc.CreateElement("RowGuid");
            pro12.InnerText = RowGuid.ToString();
            ele.AppendChild(pro12);

            doc.Save(Path.Combine(XmlClass.DEFAULT_FOLDER_XML, "C_Hilos" + RowGuid + ".xml"));
        }

        public static void SaveXmlLineas(decimal LineaId, string Descripcion, int ValidaSolomon,
            int ValidaCatalogo, string Catalogo, string RowGuid)
        {
            XmlDocument doc = new XmlDocument();
            var ele = doc.CreateElement("C_Lineas");
            doc.AppendChild(ele);

            var pro1 = doc.CreateElement("Descripcion");
            pro1.InnerText = Descripcion;
            ele.AppendChild(pro1);

            var pro2 = doc.CreateElement("ValidaSolomon");
            pro2.InnerText = ValidaSolomon.ToString();
            ele.AppendChild(pro2);

            var pro3 = doc.CreateElement("ValidaCatalogo");
            pro3.InnerText = ValidaCatalogo.ToString();
            ele.AppendChild(pro3);

            var pro4 = doc.CreateElement("Catalogo");
            pro4.InnerText = Catalogo;
            ele.AppendChild(pro4);

            var pro5 = doc.CreateElement("RowGuid");
            pro5.InnerText = RowGuid;
            ele.AppendChild(pro5);

            doc.Save(Path.Combine(XmlClass.DEFAULT_FOLDER_XML, "C_Lineas" + RowGuid + ".xml"));
        }

        public static void SaveXmlMaquinaria(int MaquinariaId, int TipoMaquinaId, string NoInventario,
                                            string Descripcion, string Marca, string Modelo, string Serie, int Propiedad, int Ubicacion, int ModuloId,
                                            string Observaciones, int Estatus, double Factor, double ConsumoArriba, double ConsumoAbajo, DateTime FechaAlta,
                                            int Rentada, double Costo, decimal ProveedorId, string RowGuid)
        {
            XmlDocument doc = new XmlDocument();
            var ele = doc.CreateElement("C_Maquinaria");
            doc.AppendChild(ele);

            var pro1 = doc.CreateElement("MaquinariaId");
            pro1.InnerText = MaquinariaId.ToString();
            ele.AppendChild(pro1);

            var pro2 = doc.CreateElement("TipoMaquinaId");
            pro2.InnerText = TipoMaquinaId.ToString();
            ele.AppendChild(pro2);

            var pro3 = doc.CreateElement("NoInventario");
            pro3.InnerText = NoInventario;
            ele.AppendChild(pro3);

            var pro4 = doc.CreateElement("Descripcion");
            pro4.InnerText = Descripcion;
            ele.AppendChild(pro4);

            var pro5 = doc.CreateElement("Marca");
            pro5.InnerText = Marca;
            ele.AppendChild(pro5);

            var pro6 = doc.CreateElement("Modelo");
            pro6.InnerText = Modelo;
            ele.AppendChild(pro6);

            var pro7 = doc.CreateElement("Serie");
            pro7.InnerText = Serie;
            ele.AppendChild(pro7);

            var pro8 = doc.CreateElement("Propiedad");
            pro8.InnerText = Propiedad.ToString();
            ele.AppendChild(pro8);

            var pro9 = doc.CreateElement("Ubicacion");
            pro9.InnerText = Ubicacion.ToString();
            ele.AppendChild(pro9);

            var pro10 = doc.CreateElement("ModuloId");
            pro10.InnerText = ModuloId.ToString();
            ele.AppendChild(pro10);
            
            var pro11 = doc.CreateElement("Observaciones");
            pro11.InnerText = Observaciones;
            ele.AppendChild(pro11);

            var pro12 = doc.CreateElement("Estatus");
            pro12.InnerText = Estatus.ToString();
            ele.AppendChild(pro12);

            var pro13 = doc.CreateElement("Factor");
            pro13.InnerText = Factor.ToString();
            ele.AppendChild(pro13);

            var pro14 = doc.CreateElement("ConsumoArriba");
            pro14.InnerText = ConsumoArriba.ToString();
            ele.AppendChild(pro14);

            var pro15 = doc.CreateElement("ConsumoAbajo");
            pro15.InnerText = ConsumoAbajo.ToString();
            ele.AppendChild(pro15);

            var pro16 = doc.CreateElement("FechaAlta");
            pro16.InnerText = FechaAlta.ToString();
            ele.AppendChild(pro16);

            var pro17 = doc.CreateElement("Rentada");
            pro17.InnerText = Rentada.ToString();
            ele.AppendChild(pro17);

            var pro18 = doc.CreateElement("Costo");
            pro18.InnerText = Costo.ToString();
            ele.AppendChild(pro18);

            var pro19 = doc.CreateElement("ProveedorId");
            pro19.InnerText = ProveedorId.ToString();
            ele.AppendChild(pro19);

            var pro20 = doc.CreateElement("RowGuid");
            pro20.InnerText = RowGuid;
            ele.AppendChild(pro20);

           
            doc.Save(Path.Combine(XmlClass.DEFAULT_FOLDER_XML, "C_Maquinaria" + RowGuid + ".xml"));
        }

        public static void SaveXmlMarcas(string MarcaId, string Marca, string RowGuid)
        {
            XmlDocument doc = new XmlDocument();
            var ele = doc.CreateElement("C_Marcas");
            doc.AppendChild(ele);

            var pro1 = doc.CreateElement("MarcaId");
            pro1.InnerText = MarcaId.ToString();
            ele.AppendChild(pro1);

            var pro2 = doc.CreateElement("Marca");
            pro2.InnerText = Marca.ToString();
            ele.AppendChild(pro2);

            var pro3 = doc.CreateElement("RowGuid");
            pro3.InnerText = RowGuid;
            ele.AppendChild(pro3);

            doc.Save(Path.Combine(XmlClass.DEFAULT_FOLDER_XML, "C_Marcas" + RowGuid + ".xml"));
        }

        public static void SaveXmlMarcasAgujas(string Marca, string RowGuid)
        {
            XmlDocument doc = new XmlDocument();
            var ele = doc.CreateElement("C_MarcasAgujas");
            doc.AppendChild(ele);

            var pro2 = doc.CreateElement("Marca");
            pro2.InnerText = Marca;
            ele.AppendChild(pro2);

            var pro3 = doc.CreateElement("RowGuid");
            pro3.InnerText = RowGuid;
            ele.AppendChild(pro3);

            doc.Save(Path.Combine(XmlClass.DEFAULT_FOLDER_XML, "C_MarcasAgujas" + RowGuid + ".xml"));
        }

        public static void SaveXmlModeloAgujas(string Modelo, string RowGuid)
        {
            XmlDocument doc = new XmlDocument();
            var ele = doc.CreateElement("C_ModeloAgujas");
            doc.AppendChild(ele);

            var pro2 = doc.CreateElement("Modelo");
            pro2.InnerText = Modelo;
            ele.AppendChild(pro2);

            var pro3 = doc.CreateElement("RowGuid");
            pro3.InnerText = RowGuid;
            ele.AppendChild(pro3);

            doc.Save(Path.Combine(XmlClass.DEFAULT_FOLDER_XML, "C_ModeloAgujas" + RowGuid + ".xml"));
        }

        public static void SaveXmlModulos(int ModuloId, string Descripcion, decimal Bono, string RowGuid)
        {
            XmlDocument doc = new XmlDocument();
            var ele = doc.CreateElement("C_Modulos");
            doc.AppendChild(ele);

            var pro2 = doc.CreateElement("ModuloId");
            pro2.InnerText = ModuloId.ToString();
            ele.AppendChild(pro2);

            var pro3 = doc.CreateElement("Descripcion");
            pro3.InnerText = Descripcion;
            ele.AppendChild(pro3);

            var pro4 = doc.CreateElement("Bono");
            pro4.InnerText = Bono.ToString();
            ele.AppendChild(pro4);

            var pro5 = doc.CreateElement("RowGuid");
            pro5.InnerText = RowGuid;
            ele.AppendChild(pro5);

            doc.Save(Path.Combine(XmlClass.DEFAULT_FOLDER_XML, "C_Modulos" + RowGuid + ".xml"));
        }

        public static void SaveXmlMonedas(decimal MonedaId, string Descripcion, double TipoCambio, string RowGuid)
        {
            XmlDocument doc = new XmlDocument();
            var ele = doc.CreateElement("C_Monedas");
            doc.AppendChild(ele);

            var pro2 = doc.CreateElement("MonedaId");
            pro2.InnerText = MonedaId.ToString();
            ele.AppendChild(pro2);

            var pro3 = doc.CreateElement("Descripcion");
            pro3.InnerText = Descripcion;
            ele.AppendChild(pro3);

            var pro4 = doc.CreateElement("TipoCambio");
            pro4.InnerText = TipoCambio.ToString();
            ele.AppendChild(pro4);

            var pro5 = doc.CreateElement("RowGuid");
            pro5.InnerText = RowGuid;
            ele.AppendChild(pro5);

            doc.Save(Path.Combine(XmlClass.DEFAULT_FOLDER_XML, "C_Monedas" + RowGuid + ".xml"));
        }

        public static void SaveXmlOperacionHilos(int OperacionId, int HiloId, int Indice, int Arriba, string RowGuid)
        {
            XmlDocument doc = new XmlDocument();
            var ele = doc.CreateElement("C_OperacionHilos");
            doc.AppendChild(ele);

            var pro2 = doc.CreateElement("OperacionId");
            pro2.InnerText = OperacionId.ToString();
            ele.AppendChild(pro2);

            var pro3 = doc.CreateElement("HiloId");
            pro3.InnerText = HiloId.ToString();
            ele.AppendChild(pro3);

            var pro4 = doc.CreateElement("Indice");
            pro4.InnerText = Indice.ToString();
            ele.AppendChild(pro4);

            var pro5 = doc.CreateElement("Arriba");
            pro5.InnerText = Arriba.ToString();
            ele.AppendChild(pro5);

            var pro6 = doc.CreateElement("RowGuid");
            pro6.InnerText = RowGuid.ToString();
            ele.AppendChild(pro6);

            doc.Save(Path.Combine(XmlClass.DEFAULT_FOLDER_XML, "C_OperacionHilos" + RowGuid + ".xml"));
        }

        public static void SaveXmlOperaciones(int OperacionId, string NumOper, string Descripcion,
                                            int AreaId, string TipoOper, double Tiempo, double Consumo, int TipoMaquinaId, double Produccion, double Costoop,
                                            int Orden, int SueldoId, double Factor, double ConsumoArriba, double ConsumoAbajo, double Costura,
                                            int Activo, string RowGuid)
        {
            XmlDocument doc = new XmlDocument();
            var ele = doc.CreateElement("C_Operaciones");
            doc.AppendChild(ele);

            var pro1 = doc.CreateElement("OperacionId");
            pro1.InnerText = OperacionId.ToString();
            ele.AppendChild(pro1);

            var pro2 = doc.CreateElement("NumOper");
            pro2.InnerText = NumOper;
            ele.AppendChild(pro2);

            var pro3 = doc.CreateElement("Descripcion");
            pro3.InnerText = Descripcion;
            ele.AppendChild(pro3);

            var pro4 = doc.CreateElement("AreaId");
            pro4.InnerText = AreaId.ToString();
            ele.AppendChild(pro4);

            var pro5 = doc.CreateElement("TipoOper");
            pro5.InnerText = TipoOper;
            ele.AppendChild(pro5);

            var pro6 = doc.CreateElement("Tiempo");
            pro6.InnerText = Tiempo.ToString();
            ele.AppendChild(pro6);

            var pro7 = doc.CreateElement("Consumo");
            pro7.InnerText = Consumo.ToString();
            ele.AppendChild(pro7);

            var pro8 = doc.CreateElement("TipoMaquinaId");
            pro8.InnerText = TipoMaquinaId.ToString();
            ele.AppendChild(pro8);

            var pro9 = doc.CreateElement("Produccion");
            pro9.InnerText = Produccion.ToString();
            ele.AppendChild(pro9);

            var pro10 = doc.CreateElement("Costoop");
            pro10.InnerText = Costoop.ToString();
            ele.AppendChild(pro10);

            var pro11 = doc.CreateElement("Orden");
            pro11.InnerText = Orden.ToString();
            ele.AppendChild(pro11);

            var pro12 = doc.CreateElement("SueldoId");
            pro12.InnerText = SueldoId.ToString();
            ele.AppendChild(pro12);

            var pro13 = doc.CreateElement("Factor");
            pro13.InnerText = Factor.ToString();
            ele.AppendChild(pro13);

            var pro14 = doc.CreateElement("ConsumoArriba");
            pro14.InnerText = ConsumoArriba.ToString();
            ele.AppendChild(pro14);

            var pro15 = doc.CreateElement("ConsumoAbajo");
            pro15.InnerText = ConsumoAbajo.ToString();
            ele.AppendChild(pro15);

            var pro16 = doc.CreateElement("Costura");
            pro16.InnerText = Costura.ToString();
            ele.AppendChild(pro16);

            var pro17 = doc.CreateElement("Activo");
            pro17.InnerText = Activo.ToString();
            ele.AppendChild(pro17);

            var pro18 = doc.CreateElement("RowGuid");
            pro18.InnerText = RowGuid;
            ele.AppendChild(pro18);

            doc.Save(Path.Combine(XmlClass.DEFAULT_FOLDER_XML, "C_Operaciones" + RowGuid + ".xml"));
        }

        public static void SaveXmlPantallas(string Descripcion, int Indice, string Menu, string RowGuid)
        {
            XmlDocument doc = new XmlDocument();
            var ele = doc.CreateElement("C_Pantallas");
            doc.AppendChild(ele);

            var pro1 = doc.CreateElement("Indice");
            pro1.InnerText = Descripcion;
            ele.AppendChild(pro1);

            var pro2 = doc.CreateElement("Indice");
            pro2.InnerText = Indice.ToString();
            ele.AppendChild(pro2);

            var pro3 = doc.CreateElement("Menu");
            pro3.InnerText = Menu;
            ele.AppendChild(pro3);

            var pro4 = doc.CreateElement("RowGuid");
            pro4.InnerText = RowGuid;
            ele.AppendChild(pro4);

            doc.Save(Path.Combine(XmlClass.DEFAULT_FOLDER_XML, "C_Pantallas" + RowGuid + ".xml"));
        }

        public static void SaveXmlParametros(int Jornada, decimal TipoCambio, string RowGuid)
        {
            XmlDocument doc = new XmlDocument();
            var ele = doc.CreateElement("C_Parametros");
            doc.AppendChild(ele);

            var pro1 = doc.CreateElement("Jornada");
            pro1.InnerText = Jornada.ToString();
            ele.AppendChild(pro1);

            var pro2 = doc.CreateElement("TipoCambio");
            pro2.InnerText = TipoCambio.ToString();
            ele.AppendChild(pro2);

            var pro3 = doc.CreateElement("RowGuid");
            pro3.InnerText = RowGuid;
            ele.AppendChild(pro3);

            doc.Save(Path.Combine(XmlClass.DEFAULT_FOLDER_XML, "C_Parametros" + RowGuid + ".xml"));
        }
    }
}
