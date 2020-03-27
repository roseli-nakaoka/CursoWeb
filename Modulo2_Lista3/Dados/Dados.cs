using System.Collections.Generic;
using Interface;

namespace Dados
{
    // Classe Livro
    public class Livro : ILivro
    {
        public string Tombo { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }

        public Livro() { }

        public Livro(string tombo, string titulo, string autor)
        {
            Tombo = tombo;
            Titulo = titulo;
            Autor = autor;
        }

        public string GetTombo()
        {
            return Tombo;
        }

        public string GetTitulo()
        {
            return Titulo;

        }

        public string GetAutor()
        {
            return Autor;

        }

        public void DeletarLivro(ILivro livro, List<ILivro> livros)
        {

            livros.Remove(livro);

        }

        //public ILivro BuscaLivro(string tombo, List<ILivro> livros)

        //{
        //    ILivro result = livros.Find(x => x.GetTombo() == tombo);
        //    return result;

        //}

    }

    // Classe Pessoa
    public class Pessoa : IPessoa
    {
        public int Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public Pessoa(int cpf, string nome, string email)
        {
            Cpf = cpf;
            Nome = nome;
            Email = email;
        }

        public void DeletarPessoa(IPessoa pessoa, List<IPessoa> listaPessoa)
        {

            listaPessoa.Remove(pessoa);

        }

        public int GetCpf()
        {
            return Cpf;

        }

        public string GetNome()
        {
            return Nome;

        }

        public string GetEmail()
        {
            return Email;

        }

        
    }

    //Classe Emprestimo

    public class Emprestimo : IEmprestimo
    {
        public string Id { get; set; }
        public string DataEmprestimo { get; set; }
        public ILivro LivroEmprestimo { get; set; }
        public IPessoa PessoaEmprestimo { get; set; }


        public Emprestimo(string id, string dataemp, ILivro livroemp, IPessoa pessoaemp)
        {
            Id = id;
            DataEmprestimo = dataemp;
            LivroEmprestimo = livroemp;
            PessoaEmprestimo = pessoaemp;
        }

        public string GetId()
        {
            return Id;

        }

        public string GetData()
        {
            return DataEmprestimo;

        }

        public ILivro GetLivro()
        {
            return LivroEmprestimo;

        }

        public IPessoa GetPessoa()
        {
            return PessoaEmprestimo;

        }

    }
}
