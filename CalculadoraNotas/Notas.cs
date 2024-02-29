using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraNotas
{
    public class Notas
    {
        public string Nombre
        {
            get; set;
        }
        public double Porcentaje
        {
            get; set;
        }
        public double Valor        {
            get; set;
        }
    public Notas(string nombre, double valor, double porcentaje)
        {
            this.Nombre = nombre;
            this.Valor = valor;
            this.Porcentaje = porcentaje /100;
        }
    }
}
