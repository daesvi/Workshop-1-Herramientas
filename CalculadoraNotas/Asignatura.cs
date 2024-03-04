using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraNotas
{
    public class Asignatura : IAsignatura
    {
        public string nombre { get; set; }
        public int creditos { get; set; }
        public List<Nota> notas { get; set; }
        public Asignatura(string nombre, int creditos)
        {
            this.nombre = nombre;
            this.creditos = creditos;
            this.notas = new List<Nota>();
        }
        
        public double contarPorcentaje()
        {
            double sumatoriaPorcentaje = 0;
            foreach (Nota nota in notas)
            {
                sumatoriaPorcentaje += nota.porcentaje;
            }
            return sumatoriaPorcentaje;
        }

        public bool validarPorcentaje()
        {
            return contarPorcentaje() <= 1;
        }

        public override string ToString()
        {
            return ($"Nombre: {this.nombre}\nCreditos: {this.creditos}");
        }

        public string verNotas()
        {
            string sb = "";
            sb += $"## {this.nombre} ##\n";
            if (notas.Count > 0)
            {
                foreach (Nota nota in notas)
                {
                    sb += nota.ToString();
                }
            }
            else sb += "No hay notas";
            return sb;
        }

        private double promedio()
        {
            double SumatoriaNotas = 0;
            foreach (Nota nota in notas)
            {
                SumatoriaNotas += (nota.valor * nota.porcentaje);
            }
            return SumatoriaNotas;
        }

        public double notasAcumuladas()
        {
            if (this.notas.Count > 0 && this.validarPorcentaje())
                return this.promedio() / this.contarPorcentaje();
            else if (this.notas.Count > 0 && !this.validarPorcentaje())
                return this.promedio();
            return 0;
        }

        public double notaDeseada(double notaRequerida)
        {
            if (validarPorcentaje()) return (notaRequerida - this.promedio()) / (1 - this.contarPorcentaje());
            return this.promedio();
        }
    }
}
