using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.Cuentas
{
    public class nuevo
    {
        public class ejecutar: IRequest
        {
         public int CuentaId{get;set;}
       public decimal monto {get;set;}
       public string moneda_origen{get;set;}
       public string moneda_destino{get;set;}
       public decimal? monto_con_tipo_de_cambio{get;set;}
       public decimal? tipo_de_cambio{get;set;}
        }
        public class manejador : IRequestHandler<ejecutar>
        {
         private readonly CuentaContext _context;
            public manejador(CuentaContext context)
            {
                _context= context;
                        
            } 

         public async Task<Unit> Handle(ejecutar request, CancellationToken cancellationToken)
            {
               var cuenta  = new Cuenta{
                   monto=request.monto,
                   CuentaId=request.CuentaId,
                   moneda_origen=request.moneda_origen,
                   moneda_destino=request.moneda_destino

               } ;
               _context.Cuenta.Add(cuenta);
               var valor = await _context.SaveChangesAsync(); 
               if (valor>0)
               {
                   return Unit.Value;
               }

               throw new System.Exception("No se pudo insertar la cuenta");
            }
        }


    }
}