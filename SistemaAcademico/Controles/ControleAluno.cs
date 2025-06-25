using SistemaAcademico.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaAcademico.Controles
{
    public class ControleAluno
    {
        // Lista interna para armazenar os alunos cadastrados
        private List<Aluno> alunos = new List<Aluno>();

        public Aluno CadastraAluno()
        {
            Aluno aluno = new Aluno();

            Console.WriteLine("Nome: ");
            aluno.Nome = Console.ReadLine();
            Console.WriteLine("Matricula: ");
            aluno.Matricula = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < 4; i++)
            {
                LancarNotas(new Random().Next(0, 10), aluno); // Lança notas aleatórias entre 0 e 10
            }
            alunos.Add(aluno); // Adiciona o aluno à lista

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

       
        public bool ApagarAluno(int matricula)
        {
            var aluno = alunos.FirstOrDefault(a => a.Matricula == matricula);
            if (aluno != null)
            {
                alunos.Remove(aluno);
                Console.WriteLine($"Aluno com matrícula {matricula} removido com sucesso.");
                return true;
            }
            else
            {
                Console.WriteLine($"Aluno com matrícula {matricula} não encontrado.");
                return false;
            }
        }

        
        public void ImprimirAlunoPorMatricula(int matricula)
        {
            var aluno = alunos.FirstOrDefault(a => a.Matricula == matricula);
            if (aluno != null)
            {
                ImprimeDados(aluno);
            }
            else
            {
                Console.WriteLine($"Aluno com matrícula {matricula} não encontrado.");
            }
        }
    }
}
