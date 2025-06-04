using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaAcademico.Modelos
{
    public class Aluno
    {
        private string nome;
        public int matricula;

        List<double> notas;
        private double media;
                public Aluno(string pNome, int pMatricula)
        {
            nome = pNome;
            matricula = pMatricula;
            notas = new List<double>();
            media = 0;
        }

        public void LancarNotas(double pNota)
        {
            notas.Add(pNota);
            CalculaMedia();
        }

        private void CalculaMedia()
        {
            var qtdNotas = notas.Count;

            var soma = notas.Sum();

            media = soma / qtdNotas;
        }

        public void ImprimeDados()
        {
            Console.WriteLine($"\n\n" +
                $"\t\t---Dados---\n" +
                $"\t\tAluno:\t\t{nome}\n" +
                $"\t\tMatricula:\t{matricula}\n" +
                $"\t\t\n----------------------\n" +
                $"\t\tNotas:\n");

            for (int i = 0; i < notas.Count(); i++)
            {
                Console.WriteLine(
                    $"\t\t\t{i} => {notas[i]}\n");
            }

            Console.WriteLine("\t\t\n------------------\n" +
                $"\t\tMédia {media}\n" +
                $"\t\t----------------------------");
        }
    }
}
