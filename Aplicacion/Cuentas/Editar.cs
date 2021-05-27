using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.Cuentas
{
    public class Editar
    {
        public class Ejecuta :IRequest
        {
       public int CuentaId{get;set;}
       public decimal? monto {get;set;}
       public string moneda_origen{get;set;}
       public string moneda_destino{get;set;}
       public decimal? monto_con_tipo_de_cambio{get;set;}
       public decimal? tipo_de_cambio{get;set;}
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CuentaContext _context;
            public Manejador(CuentaContext context)
            {
                _context= context;
                     if (!_context.Cuenta.Any())   
       {  
         _context.Cuenta.Add(new Cuenta   
                  { CuentaId = 1, monto = 100.10m,moneda_origen="S",
                  moneda_destino="D",
                  monto_con_tipo_de_cambio=10,
                  tipo_de_cambio=3.3m});  
         _context.SaveChanges();   
       } 
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var cuenta = await _context.Cuenta.FindAsync(request.CuentaId);
                if (cuenta==null)
                {
                    throw new Exception("El curso no existe");
                }

                cuenta.moneda_destino = request.moneda_destino ?? cuenta.moneda_destino ; 
                cuenta.moneda_origen = request.moneda_origen ?? cuenta.moneda_origen ; 
                cuenta.monto =  request.monto ?? cuenta.monto ; 
                cuenta.monto_con_tipo_de_cambio=cuenta.monto * cuenta.tipo_de_cambio;
               var resultado= await _context.SaveChangesAsync();

               if (resultado>0)
               return Unit.Value;
                  throw new Exception("No se guardaron los cambios en el curso");
               
            }
        }
    }
}