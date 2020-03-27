using System;
using System.Collections.Generic;

namespace Interface
{
    // Interface ILivro

    public interface ILivro
    {
        public string GetTombo();

        public string GetTitulo();

        public string GetAutor();

        public void DeletarLivro(ILivro livro, List<ILivro> livros);

    }

    // Interface IPessoa

    public interface IPessoa
    {
        public int GetCpf();

        public string GetNome();

        public string GetEmail();

        public void DeletarPessoa(IPessoa pessoa, List<IPessoa> listaPessoa);

    }

    // Interface IEmprestimo

    public interface IEmprestimo
    {
        public string GetId();

        public string GetData();

        public ILivro GetLivro();

        public IPessoa GetPessoa();
       
    }


}
