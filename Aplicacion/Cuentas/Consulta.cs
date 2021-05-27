using System.Collections.Generic;
using MediatR;
using Dominio;
using System.Threading.Tasks;
using System.Threading;
using Persistencia;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Aplicacion.Cuentas
{
    public class Consulta
    {
        public class ListaCuentas : IRequest<List<Cuenta>>{}

        public class Manejador : IRequestHandler<ListaCuentas, List<Cuenta>>
        {
            
            private readonly CuentaContext _Context;
             public Manejador(CuentaContext Context){
                 _Context = Context;
             if (!_Context.Cuenta.Any())   
       {  
         _Context.Cuenta.Add(new Cuenta   
                  { CuentaId = 1, monto = 100.10m,moneda_origen="S",
                  moneda_destino="D",monto_con_tipo_de_cambio=50.5m,tipo_de_cambio=3.3m});  
         _Context.SaveChanges();   
       }  

             }

            public async Task<List<Cuenta>> Handle(ListaCuentas request, CancellationToken cancellationToken)
            {
             var cuenta = await  _Context.Cuenta.ToListAsync();
             return cuenta;
            }
        }
    }
}