using System.Collections.Generic;

namespace SistemaAcademico.Modelos
{
    public class Aluno
    {
        public string Nome { get; set; }
        public int Matricula { get; set; }
        public List<double> Notas { get; set; }
        public double Media { get; set; }

    }
}
