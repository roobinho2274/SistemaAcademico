using SistemaAcademico.Modelos;
using System;
using System.Linq;

namespace SistemaAcademico.Controles
{
    public class ControleAluno
    {
        public Aluno CadastraAluno()
        {
            Aluno aluno = new Aluno();

            Console.WriteLine("Nome: ");
            aluno.Nome = Console.ReadLine();
            Console.WriteLine("Matricula: ");
            aluno.Matricula = Convert.ToInt32(Console.ReadLine());
            for (int i = 0;i<4 ;i++)
            {
                LancarNotas(new Random().Next(0, 10), aluno);
            }

            return aluno;
        }
        public void ImprimeDados(Aluno aluno)
        {
            Console.WriteLine($"\n\n" +
                $"\t\t---Dados---\n" +
                $"\t\tAluno:\t\t{aluno.Nome}\n" +
                $"\t\tMatricula:\t{aluno.Matricula}\n" +
                $"\t\t\n----------------------\n" +
                $"\t\tNotas:\n");

            for (int i = 0; i < aluno.Notas.Count; i++)
            {
                Console.WriteLine(
                    $"\t\t\t{i} => {aluno.Notas[i]}\n");
            }

            Console.WriteLine("\t\t\n------------------\n" +
                $"\t\tMédia {aluno.Media}\n" +
                $"\t\t----------------------------");
        }

        public void LancarNotas(double pNota, Aluno aluno)
        {
            aluno.Notas.Add(pNota);
            CalculaMedia(aluno);
        }

        private void CalculaMedia(Aluno aluno)
        {
            var qtdNotas = aluno.Notas.Count;

            var soma = aluno.Notas.Sum();

            aluno.Media = soma / qtdNotas;
        }
        public void ApagarAluno()
        {
            Console.WriteLine($"Qual aluno deseja apagar ?");
        }
    }
}
