using System;
using System.Collections.Generic;

using SistemaAcademico.Modelos;

namespace SistemaAcademico.Controles
{
    /// <summary>
    /// Inicializa o projeto
    /// </summary>
    public class Inicializa
    {
        ControleAluno ControleAluno = new ControleAluno();
        private Dictionary<int, Aluno> Alunos;
        private int op;
        public Inicializa()
        {
            Alunos = new Dictionary<int, Aluno>();
            op = 1;
        }

        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("" +
                    "\t\t-----Sistema academico TOP-------\n" +
                    "\t\t\t1 - Cadastra alunos\n" +
                    "\t\t\t2 - Exibir todos alunos\n" +
                    "\t\t\t3 - Apaga aluno\n" +
                    "\t\t\t4 - Exibir aluno\n" +
                    "\t\t\t5 - Cadastra nota de aluno\n" +
                    "\t\t\t0 - Sair\n");
                op = Convert.ToInt16(Console.ReadLine());

                EscolheFuncao();

            } while (op != 0);
        }

        private void EscolheFuncao()
        {
            switch (op)
            {
                case 1:
                    var alunoC = ControleAluno.CadastraAluno();
                    Alunos.Add(alunoC.Matricula, alunoC);
                    break;
                case 2:
                    foreach (var aluno in Alunos)
                    {
                        ControleAluno.ImprimeDados(aluno.Value);
                    }
                    Console.WriteLine("Pressione qualquer tecla para continuar......");
                    Console.ReadLine();
                    break;

                case 3:
                    Console.Write("Digite o número de matrícula do aluno que você deseja remover: ");
                    int matriculaRemover = Convert.ToInt32(Console.ReadLine());

                    bool removido = ControleAluno.RemoverAluno(matriculaRemover, Alunos);

                    if (removido)
                        Console.WriteLine("Aluno removido com sucesso! :)");
                    else
                        Console.WriteLine("Aluno não encontrado! :(");

                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;

                case 4:
                    Console.Write("Digite a matrícula do aluno que você deseja buscar: ");
                    int matriculaExibir = Convert.ToInt32(Console.ReadLine());

                    Aluno alunoEncontrado = ControleAluno.BuscarAluno(matriculaExibir, Alunos);

                    if (alunoEncontrado != null)
                    {
                        Console.WriteLine("Aluno encontrado! :)");
                        ControleAluno.ImprimeDados(alunoEncontrado);
                        
                    }
                    else
                    {
                        Console.WriteLine("Aluno não encontrado! :(");
                    }
                       

                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;

            }
        }
    }
}
