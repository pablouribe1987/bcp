using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.Cuentas;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    //http://localhost:5000/api/Cuentas
    [Route("api/[controller]")]
    [ApiController]
        public class CuentasController :ControllerBase
    {
        private readonly IMediator _mediator;
        public CuentasController(IMediator mediator)
        {
            _mediator = mediator;

        }
[HttpGet]
public async Task<ActionResult<List<Cuenta>>> Get()
{
return await _mediator.Send(new Consulta.ListaCuentas());
}

[HttpPut("{id}")]
public async Task<ActionResult<Unit>> Editar(int id,Editar.Ejecuta data)
{
    data.CuentaId = id;
    return await _mediator.Send(data);

}

[HttpPost]
public async Task<ActionResult<Unit>> Crear(nuevo.ejecutar data)
{
    
    return await _mediator.Send(data);

}


    }
}