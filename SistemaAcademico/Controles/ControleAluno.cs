using SistemaAcademico.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaAcademico.Controles
{
    public class ControleAluno
    {
        //cadastra aluno
        public Aluno CadastraAluno()
        {
            Aluno aluno = new Aluno();

            Console.WriteLine("Nome: ");
            aluno.Nome = Console.ReadLine();
            Console.WriteLine("Matricula: ");
            aluno.Matricula = Convert.ToInt32(Console.ReadLine());

            for (int i=0; i<4; i++)
            {
                LancarNotas(new Random().Next(0, 10), aluno);
            }

            return aluno;
        }

        //imprime dados
        public void ImprimeDados(Aluno aluno)
        {
            Console.WriteLine($"\n" +
                $"\t\t---Dados---\n" +
                $"\t\tAluno:\t\t{aluno.Nome}\n" +
                $"\t\tMatricula:\t{aluno.Matricula}\n" +
                $"\t\tNotas:\n");

            for (int i = 0; i < aluno.Notas.Count; i++)
            {
                Console.WriteLine($"\t\t\t{i} => {aluno.Notas[i]}\n");
            }

            Console.WriteLine("\t\t\n------------------\n" +
                $"\t\tMédia {aluno.Media}\n" +
                $"\t\t----------------------------");
        }

        //apaga
        public void Apaga(Dictionary<int, Aluno> alunos, int matricula)
        {
            var alunoToRemove = alunos.FirstOrDefault(a => a.Value.Matricula == matricula);
            if (alunoToRemove.Equals(default(KeyValuePair<int, Aluno>)))
            {
                Console.WriteLine("Aluno não encontrado.");
            }
            else
            {
                alunos.Remove(alunoToRemove.Key);
                Console.WriteLine("Aluno apagado com sucesso!");
            }
        }


        //exibir alunos
        public void matriculaExibir(List<Aluno> alunos)
        {
            Console.WriteLine("---Alunos---");
            foreach (var aluno in alunos)
            {
                Console.WriteLine($"Nome: {aluno.Nome}, Matrícula: {aluno.Matricula}");
            }
        }

        // calcula nota
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
    }
}
