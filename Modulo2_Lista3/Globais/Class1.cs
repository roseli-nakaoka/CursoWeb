using System;
using System.Collections.Generic;
using Interface;

namespace Globais
{
    public class Global
    {

        public static List<ILivro> livros = new List<ILivro>();
        public static List<IPessoa> pessoas = new List<IPessoa>();
        public static List<IEmprestimo> emprestimos = new List<IEmprestimo>();

    }
}
