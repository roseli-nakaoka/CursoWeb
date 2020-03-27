using System;
using System.Collections.Generic;
using Interface;


namespace Negocio
{
    public static class Biblioteca
    {
        // Metodo para Procurar um livro
        public static ILivro ProcurarLivro(string tombo, List<ILivro> livros)
        {

            ILivro result = livros.Find(x => x.GetTombo() == tombo);
            return result;
        }

        // Metodo para Procurar uma Pessoa
        public static IPessoa ProcurarPessoa(int cpf, List<IPessoa> pessoas)
        {
            IPessoa result = pessoas.Find(x => x.GetCpf() == cpf);
            return result;
        }

        //Metodo para Procurar um Empréstimo pelo ID de emprestimo
        public static IEmprestimo ProcurarEmprestimo(string id, List<IEmprestimo> emprestimos)
        {
            IEmprestimo result = emprestimos.Find(x => x.GetId() == id);   
            return result;
        }

        //Metodo para Procurar um Empréstimo por CPF do usuário
        public static IEmprestimo ProcurarEmprestimoUsuario(int cpf, List<IEmprestimo> emprestimos)
        {
            IEmprestimo result = emprestimos.Find(x => x.GetPessoa().GetCpf() == cpf);
            return result;
        }

        //Metodo para Procurar um Empréstimo pelo Tombo do livro
        public static IEmprestimo ProcurarEmprestimoLivro(string tombo, List<IEmprestimo> emprestimos)
        {
            IEmprestimo result = emprestimos.Find(x => x.GetLivro().GetTombo() == tombo);
            return result;
        }

        // Métoo para Validar um Livro (Efetuado Antes do Cadastro)
        public static void ValidarLivro(string titulo, string autor, List<ILivro> livros, out bool valido)
        {
            valido = true;
        
            if (livros != null && livros.Count > 0)
            {
                foreach (var item in livros)
                {
                   
                    if (titulo == item.GetTitulo() && autor == item.GetAutor())
                    {
                        valido = false;
                        break;
                    }

                }
            }

            //return valido;

        }

        // Método para Validar uma Pessoa (Efetuado Antes do Cadastro)
        public static void ValidarPessoa(int cpf, List<IPessoa> pessoas, out bool valido)
        {
            valido = true;

            if (pessoas != null && pessoas.Count > 0)
            {
                foreach (var item in pessoas)
                {
                    
                    if (cpf == item.GetCpf())
                    {
                        valido = false;
                        break;
                    }

                }
            }

        }

        // Método para adicionar o emprestimo na Lista de Emprestimos
        public static void Emprestar(IEmprestimo emprestimo, List<IEmprestimo> lista)
        {
            lista.Add(emprestimo);
        }

        // Método para devolver o livro, removendo-o da Lista de Emprestimos
        public static bool Devolver(string id, List<IEmprestimo> emprestimos)
        {
            
            bool res = emprestimos.Remove(emprestimos.Find(x => x.GetId() == id));

            return res;
        
        }


    }
}
