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
                    "\t\t\t5 - Cadastra nota de aluno\n\"" +
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
                    
                    Console.Clear();
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
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;

                case 3:
                    
                    Console.Clear();
                    if (Alunos.Count == 0)
                    {
                        Console.WriteLine("Nenhum aluno para apagar.");
                    }
                    else
                    {
                        Console.WriteLine("Alunos cadastrados:");
                        foreach (var aluno in Alunos)
                        {
                            Console.WriteLine($"Matrícula: {aluno.Key}, Nome: {aluno.Value.Nome}");
                        }

                        Console.Write("\nDigite a matrícula do aluno que deseja apagar: ");
                        if (int.TryParse(Console.ReadLine(), out int matriculaApagar))
                        {
                            if (Alunos.ContainsKey(matriculaApagar))
                            {
                                Alunos.Remove(matriculaApagar);
                                Console.WriteLine("Aluno removido com sucesso.");
                            }
                            else
                            {
                                Console.WriteLine("Matrícula não encontrada.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida.");
                        }
                    }
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;

                case 4:
                    
                    Console.Clear();
                    if (Alunos.Count == 0)
                    {
                        Console.WriteLine("Nenhum aluno cadastrado.");
                    }
                    else
                    {
                        Console.WriteLine("Alunos cadastrados:");
                        foreach (var aluno in Alunos)
                        {
                            Console.WriteLine($"Matrícula: {aluno.Key}, Nome: {aluno.Value.Nome}");
                        }

                        Console.Write("\nDigite a matrícula do aluno que deseja visualizar: ");
                        if (int.TryParse(Console.ReadLine(), out int matriculaBusca))
                        {
                            if (Alunos.ContainsKey(matriculaBusca))
                            {
                                ControleAluno.ImprimeDados(Alunos[matriculaBusca]);
                            }
                            else
                            {
                                Console.WriteLine("Matrícula não encontrada.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida.");
                        }
                    }
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
