using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraNotas
{
    public class Nota
    {
        public string nombre {get; set;}
        public double porcentaje {get; set;}
        public double valor { get; set;}

        public Nota(string nombre, double valor, double porcentaje)
        {
            this.nombre = nombre;
            this.valor = valor;
            this.porcentaje = porcentaje /100;
        }

        public override string ToString()
        {
            return ($"Nombre: {this.nombre}\nNota: {this.valor}\nPorcentaje: {this.porcentaje * 100}%\n");
        }
    }
}
