using System;
using System.Collections.Generic;
using System.Text;

namespace CLRSincroniza
{
    public static class WSConsts
    {
        public const string URL = "https://sicrodbservice.maceesoft.com/SincroDBService.asmx";
        public const string URI = "http://SicroDBService";
        public const int TIMEOUT = ((1000 * 30) * 2);

        public const string SOAP_ACTION_C_ALMACEN = URI + "/SincronizarC_Almacen";
        public const string SOAP_ACTION_C_AREA_MODULO = URI + "/SincronizarC_AreaModulo";
        public const string SOAP_ACTION_C_AREAS = URI + "/SincronizarC_Areas";
        public const string SOAP_ACTION_C_BIHORARIOS = URI + "/SincronizaC_Bihorarios";
        public const string SOAP_ACTION_C_ACTICULOS = URI + "/SincronizaC_Articulos";
        public const string SOAP_ACTION_C_AREA_RPT_ESTATUS = URI + "/SincronizarC_AreasRptEstatus";
        public const string SOAP_ACTION_C_CONCEPTOS = URI + "/SincronizaC_Conceptos";
        public const string SOAP_ACTION_C_CONCEPTOSP = URI + "/SincronizaC_ConceptosP";
        public const string SOAP_ACTION_C_EMPRESAP = URI + "/SincronizaC_EmpresaP";
        public const string SOAP_ACTION_C_EMPRESAS = URI + "/SincronizaC_Empresas";
        public const string SOAP_ACTION_C_GROSORAGUJAS = URI + "/SincronizaC_GrosorAgujas";
        public const string SOAP_ACTION_C_HILO = URI + "/SincronizaC_Hilos";
        public const string SOAP_ACTION_C_LINEAS = URI + "/SincronizaC_Lineas";
        public const string SOAP_ACTION_C_MAQUINARIA = URI + "/SincronizaC_Maquinaria";
        public const string SOAP_ACTION_C_MARCAS = URI + "/SincronizaC_Marcas";
        public const string SOAP_ACTION_C_MARCASAGUJAS = URI + "/SincronizaC_MarcasAgujas";
        public const string SOAP_ACTION_C_MODELOAGUJAS = URI + "/SincronizaC_ModeloAgujas";
        public const string SOAP_ACTION_C_MODULOS = URI + "/SincronizaC_Modulos";
        public const string SOAP_ACTION_C_MODENAS = URI + "/SincronizaC_Monedas";
        public const string SOAP_ACTION_C_OPERACIONHILOS = URI + "/SincronizaC_OperacionHilos";
        public const string SOAP_ACTION_C_OPERACIONES = URI + "/SincronizaC_Operaciones";
        public const string SOAP_ACTION_C_PANTALLAS = URI + "/SincronizaC_Pantallas";
        public const string SOAP_ACTION_C_PARAMETROS = URI + "/SincronizaC_Parametros";
    }
}
