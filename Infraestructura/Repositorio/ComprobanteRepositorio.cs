using Dominio.Entidades;
using Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorio
{
    public class ComprobanteRepositorio : Repositorio<Comprobante>, IComprobanteRepositorio
    {
        public ComprobanteRepositorio(DataContext dataContext)
            : base(dataContext)
        {

        }

        public override Comprobante Obtener(long entidadId, string propiedadNavegacion = "")
        {
            var resultado = propiedadNavegacion.Split(new[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).Aggregate<string,
                IQueryable<Comprobante>>(_context.Set<Comprobante>().OfType<Comprobante>(), (current, include)
                => current.Include(include));

            return resultado.FirstOrDefault(x => x.Id == entidadId);
        }

        public override IEnumerable<Comprobante> Obtener(Expression<Func<Comprobante, bool>> filtro = null, string propiedadNavegacion = "")
        {
            var context = ((IObjectContextAdapter)_context).ObjectContext;
            var resultadoClient = context.CreateObjectSet<Comprobante>().OfType<Comprobante>();
            context.Refresh(RefreshMode.ClientWins, resultadoClient);

            var resultado = propiedadNavegacion.Split(new[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).Aggregate<string,
                IQueryable<Comprobante>>(resultadoClient, (current, include) => current.Include(include));

            if (filtro != null) resultado = resultado.Where(filtro);

            return resultado.ToList();
        }
    }
}
