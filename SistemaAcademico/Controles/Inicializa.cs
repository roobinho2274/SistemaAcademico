using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

using SistemaAcademico.Modelos;

namespace SistemaAcademico.Controles
{
    public class Inicializa
    {
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
                    "\t\t\t5 - Cadastra nota de aluno\\n\"" +
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
                    var alunoC = CadastraAluno();
                    Alunos.Add(alunoC.matricula, alunoC);
                    break;
                case 2:
                    /// [int, aluno]
                    foreach (var aluno in Alunos)
                    {
                        aluno.Value.ImprimeDados();
                    }
                    Console.WriteLine("Pressione qualquer tecla para continuar......");
                    Console.ReadLine();
                    break;
                case 3:
                    break;
                case 4:
                    break;

            }
        }

        private Aluno CadastraAluno()
        {
            // Criar uma instancia de aluno com os dados informados pelo usuário
            return null;//Vai retornar o aluno
        }
    }
}
