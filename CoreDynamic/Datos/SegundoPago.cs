using System;

namespace CoreDynamic
{
    public class SegundoPago
    {
        public SegundoPago(int id, Persona persona, decimal porcentaje, int mes_cierrre, int anio_cierre, DateTime fecha_Inicial, DateTime fecha_Final, int cantidad_Contratos, int contratos_Solventes)
        {
            Id = id;
            this.persona = persona;
            Porcentaje = porcentaje;
            Mes_cierrre = mes_cierrre;
            Anio_cierre = anio_cierre;
            Fecha_Inicial = fecha_Inicial;
            Fecha_Final = fecha_Final;
            Cantidad_Contratos = cantidad_Contratos;
            Contratos_Solventes = contratos_Solventes;
        }

        public int Id { get; set; }
        public Persona persona { get; set; }
        public decimal Porcentaje { get; set; }
        public int Mes_cierrre { get; set; }
        public int Anio_cierre { get; set; }
        public DateTime Fecha_Inicial { get; set; }
        public DateTime Fecha_Final { get; set; }
        public int Cantidad_Contratos { get; set; }
        public int Contratos_Solventes { get; set; }
    }
}


