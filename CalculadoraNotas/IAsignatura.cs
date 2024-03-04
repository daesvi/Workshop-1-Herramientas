using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraNotas
{
    public interface IAsignatura
    {
        double contarPorcentaje();
        double notasAcumuladas();
        double notaDeseada(double notaRequerida);
    }
}
