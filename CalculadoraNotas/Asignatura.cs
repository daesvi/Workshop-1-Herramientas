using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraNotas
{
    public class Asignatura
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

        private bool validarPorcentaje()
        {
            return contarPorcentaje() <= 1;
        }

        private double promedio()
        {
            double sumatoriaNotas = 0;
            double sumatoriaPorcentaje = contarPorcentaje();
            foreach (Nota nota in notas)
            {
                sumatoriaNotas += (nota.valor * nota.porcentaje);
            }
            return sumatoriaNotas / sumatoriaPorcentaje;
        }

        public double notasAcumuladas()
        {
            if(this.notas.Count > 0)
            return this.promedio()/this.contarPorcentaje();
            else return 0;
        }

        public double notaDeseada(double notaRequerida)
        {
            if (notas.Count > 0)
            {
                if (validarPorcentaje()) return (notaRequerida - promedio()) / (1 - contarPorcentaje());
                else return promedio();
            }
            else return 0;
        }
    }
}
