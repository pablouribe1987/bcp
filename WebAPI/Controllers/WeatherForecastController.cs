using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistencia;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //http://localhost:5000/Cuenta
    public class WeatherForecastController : ControllerBase
    {
        private readonly CuentaContext context;

        public WeatherForecastController(CuentaContext _context)
        {
            this.context =_context;
             if (!_context.Cuenta.Any())   
       {  
         _context.Cuenta.Add(new Cuenta   
                  { CuentaId = 1, monto = 100.13m,moneda_origen="S",
                  moneda_destino="D",monto_con_tipo_de_cambio=50.5m,tipo_de_cambio=10.234m});  
         _context.SaveChanges();   
       }  
        }
       
           [HttpGet]
           public IEnumerable<Cuenta> Get(){
               return context.Cuenta.ToList();
           }
         //  public IEnumerable<string> Get(){
        //string [] nombres = new[]{"Fabian","Rolando","maria","rebeca"};
        //return nombres;

          // }


    }
}
