using IServicio.Articulo.DTOs;
using IServicio.Base;
using IServicio.BaseDto;
using IServicios.Articulo.DTOs;
using System.Collections.Generic;

namespace IServicio.Articulo
{
    public interface IArticuloServicio : IServicioAbm
    {
        int ObtenerSiguienteNroCodigo();
        bool VerificarSiExiste(string datoVerificar, long? Codigo = null);
        DtoBase Obtener(long id);
        IEnumerable<DtoBase> Obtener(string cadenaBuscar, bool mostrarTodos = true);

        IEnumerable<ArticuloVentaDto> ObtenerLooUp(string cadenaBuscar);

        ArticuloVentaDto ObtenerPorCodigo(string Codigo);

        int ActualizarStock(ArticuloDto art, decimal cantidad);
    }
}

