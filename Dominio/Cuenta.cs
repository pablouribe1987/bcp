namespace Dominio
{
    public class Cuenta
    {
       public int CuentaId{get;set;}
       public decimal monto {get;set;}
       public string moneda_origen{get;set;}
       public string moneda_destino{get;set;}
       public decimal monto_con_tipo_de_cambio{get;set;}
       public decimal tipo_de_cambio{get;set;}

    }
}