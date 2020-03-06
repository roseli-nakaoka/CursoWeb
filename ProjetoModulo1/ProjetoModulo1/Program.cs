//--------------------------------------------------------------------------------------------
// ProjetoModulo1 - Adding candidates to the list, candidate voting, counting of votes
//                  and presenting election results.
//-------------------------------------------------------------------------------------------
//
// class Program
//  - static void Main()
//    - public static void CriarCandidatos()
//    - public static void AcessarMenuPrincipal()
//      - public static void Votacao()
//      - public static void Contagem()
//
// static class Eleicao
// - public static void Votar(Candidato candidato)
// - public static List<int> Apuracao()
// - public static string Vencedor(List<int> list)
// - public static void ResultadoEleicao(List<int> list, string winner)
//
// class Candidato
// - public Candidato(string nome, int numero, TipoCandidato tipo)
//
// enum TipoCandidato
//--------------------------------------------------------------------------------------------

using System;
using System.Text;
using System.Collections.Generic;

namespace ProjetoModulo1
{

    class Program

    {
        public static List<Candidato> candidatos = new List<Candidato>();
        public static List<Candidato> listaVotacao = new List<Candidato>();

        //----------------------------
        // MAIN Program
        //----------------------------

        static void Main()
        {
            try
            {
                CriarCandidatos();
                AcessarMenuPrincipal();
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro encontrado!\nMESSAGE: " + e.Message + "\nTASK: " + e.StackTrace);
            }

        }

        //------------------------------------------------------------
        // MAIN -> CriarCandidatos - Method to add Candidates
        //------------------------------------------------------------

        public static void CriarCandidatos()

        // TipoCandidato Branco and Nulo must be added at the botton of the list
        {
            candidatos.Add(new Candidato("Luizinho", 23, TipoCandidato.Valido));
            candidatos.Add(new Candidato("Zezinho", 45, TipoCandidato.Valido));            candidatos.Add(new Candidato("Nulo", 999, TipoCandidato.Nulo));            candidatos.Add(new Candidato("Branco", 0, TipoCandidato.Branco));
        }

        //--------------------------------------------------------------------------
        // MAIN -> AcessarMenuPrincipal - Method to get access to the Main Menu
        //--------------------------------------------------------------------------

        public static void AcessarMenuPrincipal()        {            StringBuilder menu1 = new StringBuilder();

            int opt1;

            menu1.Append("\n----------------------------------------");
            menu1.Append("\n*****          ELEIÇÕES            *****");
            menu1.Append("\n----------------------------------------\n");
            menu1.Append("\n1 - Votar");            menu1.Append("\n2 - Conferir contagem");            menu1.Append("\n3 - Sair\n");

            do
            {
                Console.WriteLine(menu1);
                Console.Write("Digite a opção desejada: ");
                opt1 = Int32.Parse(Console.ReadLine());

                switch (opt1)
                {
                    case 1:
                        Votacao();
                        break;
                    case 2:
                        Contagem();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Opção Inválida. Tente novamente.");
                        break;
                }

            } while (opt1 != 3);        }

        //----------------------------------------------------------------
        // MAIN ->  VOTACAO - Method to get access to the Voting Menu
        //----------------------------------------------------------------


        public static void Votacao()        {            StringBuilder menu2 = new StringBuilder();
            int opt2;
            bool achou = false;

            menu2.Append("\n----------------------------------------");
            menu2.Append("\n*****          VOTAÇÃO             *****");
            menu2.Append("\n----------------------------------------\n");

            foreach (var item in candidatos)
            {
                menu2.Append($"\n{item.Numero.ToString("000")} – {item.Nome}");
            }
 
            do
            {
                Console.WriteLine(menu2);
                Console.Write("\nDigite a opção desejada: ");
                opt2 = Int32.Parse(Console.ReadLine());

                foreach (var item in candidatos)
                {
                    if (opt2 == item.Numero)
                    {
                        Eleicao.Votar(item);
                        achou = true;
                        break;
                    }
                }

                if (!achou) Console.WriteLine("Opção Inválida. Tente novamente.");

            } while (!achou);        }


        //------------------------------------------------------------------------------------
        // MAIN -> CONTAGEM - Method to counting of votes
        //------------------------------------------------------------------------------------

