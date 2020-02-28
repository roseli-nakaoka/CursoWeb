using System;
using System.Text;
using System.Globalization;
using System.Threading;

namespace Exercicios_Lista4
{
    class Lista4
    {
        static Conta[] contas = new Conta[3];
        static bool add = true;

        public static void Main(string[] args)
        {
            //# Lógica de Programação - 4
            //### Classes, metodos, heranca e polimorfismo.
            //1. Crie uma classe Principal que conterá seu método Main.Esta classe deverá conter um while que deverá imprimir o menu abaixo.O programa só deverá fechar caso seja digitado 0.

            //## Escolhe uma opçao ##
            //1 - Criar conta max
            //2 - Criar conta universitaria
            //3 - Imprimir conta
            //4 - Investir
            //0 - Sair

            int opc = -1;
            StringBuilder str = new StringBuilder();

            //2. Após executar a opção 1, 2, 3, 4 o menu deverá ser reimpresso para nova escolha.

            do
            {
                str.Append($"\n1 - Criar conta max");
                str.Append($"\n2 - Criar conta universitaria");
                str.Append($"\n3 - Imprimir conta");
                str.Append($"\n4 - Investir");
                str.Append($"\n0 - Sair");
                str.Append($"\n");
                Console.WriteLine(str);
                Console.Write("Digite a opção desejada: ");
                opc = Int32.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        AddMax();
                        break;
                      
                    case 2:
                        AddUniversitaria();
                        break;
                    case 3:
                        ImprimirContas(contas);
                        break;
                    case 4:
                        InvestirContas();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opção Inválida. Tente novamente!");
                        break;
                }
                str.Clear();

            } while (opc != 0);

        }

        //3. Crie os métodos de Criar Conta Max, Criar Conta Universitaria e Imprimir Conta dentro da classe Principal. Requisite ao usuário todas as informações contidas na classe Conta abaixo.

        public static void AddMax()
        {
            //9. Caso ao adicionar uma nova conta não haja mais espaço no array, imprima a mensagem de lista cheia.

            if (!add)
                Console.WriteLine("Não é possível adicionar nova conta, a lista está cheia");
            else
            {
                Console.Write("Digite o Nome: ");
                string name = Console.ReadLine();
                Console.Write("Digite o Cpf: ");
                string cpf = Console.ReadLine();
                Console.Write("Digite o Email: ");
                string email = Console.ReadLine();
                Console.Write("Digite o Saldo: ");
                Double saldo = Double.Parse(Console.ReadLine());
                DateTime criado = DateTime.Now;
                DateTime modificado = DateTime.Now;
                string id = Guid.NewGuid().ToString();

                ContaMax conta = new ContaMax(id, name, cpf, email, saldo, criado, modificado);

                //8. As contas criadas devem ser armazenadas em um array de 3 posições.Ao escolher no menu a opção 3, todas as contas criadas deverão ser impressas.Diferencie quais são Max e quais são Univerisitária.

                for (int i = 0; i < contas.Length; i++)
                {
                    if (contas[i] == null)
                    {
                        contas[i] = conta;
                        Console.WriteLine("Conta Max Adicionada com sucesso");
                        add = (i == contas.Length - 1) ? false : true;
                        break;
                    }
                }
            }

        }

        public static void AddUniversitaria()
        {
            //9. Caso ao adicionar uma nova conta não haja mais espaço no array, imprima a mensagem de lista cheia.

            if (!add)
                Console.WriteLine("Não é possível adicionar nova conta, a lista está cheia");
            else
            {
                Console.Write("Digite o Nome: ");
                string name = Console.ReadLine();
                Console.Write("Digite o Cpf: ");
                string cpf = Console.ReadLine();
                Console.Write("Digite o Email: ");
                string email = Console.ReadLine();
                Console.Write("Digite o Saldo: ");
                Double saldo = Double.Parse(Console.ReadLine());
                DateTime criado = DateTime.Now;
                DateTime modificado = DateTime.Now;
                string id = Guid.NewGuid().ToString();

                ContaUniversitaria conta = new ContaUniversitaria(id, name, cpf, email, saldo, criado, modificado);

                //8. As contas criadas devem ser armazenadas em um array de 3 posições.Ao escolher no menu a opção 3, todas as contas criadas deverão ser impressas.Diferencie quais são Max e quais são Univerisitária.

                for (int i = 0; i < contas.Length; i++)
                {
                    if (contas[i] == null)
                    {
                        contas[i] = conta;
                        Console.WriteLine("Conta Universitária Adicionada com sucesso");
                        add = (i == contas.Length - 1) ? false : true;
                        break;
                    }
                }
            }
            
        }

        public static void ImprimirContas(Conta[] contas)
        {
            //8. As contas criadas devem ser armazenadas em um array de 3 posições.Ao escolher no menu a opção 3, todas as contas criadas deverão ser impressas.Diferencie quais são Max e quais são Univerisitária.

            for (int i = 0; i < contas.Length; i++)
            {
                if (contas[i] != null)
                {
                    if (contas[i].GetType().Name == "ContaMax")
                    {
                        ContaMax contaMax = (ContaMax)contas[i];
                        contaMax.Imprimir();
                    }
                       
                    else if (contas[i].GetType().Name == "ContaUniversitaria")
                    {
                        ContaUniversitaria contaUniv = (ContaUniversitaria)contas[i];
                        contaUniv.Imprimir();
                    }
                }
                else
                    break;
            }
        }

