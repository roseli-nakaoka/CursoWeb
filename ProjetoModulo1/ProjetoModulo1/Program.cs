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

        static void Main(string[] args)
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

            candidatos.Add(new Candidato("Luizinho", 23));
            candidatos.Add(new Candidato("Zezinho", 45));        }

        //--------------------------------------------------------------------------
        // MAIN -> AcessarMenuPrincipal Static Method to get access to the Main Menu
        //--------------------------------------------------------------------------

        private static void AcessarMenuPrincipal()        {            StringBuilder menu1 = new StringBuilder();

            int opt1 = -1;

            menu1.Append("\n----------------------------------------");
            menu1.Append("\n1 - ELEIÇÕES");
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
            int opt2 = -1;
            bool continua = false;

            menu2.Append("\n1 – Candidato 1");
            menu2.Append("\n2 – Candidato 2");
            menu2.Append("\n3 – Nulo");
            menu2.Append("\n4 – Branco\n");

            do
            {
                
                Console.WriteLine(menu2);
                Console.Write("Digite a opção desejada: ");
                opt2 = Int32.Parse(Console.ReadLine());

                switch (opt2)
                {
                    case 1:

                        Eleicao.Votar(new Candidato(candidatos[opt2 - 1].Nome, TipoCandidato.Valido));
                        Eleicao.ImprimeCand(new Candidato(candidatos[opt2 - 1].Nome, TipoCandidato.Valido));
                        continua = false;
                        break;

                    case 2:
                    
                        Eleicao.Votar(new Candidato(candidatos[opt2 - 1].Nome, TipoCandidato.Valido));
                        Eleicao.ImprimeCand(new Candidato(candidatos[opt2 - 1].Nome, TipoCandidato.Valido));
                        continua = false;
                        break;
                    case 3:
             
                        Eleicao.Votar(new Candidato(TipoCandidato.Nulo));
                        Eleicao.ImprimeCand(new Candidato(TipoCandidato.Nulo));
                        continua = false;
                        break;
                    case 4:
                        Eleicao.Votar(new Candidato(TipoCandidato.Branco));
                        Eleicao.ImprimeCand(new Candidato(TipoCandidato.Branco));
                        continua = false;
                        break;

                    default:
                        Console.WriteLine("Opção Inválida. Tente novamente.");
                        continua = true;
                        break;
                }

            } while (continua);        }
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
            int total = Program.listaVotacao.Count;
            int candidato1 = Program.listaVotacao.FindAll(item => item.Nome == Program.candidatos[0].Nome).Count;
            int candidato2 = Program.listaVotacao.FindAll(item => item.Nome == Program.candidatos[1].Nome).Count;
            int brancos = Program.listaVotacao.FindAll(item => (int)item.Tipo == 1).Count;
            int nulos = Program.listaVotacao.FindAll(item => (int)item.Tipo == 2).Count;
            string vencedor = candidato1 > candidato2 ? "Candidato 1" : "Candidato 2";
            if (candidato1 == candidato2) vencedor = "Empate";

            Console.WriteLine("\nRESULTADO DAS ELEIÇÕES\n");
            Console.WriteLine($"total de votos: {total}");
            Console.WriteLine($"porcentagem de brancos: {(100 * (float) brancos / total).ToString("0.00")} %");
            Console.WriteLine($"porcentagem de nulos: {(100 * (float) nulos / total).ToString("0.00")} %");
            Console.WriteLine($"votos por candidato: Candidato 1: {candidato1} / Candidato 2: {candidato2}");
            Console.WriteLine($"candidato vencedor: {vencedor}");

        }

        public static void ImprimeCand(Candidato candidato)
        {
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


        public Candidato(string nome, TipoCandidato tipo)
        {
            Nome = nome;
            Numero = Program.candidatos[Program.candidatos.FindIndex(item => item.Nome == this.Nome)].Numero;
            Tipo = tipo;
        }

        public Candidato(TipoCandidato tipo)
        {
            Tipo = tipo;
        }


        public Candidato(string nome, int numero)
        {
            Nome = nome;
            Numero = numero;
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