        public static void Contagem()
        {

            List<int> apuracao = Eleicao.Apuracao();
            string vencedor = Eleicao.Vencedor(apuracao);
            Eleicao.ResultadoEleicao(apuracao, vencedor);

        }

    }

    //--------------------------------------------------
    // ELEICAO Static Class 
    //--------------------------------------------------


    static class Eleicao
    {
        //------------------------------------------------------------------------------------
        // ELEICAO Static Class  -> VOTAR - Method to add the vote to listaVotacao
        //------------------------------------------------------------------------------------

        public static void Votar(Candidato candidato)
        {
            Program.listaVotacao.Add(candidato);
            Console.WriteLine("Voto computado com sucesso.");

            if (candidato.Nome == "")
                Console.WriteLine($"Tipo: {candidato.Tipo}\n");
            else
                Console.WriteLine($"\nNome: {candidato.Nome} Numero: {candidato.Numero} Tipo: {candidato.Tipo}\n");
        }

        //------------------------------------------------------------------------------------
        // ELEICAO Static Class -> APURACAO - Method to store the total of votes per candidate
        //
        // Notes: - Calculate the total of votes for each candidate included in "cadidatos" List
        //          and stores it in "apuracao" List.
        //        - "apuração" follows the same index order as "candidatos"
        //------------------------------------------------------------------------------------

        public static List<int> Apuracao()
        {
            List<int> apuracao = new List<int>();

            for (int i = 0; i <= Program.candidatos.Count - 1; i++)
            {
                int votos = Program.listaVotacao.FindAll(item => item.Nome == Program.candidatos[i].Nome).Count;
                apuracao.Add(votos);
            }

            return apuracao;
        }

        //------------------------------------------------------------------------------------
        // ELEICAO Static Class -> VENCEDOR - Method to find the winner
        //------------------------------------------------------------------------------------


        public static string Vencedor(List<int> list)
        { 
            // Find the maximum number of votes among all the candidates (except nulos e brancos) 

            int max = 0;
            int indmax = 0;
            
            for (int i = 0; i <= list.Count - 3; i++)
            {
                if (list[i] > max)
                {
                    max = list[i];
                    indmax = i;
                }
            }

            // Figure out if there was a draw

            int repete = list.GetRange(0, list.Count - 2).FindAll(item => item == max).Count;

            return (repete>1)? "Empate": Program.candidatos[indmax].Nome;

        }

        //------------------------------------------------------------------------------------
        // ELEICAO Static Class -> RESULTADOELEICAO - Method to print out the election results
        //------------------------------------------------------------------------------------


        public static void ResultadoEleicao(List<int> list, string winner)
        {

            // Print out the election results

            StringBuilder res = new StringBuilder();

            int total = Program.listaVotacao.Count;

            res.Append("\nRESULTADO DAS ELEIÇÕES\n");
            res.Append($"\nTotal de votos: {total}\n");
            res.Append($"\nVotos por candidato: \n");

            for (int i = 0; i <= Program.candidatos.Count - 1; i++)
            {
                if ((int)Program.candidatos[i].Tipo == 0)
                    res.Append($"{Program.candidatos[i].Nome}: {list[i]}\n");
                else if ((int)Program.candidatos[i].Tipo == 1 || (int)Program.candidatos[i].Tipo == 2)
                    res.Append($"\nPorcentagem de {Program.candidatos[i].Nome}: {(100 * (float)list[i] / total).ToString("0.00")} %");
            }
            res.Append($"\n\nCANDIDATO VENCEDOR: {winner}");

            Console.WriteLine(res);

        }
       
    }

    //--------------------------------------------------
    // Class CANDIDATO
    //--------------------------------------------------

    class Candidato

    {
        public string Nome { get; set; }

        public int Numero { get; }

        public TipoCandidato Tipo { get; set; }

        //--------------------------------------------------
        // Class CANDIDATO -> Class constructors
        //--------------------------------------------------

        public Candidato(string nome, int numero, TipoCandidato tipo)
        {
            Nome = nome;
            Numero = numero;
            Tipo = tipo;
        }
    }

    //---------------------------------------------------------
    // Enum - Enum TipoCandidato with valid Voting Status
    //---------------------------------------------------------

    enum TipoCandidato
    {
        Valido = 0,
        Branco = 1,
        Nulo = 2
    }

}
