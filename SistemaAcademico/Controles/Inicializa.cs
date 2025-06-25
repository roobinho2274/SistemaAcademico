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
                Console.WriteLine("" +
                    "\t\t-----Sistema academico TOP-------\n" +
                    "\t\t\t1 - Cadastra alunos\n" +
                    "\t\t\t2 - Exibir todos alunos\n" +
                    "\t\t\t3 - Apaga aluno\n" +
                    "\t\t\t4 - Exibir aluno\n" +
                    "\t\t\t5 - Cadastra nota de aluno\n" +
                    "\t\t\t0 - Sair");
                op = Convert.ToInt16(Console.ReadLine());

                EscolheFuncao();

            } while (op != 0);
        }
        private void EscolheFuncao()
        {
            switch (op)
            {
                case 1: // Cadastrar Aluno
                    var alunoC = ControleAluno.CadastraAluno();
                    if (Alunos.ContainsKey(alunoC.Matricula))
                    {
                        Console.WriteLine("Aluno já cadastrado!");
                    }
                    else
                    {
                        Alunos.Add(alunoC.Matricula, alunoC);
                        Console.WriteLine("Aluno cadastrado com sucesso!");
                    }
                    break;

                case 2: // Exibir Todos os Alunos
                    if (Alunos.Count == 0)
                    {
                        Console.WriteLine("Nenhum aluno cadastrado.");
                    }
                    else
                    {
                        foreach (var aluno in Alunos.Values)
                        {
                            ControleAluno.ImprimeDados(aluno);
                        }
                    }
                    break;

                case 3: // Apagar Aluno
                    Console.WriteLine("Digite o número de matrícula do aluno para apagar:");
                    int apaga = Convert.ToInt32(Console.ReadLine());
                    ControleAluno.Apaga(Alunos, apaga);
                    break;

                                     
                case 4: // Exibir um Aluno
                    Console.WriteLine("Digite o número de matrícula do aluno: ");
                    int matriculaExibir = Convert.ToInt32(Console.ReadLine());

                    if (Alunos.ContainsKey(matriculaExibir))
                    {
                        ControleAluno.ImprimeDados(Alunos[matriculaExibir]);
                    }
                    else
                    {
                        Console.WriteLine("Aluno não encontrado!");
                    }
                    break;
                    
                default:
                    Console.WriteLine("Opção inválida!!");
                    break;
            }
        }

    }
}
