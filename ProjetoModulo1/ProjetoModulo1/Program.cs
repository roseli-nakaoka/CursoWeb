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
        // MAIN -> CriarCandidatos Static Method to add Candidates
        //------------------------------------------------------------

        private static void CriarCandidatos()        {
            candidatos.Add(new Candidato("Luizinho", 23, TipoCandidato.Valido));
            candidatos.Add(new Candidato("Zezinho", 45, TipoCandidato.Valido));            candidatos.Add(new Candidato("Manuca", 33, TipoCandidato.Valido));            candidatos.Add(new Candidato("Nulo", 0, TipoCandidato.Nulo));            candidatos.Add(new Candidato("Branco", 999, TipoCandidato.Branco));        }

        //--------------------------------------------------------------------------
        // MAIN -> AcessarMenuPrincipal Static Method to get access to the Main Menu
        //--------------------------------------------------------------------------

        private static void AcessarMenuPrincipal()        {            StringBuilder menu1 = new StringBuilder();

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
                        Eleicao.Contagem();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Opção Inválida. Tente novamente.");
                        break;
                }

            } while (opt1 != 3);        }

        //----------------------------------------------------------------
        // MAIN ->  VOTACAO Static Method to get access to the Voting Menu
        //----------------------------------------------------------------


        private static void Votacao()        {            StringBuilder menu2 = new StringBuilder();
            int opt2;
            bool achou = false;

            menu2.Append("\n----------------------------------------");
            menu2.Append("\n*****          VOTAÇÃO             *****");
            menu2.Append("\n----------------------------------------\n");

            foreach (var item in candidatos)
            {
                menu2.Append($"\n{item.Numero}  – {item.Nome}");
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
                        Eleicao.ImprimeCand(item);
                        achou = true;
                        break;
                    }
                }

                if (!achou) Console.WriteLine("Opção Inválida. Tente novamente.");

            } while (!achou);        }
    }

    //--------------------------------------------------
    // ELEICAO Static Class 
    //--------------------------------------------------


    static class Eleicao
    {
        //------------------------------------------------------------------------------------
        // ELEICAO Static Class  -> VOTAR Public static Method to add the vote to listaVotacao
        //------------------------------------------------------------------------------------

        public static void Votar(Candidato candidato)
        {
            Program.listaVotacao.Add(candidato);
            Console.WriteLine("Voto computado com sucesso.");
        }

        //------------------------------------------------------------------------------------
        // ELEICAO Static Class -> CONTAGEM Public static Method to counting of votes
        //------------------------------------------------------------------------------------

        public static void Contagem()
        {
            StringBuilder res = new StringBuilder();

            int total = Program.listaVotacao.Count;

            List <int> apuracao = new List<int>();

            // Calculate the total of votes for each candidate included in "cadidatos" List
            // and stores it in "apuracao" Array.
            // "apuração" follows the same index order as "candidatos"

            for (int i = 0; i <= Program.candidatos.Count - 1; i++)
            {
                int votos = Program.listaVotacao.FindAll(item => item.Nome == Program.candidatos[i].Nome).Count;
                apuracao.Add(votos);
            }

            // Find the maximum number of votes among all the candidates (except nulos e brancos) 

            int max = 0;
            int indmax = 0;
            string vencedor = "";

            for (int i = 0; i <= apuracao.Count - 3; i++)
            {
                if (apuracao[i] > max)
                {
                    max = apuracao[i];
                    indmax = i;
                }
            }

            // Figure out if there was a draw

            int repete = apuracao.GetRange(0, apuracao.Count - 2).FindAll(item => item == max).Count;

            if (repete > 1 )
                vencedor = "Empate";
            else
                vencedor = Program.candidatos[indmax].Nome;

            Console.WriteLine(repete);
            Console.WriteLine(indmax);
            Console.WriteLine(vencedor);

            // Print out the election results

            res.Append("\nRESULTADO DAS ELEIÇÕES\n");
            res.Append($"\nTotal de votos: {total}");
            res.Append($"\nVotos por candidato: ");
            for (int i = 0; i <= apuracao.Count - 1; i++)
            {
                if ((int)Program.candidatos[i].Tipo == 0)
                    res.Append($"\n{Program.candidatos[i].Nome}: {apuracao[i]}");
                else if ((int)Program.candidatos[i].Tipo == 1 || (int)Program.candidatos[i].Tipo == 2)
                    res.Append($"\nPorcentagem de {Program.candidatos[i].Nome}: {(100 * (float)apuracao[i] / total).ToString("0.00")} %");
            }
            res.Append($"\n\nCandidato vencedor: {vencedor}");

            Console.WriteLine(res);
        }

        public static void ImprimeCand(Candidato candidato)
        {
            if (candidato.Nome == "")
                Console.WriteLine($"Tipo: {candidato.Tipo}\n");
            else
                Console.WriteLine($"\nNome: {candidato.Nome} Numero: {candidato.Numero} Tipo: {candidato.Tipo}\n");

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
