using System;
using System.Web.Services;
using SincronizaWS.Metodos;

[WebService(Namespace = "http://SicroDBService")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class SincroDBService : System.Web.Services.WebService
{
    public SincroDBService()
    {

    }
    
    [WebMethod]
    public string SincronizaC_Almacen(decimal AlmacenId, string Almacen, string Ubicacion, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_Almacen(AlmacenId, Almacen, Ubicacion, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_AreaModulo(int ModuloId, int? AreaId, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_AreaModulo(ModuloId, AreaId, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_Areas(int AreaId, string Descripcion, int? Orden, decimal? Bono, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_Areas(AreaId, Descripcion, Orden, Bono, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_AreasRptEstatus(int AreaOrdnId, int? Orden, int? OrdenDelantero, int? OrdenTrasero, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_AreasRptEstatus(AreaOrdnId, Orden, OrdenDelantero, OrdenTrasero, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_Articulos(decimal ArticuloId, decimal? LineaId, decimal? MonedaId, string Clave, string Descripcion, decimal? Costo,
           string unidad, string Ubicacion, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_Articulos(ArticuloId, LineaId, MonedaId, Clave, Descripcion, Costo, unidad, Ubicacion, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_Bihorarios(int BihorarioId, DateTime? HoraInicio, DateTime? HoraFin, decimal? CantHrsLab, DateTime? HoraIniReal,
           DateTime? HoraFinReal, DateTime? HoraIniRealAnt, DateTime? HoraFinRealAnt, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_Bihorarios(BihorarioId, HoraInicio, HoraFin, CantHrsLab, HoraIniReal, HoraFinReal, HoraIniRealAnt, HoraFinRealAnt, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_Conceptos(int ConceptoId, string Tipo, string Concepto, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_Conceptos(ConceptoId, Tipo, Concepto, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_ConceptosP(int ConceptoPId, string Descripcion, int? Tipo, decimal? Monto, string Formula, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_ConceptosP(ConceptoPId, Descripcion, Tipo, Monto, Formula, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_EmpresaP(int EmpresaId, int? Dias, int? PorMax, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_EmpresaP(EmpresaId, Dias, PorMax, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_Empresas(int EmpresaId, string Nombre, string NombreBd, string Dirección, string Telefono, string Fax, string Mail,
                                           string rfc, int? Jornada, int? Pago, decimal? Porcentajeop, decimal? Porcentajearea, int? TotalPiezas, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_Empresas(EmpresaId, Nombre, NombreBd, Dirección, Telefono, Fax, Mail, rfc, Jornada, Pago, Porcentajeop, Porcentajearea, TotalPiezas, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_GrosorAgujas(string Grosor, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_GrosorAgujas(Grosor, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_Hilos(int HiloId, string Clave, string Descripcion, string Calibre, string CveColor, string Prov, string Marca, string Tipo,
           decimal Yardas, decimal? Costo, int? unidad, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_Hilos(HiloId, Clave, Descripcion, Calibre, CveColor, Prov, Marca, Tipo, Yardas, Costo, unidad, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_Lineas(decimal LineaId, string Descripcion, int? ValidaSolomon, int? ValidaCatalogo, string Catalogo, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_Lineas(LineaId, Descripcion, ValidaSolomon, ValidaCatalogo, Catalogo, RowGuid));

    }

    [WebMethod]
    public string SincronizaC_Maquinaria(int MaquinariaId, int? TipoMaquinaId, string NoInventario, string Descripcion, string Marca, string Modelo, string Serie,
          int Propiedad, int? Ubicacion, int? ModuloId, string Observaciones, int? Estatus, decimal? Factor, decimal? ConsumoArriba, decimal? ConsumoAbajo, DateTime? FechaAlta,
          int Rentada, decimal? Costo, decimal? ProveedorId, string RowGuid)
    {

        return (SQLMetodos.SincronizaC_Maquinaria(MaquinariaId, TipoMaquinaId, NoInventario, Descripcion, Marca, Modelo, Serie, Propiedad, Ubicacion, ModuloId,
                                                Observaciones, Estatus, Factor, ConsumoArriba, ConsumoAbajo, FechaAlta, Rentada, Costo, ProveedorId, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_Marcas(string MarcaId, string Marca, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_Marcas(MarcaId, Marca, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_MarcasAgujas(string Marca, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_MarcasAgujas(Marca, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_ModeloAgujas(string Modelo, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_ModeloAguja(Modelo, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_Modulos(int ModuloId, string Descripcion, decimal? Bono, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_Modulos(ModuloId, Descripcion, Bono, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_Monedas(decimal MonedaId, string Descripcion, decimal? TipoCambio, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_Monedas(MonedaId, Descripcion, TipoCambio, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_Operaciones(int OperacionId, string NumOper, string Descripcion, int? AreaId, string TipoOper, decimal? Tiempo, decimal? Consumo,
                             int TipoMaquinaId, decimal? Produccion, decimal? Costoop, int? Orden, int? SueldoId, decimal? Factor, decimal? ConsumoArriba, decimal? ConsumoAbajo,
                             decimal Costura, int? Activo, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_Operaciones(OperacionId, NumOper, Descripcion, AreaId, TipoOper, Tiempo, Consumo, TipoMaquinaId, Produccion,
                                                    Costoop, Orden, SueldoId, Factor, ConsumoArriba, ConsumoAbajo, Costura, Activo, RowGuid));

    }

    [WebMethod]
    public string SincronizaC_OperacionHilos(int OperacionId, int? HiloId, int? Indice, int? Arriba, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_OperacionHilos(OperacionId, HiloId, Indice, Arriba, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_Pantallas(string Descripcion, int? Indice, string Menu, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_Pantallas(Descripcion, Indice, Menu, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_Personal(int PersonalId, int? ModuloId, int? SueldoId, int? AreaId, int? OperacionId, string Numero, string ApellidoP, string ApellidoM,
                            string Nombre, string Calle, string NumeroExt, string Colonia, string Poblacion, string Ciudad, string Cp, string Telefono, string Emergencia,
                            string TelEmergencia, string Rfc, int? Estatus, DateTime? FecNac, decimal? Dias, decimal? PuestoId, string RowGuid)

    {
        return (SQLMetodos.SincronizaC_Personal(PersonalId, ModuloId, SueldoId, AreaId, OperacionId, Numero, ApellidoP, ApellidoM, Nombre, Calle, NumeroExt, Colonia,
                                               Poblacion, Ciudad, Cp, Telefono, Emergencia, TelEmergencia, Rfc, Estatus, FecNac, Dias, PuestoId, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_PersonalFechas(int PersonalId, int? Tipo, DateTime? Fecha, string RowGuid)
    {

        return (SQLMetodos.SincronizaC_PersonalFechas(PersonalId, Tipo, Fecha, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_Proveedores(string Descripcion, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_Proveedores(Descripcion, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_Puestos(decimal PuestoId, string Puesto, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_Puestos(PuestoId, Puesto, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_PuntasAgujas(string Punta, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_PuntasAgujas(Punta, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_Refacciones(decimal RefaccionId, string Clave, string Descripcion, decimal? MonedaId, decimal? Costo, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_Refacciones(RefaccionId, Clave, Descripcion, MonedaId, Costo, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_Semanas(int SemanaId, DateTime? FechaInicio, DateTime? FechaFinal, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_Semanas(SemanaId, FechaInicio, FechaFinal, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_Sueldos(int SueldoId, string Categoria, decimal? Monto, decimal? Bono, string RowGuid)
    {

        return (SQLMetodos.SincronizaC_Sueldos(SueldoId, Categoria, Monto, Bono, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_Tallas(decimal TallaId, string Largo, string Ancho, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_Tallas(TallaId, Largo, Ancho, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_TiposMaquina(int TipoMaquinaId, string Descripcion, decimal? Factor, decimal? ConsumoArriba, decimal? ConsumoAbajo, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_TiposMaquina(TipoMaquinaId, Descripcion, Factor, ConsumoArriba, ConsumoAbajo, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_TiposRegAguja(int ReAguja, string TipoReg, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_TiposRegAguja(ReAguja, TipoReg, RowGuid));
    }

    [WebMethod]
    public string SincronizaC_Usuarios(int UsuarioId, string Usuario, string Contrasena, string Nombre, int? Activo, string RowGuid)
    {
        return (SQLMetodos.SincronizaC_Usuarios(UsuarioId, Usuario, Contrasena, Nombre, Activo, RowGuid));
    }

    [WebMethod]
    public string SincronizaParametros(int Jornada, decimal? TipoCambio, string RowGuid)
    {
        return (SQLMetodos.SincronizaParametros(Jornada, TipoCambio, RowGuid));
    }

    [WebMethod]
    public string Sincronizarpt_Estatus(int OrdenId, int? Cantidad, int? UsuarioId, string Descripcion, int? OrdenArea, string RowGuid)
    {
        return (SQLMetodos.Sincronizarpt_Estatus(OrdenId, Cantidad, UsuarioId, Descripcion, OrdenArea, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_Agujas(decimal Folio, int? MaquinariaId, decimal? MarcaId, decimal? ModeloId, decimal? GrosorId, decimal? PuntaId, string Motivo,
            DateTime? Fecha, string Observaciones, int? Tipo, int? cancelado, DateTime? FechaCancel, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_Agujas(Folio, MaquinariaId, MarcaId, ModeloId, GrosorId, PuntaId, Motivo, Fecha, Observaciones, Tipo, cancelado, FechaCancel, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_Balanceo(decimal BalanceoId, decimal? EstiloId, DateTime? Fecha, string Observaciones, int? MinTurno, int? Produccion, decimal? porcentaje, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_Balanceo(BalanceoId, EstiloId, Fecha, Observaciones, MinTurno, Produccion, porcentaje, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_BalanceoMaq(decimal BalanceoId, decimal? Renglon, int? TipoMaquinaId, int? Cantidad, int? Invent, int? Dif, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_BalanceoMaq(BalanceoId, Renglon, TipoMaquinaId, Cantidad, Invent, Dif, RowGuid));
    }


    [WebMethod]
    public string SincronizaT_BalanceoOpDet(decimal BalanceoId, int? OperacionId, int? Renglon, decimal? std, decimal? stda, decimal? prodh, decimal? prodt, decimal? tiempon,
            decimal operariost, int? operariorr, decimal? mintd, decimal? desocu, int? maquinas, int? Manuales, int? asistente, int? bultero, int? sup, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_BalanceoOpDet(BalanceoId, OperacionId, Renglon, std, stda, prodh, prodt, tiempon, operariost, operariorr, mintd, desocu, maquinas, Manuales, asistente, bultero, sup, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_BalanceoOtros(decimal BalanceoId, decimal? renglon, string Descripcion, decimal? cant, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_BalanceoOtros(BalanceoId, renglon, Descripcion, cant, RowGuid));

    }

    [WebMethod]
    public string SincronizaT_BalanceoStaf(decimal BalanceoId, decimal? renglon, string Descripcion, decimal? cant, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_BalanceoStaf(BalanceoId, renglon, Descripcion, cant, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_Bitacora(decimal BitacoraId, int? UsuarioId, DateTime? Fecha, DateTime? Hora, string Descripcion, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_Bitacora(BitacoraId, UsuarioId, Fecha, Hora, Descripcion, RowGuid));
    }

    [WebMethod]
    public string SincronizatT_Bultos(decimal BultoId, decimal? NoBulto, string Serie, int? OrdenId, int? Cantidad, DateTime? FechaEnt, decimal? TallaId, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_Bultos(BultoId, NoBulto, Serie, OrdenId, Cantidad, FechaEnt, TallaId, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_CostosMonedas(decimal ArticuloId, decimal? AlmacenId, decimal? MonedaId, decimal? Existencia, decimal? EntradaUnidad, decimal? EntradaValor,
            decimal SalidaUnidad, decimal? SalidaValor, decimal? ExtDum, decimal? CostoPromedio, decimal? CostoReposicion, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_CostosMonedas(ArticuloId, AlmacenId, MonedaId, Existencia, EntradaUnidad, EntradaValor, SalidaUnidad, SalidaValor, ExtDum, CostoPromedio, CostoReposicion, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_Cotizacion(decimal CotizacionId, decimal? EstiloId, string Observaciones, DateTime? FechaCreacion, DateTime? FechaModificacion, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_Cotizacion(CotizacionId, EstiloId, Observaciones, FechaCreacion, FechaModificacion, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_CotizacionDet(decimal CotizacionId, decimal? Renglon, int? Equivalencia, int? HiloId, string Aplic, string Cod, decimal? Metros, decimal? Costo,
           decimal? Total, decimal? TotalConos, decimal? MtsCono, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_CotizacionDet(CotizacionId, Renglon, Equivalencia, HiloId, Aplic, Cod, Metros, Costo, Total, TotalConos, MtsCono, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_Estilos(decimal EstiloId, string Num, string Descripcion, DateTime? FechaAlta, int? Inactivo, DateTime? FechaBaja, string Linea, string Division,
         string Cliente, string Observacion, int? num_metadia, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_Estilos(EstiloId, Num, Descripcion, FechaAlta, Inactivo, FechaBaja, Linea, Division, Cliente, Observacion, num_metadia, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_EstilosDet(decimal EstiloId, decimal? Renglon, int? OperacionId, int? Orden, int? Act, int? OrdenRpt, string Lado, string Etapa, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_EstilosDet(EstiloId, Renglon, OperacionId, Orden, Act, OrdenRpt, Lado, Etapa, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_EstilosDetTeor(decimal EstiloId, decimal? Renglon, int? OperacionId, int? Orden, int? Act, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_EstilosDetTeor(EstiloId, Renglon, OperacionId, Orden, Act, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_EstilosHilosDet(decimal EstiloId, decimal? Renglon, int? Orden, int? HiloId, int? Arriba, int? Act, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_EstilosHilosDet(EstiloId, Renglon, Orden, HiloId, Arriba, Act, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_EstilosHilosDetTeor(decimal EstiloId, decimal? Renglon, int? Orden, int? HiloId, int? Arriba, int? Act, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_EstilosHilosDetTeor(EstiloId, Renglon, Orden, HiloId, Arriba, Act, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_EstilosMarcas(int EstiloId, string MarcaId, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_EstilosMarcas(EstiloId, MarcaId, RowGuid));

    }

    [WebMethod]
    public string SincronizaT_EtiqFecPag(decimal EtiquetaId, DateTime? FechaPago, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_EtiqFecPag(EtiquetaId, FechaPago, RowGuid));

    }

    [WebMethod]
    public string SincronizaT_Etiquetas(decimal EtiquetaId, decimal? BultoId, int? OperacionId, int? EstiloId, int? Renglon, int? PersonalId, DateTime? Fecha, DateTime? Hora,
                decimal? HojaId, int? Escaneada, int? Cancelada, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_Etiquetas(EtiquetaId, BultoId, OperacionId, EstiloId, Renglon, PersonalId, Fecha, Hora, HojaId, Escaneada, Cancelada, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_Folios(decimal Folio, string Tipo, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_Folios(Folio, Tipo, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_HojasControl(decimal HojaId, int? PersonalId, DateTime? Fecha, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_HojasControl(HojaId, PersonalId, Fecha, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_Inventario(decimal ArticuloId, decimal? AlmacenId, decimal? Existencia, decimal? EntradaUnidad, decimal? EntradaValor, decimal? SalidaUnidad, decimal? SalidaValor, decimal? ExtDum,
                decimal CostoPromedio, decimal? CostoReposicion, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_Inventario(ArticuloId, AlmacenId, Existencia, EntradaUnidad, EntradaValor, SalidaUnidad, SalidaValor, ExtDum, CostoPromedio, CostoReposicion, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_MantoMaq(decimal MantoId, int? MaquinariaId, string Fecha, string Motivo, decimal? Total, int? Tipo, int? Cancelado, decimal? MotCancelado,
                DateTime? FechaCancel, decimal? MonedaId, decimal? TipoCambio, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_MantoMaq(MantoId, MaquinariaId, Fecha, Motivo, Total, Tipo, Cancelado, MotCancelado, FechaCancel, MonedaId, TipoCambio, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_MantoMaqDet(decimal MantoId, int? Renglon, decimal? Cantidad, decimal? RefaccionId, decimal? Costo, decimal? CostoPesos, decimal? TipoCambio,
            string Observacion, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_MantoMaqDet(MantoId, Renglon, Cantidad, RefaccionId, Costo, CostoPesos, TipoCambio, Observacion, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_MovimientosAlm(decimal MomientoId, string Tipo, decimal? AlmacenId, DateTime? Fecha, string Referencia, decimal? TotalU, decimal? TotalC, decimal? MonedaId,
                decimal? TotalCDef, int? Cancelado, int? Aplicado, decimal? TipoCambio, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_MovimientosAlm(MomientoId, Tipo, AlmacenId, Fecha, Referencia, TotalU, TotalC, MonedaId, TotalCDef, Cancelado, Aplicado, TipoCambio, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_MovimientosAlmacenDet(decimal MovimientoId, string Tipo, decimal? Renglon, decimal? ArticloId, decimal? Cantidad, decimal? Costo, decimal? Importe, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_MovimientosAlmacenDet(MovimientoId, Tipo, Renglon, ArticloId, Cantidad, Costo, Importe, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_MovimientosMaquinaria(int MovimientoId, int? MaquinariaId, int? ConceptoId, DateTime? Fecha, int? Origen, int? Destino, string Entrega, string Recibe,
        string Autoriza, string Transportista, string Observaciones, int? Cancelado, DateTime? FechaCancel, string Motivo, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_MovimientosMaquinaria(MovimientoId, MaquinariaId, ConceptoId, Fecha, Origen, Destino, Entrega, Recibe, Autoriza, Transportista, Observaciones,
                           Cancelado, FechaCancel, Motivo, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_Nomina(decimal NominaId, string Semana, DateTime? FechaInicio, DateTime? FechaFin, DateTime? Fecha, decimal? TotalNomina, int? Cancelado,
          string Motivo, DateTime? FechaCancel, decimal? BalanceoId, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_Nomina(NominaId, Semana, FechaInicio, FechaFin, Fecha, TotalNomina, Cancelado, Motivo, FechaCancel, BalanceoId, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_NominaDet(decimal NominaId, decimal? Renglon, int? PersonalId, int? ConceptoPId, decimal? Importe, decimal? Cantidad, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_NominaDet(NominaId, Renglon, PersonalId, ConceptoPId, Importe, Importe, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_OrdenesProduccion(int OrdenId, string NoOrden, string NoPo, string OV, DateTime? FechaAlta, decimal? EstiloId, DateTime? FechaCierre,
            DateTime? FechaCancel, int? Cancelado, string Motivo, string Planta, string Tela, DateTime? FechaCorte, int? Total, int? id_periodo, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_OrdenesProduccion(OrdenId, NoOrden, NoPo, OV, FechaAlta, EstiloId, FechaCierre, FechaCancel, Cancelado, Motivo, Planta,
                           Tela, FechaCorte, Total, id_periodo, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_OrdEnPlanta(decimal OrdenId, int? Cantidad, DateTime? Fecha, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_OrdEnPlanta(OrdenId, Cantidad, Fecha, RowGuid));

    }

    [WebMethod]
    public string SincronizaT_OrdenProduccionDet(int OrdenId, int? Renglon, decimal? TallaId, int? NoBultos, int? NPiezasXBulto, string Serie, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_OrdenProduccionDet(OrdenId, Renglon, TallaId, NoBultos, NPiezasXBulto, Serie, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_OrdOrdenesProduccion(int OrdenId, int? Orden, string Periodo, int? Auditoria, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_OrdOrdenesProduccion(OrdenId, Orden, Periodo, Auditoria, RowGuid));

    }

    [WebMethod]
    public string SincronizaT_Perfil(int UsuarioId, int? PantallaId, int? Alta, int? Baja, int? Cambio, int? Consulta, int? Depurar,int Firma, int? Imprimir, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_Perfil(UsuarioId, PantallaId, Alta, Baja, Cambio, Consulta, Depurar, Firma, Imprimir, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_PersonalConceptos(int ConceptoPid, int? PersonalId, decimal? Importe, int? Cantidad, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_PersonalConceptos(ConceptoPid, PersonalId, Importe, Cantidad, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_PersonalFaltas(int PersonalId, string Tipo, DateTime? Fecha, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_PersonalFaltas(PersonalId, Tipo, Fecha, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_PersonalFechas(int PersonalId, string Tipo, DateTime? Fecha, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_PersonalFechas(PersonalId, Tipo, Fecha, RowGuid));
    }

    [WebMethod]
    public string SincronizaT_RegistroCorte(int Id, int? BihorarioId, DateTime? Fecha, int? OrdenId, int? piezas, string RowGuid)
    {
        return (SQLMetodos.SincronizaT_RegistroCorte(Id, BihorarioId, Fecha, OrdenId, piezas, RowGuid));                
    }
    

        //***FIN***//

    }