        //11. Armazene o resultado do investimento dentro do saldo da conta em contexto.Após a tela voltar para o menu, caso seja clicado em 3 Imprimir, o novo valor deverá ser mostrado para a conta que foi realizado o cálculo.

        public static void InvestirContas()
        {
            Console.Write("Entre com o ID da Conta para investimento: ");
            string idref = Console.ReadLine();
            bool achou = false;

            foreach (var item in contas)
            {
                if (item != null)
                {
                    if (idref == item.Id)
                    {
                        item.Saldo = Investimento.Investir(item);
                        Console.WriteLine("Investimento Realizado com Sucesso!");
                        achou = true;
                        break;
                    }
                }
            }
            if (!achou)
                Console.WriteLine("Conta Inexistente");
        }

    }

    //4. Crie uma classe base chamada Conta com os dados abaixo:
    //Saldo, Nome, Cpf, Email, Modificado e Criado. (Define os tipos que você entender ser mais apropriado).

    public class Conta
    {

        //Saldo, Nome, Cpf, Email, Modificado e Criado. (Define os tipos que você entender ser mais apropriado).
        public readonly String Id;
        public String Name { get; set; }
        public String Cpf { get; set; }
        public String Email { get; set; }
        public DateTime Criado { get; set; }
        public DateTime Modificado { get; set; }
        private double saldo;
        public Double Saldo
        {
            get
            {
                return saldo;
            }

            set
            {
                saldo = value;
                Modificado = DateTime.Now;
            }

        }

        public Conta()
        {
        }

        public Conta(string id, string name, string cpf, string email, double saldo, DateTime criado, DateTime modificado)
        {
            Id = id;
            Name = name;
            Cpf = cpf;
            Email = email;
            Saldo = saldo;
            Criado = criado;
            Modificado = modificado;
        }
    }

    //5. Crie duas classes que herdam de Conta.Estas duas classes devem se chamar ContaMax e ContaUniversitaria.Ambas devem ter um método público de impressão de todos os dados do cliente.Exceto a taxa mencionada no item 6 e 7).

    public class ContaMax : Conta
    {
        //6. ContaMax também deverá ter um atributo constante do tipo double chamado Taxa.O valor deverá ser 1.3

        public const Double Taxa = 1.3;

        public ContaMax(string id, string name, string cpf,
            string email, double saldo, DateTime criado, DateTime modificado) : base(id, name, cpf, email, saldo, criado, modificado)
        { }

        public void Imprimir()
        {

            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-Br");
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;

            Console.WriteLine();
            Console.WriteLine("CONTA MAX");
            Console.WriteLine($"Id : {Id}");
            Console.WriteLine($"Nome : {Name}");
            Console.WriteLine($"Cpf : {Cpf}");
            Console.WriteLine($"Email : {Email}");
            Console.WriteLine($"Saldo : {Saldo.ToString("c")}");
            Console.WriteLine($"Data Criado : {Criado.ToString(culture)}");
            Console.WriteLine($"Data Modificado : {Modificado.ToString(culture)}");
            Console.WriteLine();

        }

    }

    public class ContaUniversitaria : Conta
    {
        //7. Contauniversitária também deverá ter um atributo constante do tipo double chamado Taxa.O valor deverá ser 1.1

        public const Double Taxa = 1.1;

        public ContaUniversitaria(string id, string name, string cpf,
            string email, double saldo, DateTime criado, DateTime modificado) : base(id, name, cpf, email, saldo, criado, modificado)
        { }

        public void Imprimir()
        {

            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-Br");
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;

            Console.WriteLine();
            Console.WriteLine("CONTA UNIVERSITÁRIA");
            Console.WriteLine($"Id : {Id}");
            Console.WriteLine($"Nome : {Name}");
            Console.WriteLine($"Cpf : {Cpf}");
            Console.WriteLine($"Email : {Email}");
            Console.WriteLine($"Saldo : {Saldo.ToString("c")}");
            Console.WriteLine($"Data Criado : {Criado.ToString(culture)}");
            Console.WriteLine($"Data Modificado : {Modificado.ToString(culture)}");
            Console.WriteLine();

        }

    }

    //10. Crie uma classe estática chamada Investimento e adicione um método estático chamado Investir.O método estático deverá receber um parametro do tipo Conta. Dentro do método de investir crie uma lógica que utilize a propriedade Saldo e a constante Taxa que retorne um valor double como resultado de um investimento.

    static class Investimento
    {
        public static double Investir(Conta conta)
        {
            double valor = conta.Saldo;
            if (conta.GetType().Name == typeof(ContaMax).Name)
                valor = (ContaMax.Taxa * conta.Saldo);
      
            else if (conta.GetType().Name == typeof(ContaUniversitaria).Name)
                valor = (ContaUniversitaria.Taxa * conta.Saldo);
            return valor;
        }
    }

}

