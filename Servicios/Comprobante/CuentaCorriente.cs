using Aplicacion.Constantes;
using Dominio.Entidades;
using IServicio.Configuracion;
using IServicios.Comprobante.DTOs;
using IServicios.Contador;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Servicios.Comprobante
{
    public class CuentaCorriente : Comprobante
    {

        private readonly IContadorServicio _contadorServicio;
        private readonly IConfiguracionServicio _configuracionServicio;

        public CuentaCorriente() : base()
        {
            _contadorServicio = ObjectFactory.GetInstance<IContadorServicio>();
            _configuracionServicio = ObjectFactory.GetInstance<IConfiguracionServicio>();

        }

        public override long Insertar(FacturaDto comprobante)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    int numeroComprobante = 0;

                    tran.Complete();
                    return 0;
                }
                catch
                {
                    tran.Dispose();
                    throw new Exception("Ocurrio un error grave al grabar la Factura");
                }
            }
        }
    }
}
// 36 3