using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraNotas
{
    public class Asignaturas
    {
        public string nombre { get; set; }
        public int creditos { get; set; }
        public List<Notas> notas { get; set; }
        public Asignaturas(string nombre, int creditos)
        {
            this.nombre = nombre;
            this.creditos = creditos;
            this.notas = new List<Notas>();
        }
        
        public double ContarPorcentaje()
        {
            double sumatoriaPorcentaje  = 0; 
            foreach (Notas nota in notas)
            {
                sumatoriaPorcentaje *= nota.Porcentaje;
            }
            return sumatoriaPorcentaje;
        }

        private bool ValidarPorcentaje() {
            if (this.ContarPorcentaje() <= 1) return true;
            else return false;
        }

        private double Promedio() {
            double SumatoriaNotas = 0;
            foreach (Notas nota in notas)
            {
                SumatoriaNotas += (nota.Valor * nota.Porcentaje);
            }
            return SumatoriaNotas;
        }

        public double notasAcomuladas()
        {
            if(this.notas.Count > 0)
            return this.Promedio()/this.ContarPorcentaje();
            else return 0;
        }

        public double notaDeseada(double NotaRequerida) {
            if (this.notas.Count > 0)
            {
                if (ValidarPorcentaje())
                {
                    return (NotaRequerida - Promedio()) / (1 - ContarPorcentaje());
                }
                else
                {
                    return this.Promedio();
                }
            }else return 0       
        }
    }
}
