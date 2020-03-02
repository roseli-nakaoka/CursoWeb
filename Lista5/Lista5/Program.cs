using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;

namespace Lista5
{
    class ExercicioLista5
    {
        static void Main(string[] args)
        {
            int exerc = -1;

            do
            {
                //# Lógica de Programação - 5
                //### Collection

                Console.WriteLine();
                Console.Write($"Digite o número do exercicio (<1-4> ou <0-SAIR>): ");
                exerc = Int32.Parse(Console.ReadLine());
 
                switch (exerc)
                {
                    //1 - Crie um programa que colete 5 números inseridos pelo usuário e armazene estes números em algum tipo de lista.Imprima a lista nas seguintes formas:
                    case 1:
                        Exercise1();
                        break;

                    //2 - Crie um programa que colete 5 nome de site e suas urls inseridos pelo usuário e armazene em algum tipo de lista. O nome do site e a url devem ser requisitados ao usuário em duas perguntas diferentes. Ex. “Digite o nome do site:” < enter > “Digite a url do site” < enter >
                    //  Após armazenar os dados acima, desenvolva os passos:
                    case 2:
                        Exercise2();
                        break;

                    //3 - Crie um programa que monte um menu com as opções 1 - Inserir número, 2 - Remover número e 3 - sair.
                    case 3:
                        Exercise3();
                        break;

                    //4 - Crie um programa que monte um menu com as opções 1 - Inserir número, 2 - Remover número e 3 - sair.
                    case 4:
                        Exercise4();
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }

            } while (exerc != 0);

        }


        //**************************************************
        // Method to Call the Main Program of each Exercise 
        //**************************************************


        //***************************
        // Method to Call Exercise 1 
        //***************************


        static void Exercise1()
        { 
            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("EXERCÍCIO 1 - Impressão de Lista");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();

            List<int> numList = new List<int>();
            numList = PopulateList(5);

            //1 - Original, na ordem digitada.
            PrintList("Impressao na Ordem digitada", numList.ToArray());

            //2 - Ordenada crescente
            numList.Sort();
            PrintList("Impressao na Ordem crescente", numList.ToArray());

            //3 - Ordenada decrescente
            numList.Reverse();
            PrintList("Impressao na Ordem decrescente", numList.ToArray());

            //4 - Total de itens.
            SumList(numList);

        }

        //***************************
        // Method to Call Exercise 2
        //***************************


        static void Exercise2()
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("EXERCÍCIO 2 - Cria uma lista e Faz a busca pelo nome do site");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine();

            Dictionary<string, string> site = new Dictionary<string, string>();
            site = PopulateDict(5);

            //4 - Volte ao menu do passo 1 para nova escolha.
            int opt2;

            do
            {
                //1 - Crie um menu com duas opções. 1 - Achar um site e 2 Sair.
                opt2 = PrintMenuSite();

                //2 - Caso escolhido 1: requisite ao usuário o nome do site.
                if (opt2 == 1)
                    //3 - Após digitado, busca na lista e imprima qual a url do site digitado. 
                    FindSite(site);

                //5 - Caso escolhi 2, fechar o programa.    
            } while (opt2 != 2);

        }

        //***************************
        // Method to Call Exercise 3
        //***************************

        static void Exercise3()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("EXERCÍCIO 3 - Adiciona Elementos e Remove o ULTIMO elemento da lista");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine();

            Stack<int> myStack = new Stack<int>();
          
            int opt3;

            do
            {
                opt3 = PrintMenu();

                //1 - Caso escolhido 1: requisite ao usuário um número e armazene.Imprima a lista sempre após a inserção.Volte para o menu.
                if (opt3 == 1)
                {
                    AddItemStack(myStack);
                    PrintList("Lista de números", myStack.ToArray());
                }

                //2 - Caso escolhido 2, remova da lista o último número inserido.Imprima a lista após a exclusão. Volte para o menu.
                else if (opt3 == 2)
                {

                    RemoveItemStack(myStack);
                    PrintList("Lista de números", myStack.ToArray());
                }

                //3 - Caso escolhi 3, fechar o programa.

            } while (opt3 != 3);


        }

        //***************************
        // Method to Call Exercise 4
        //***************************

        static void Exercise4()
        {

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("EXERCÍCIO 4 - Adiciona Elementos e Remove o PRIMEIRO elemento da lista");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine();

            int opt4;

            Queue<int> myqueue = new Queue<int>();
    
            do
            {
                opt4 = PrintMenu();

                //1 - Caso escolhido 1: requisite ao usuário um número e armazene.Imprima a lista sempre após a inserção.Volte para o menu.
                if (opt4 == 1)
                {
                    AddItemQueue(myqueue);
                    PrintList("Lista de números", myqueue.ToArray());
                }

                //2 - Caso escolhido 2, remova da lista o primeiro número inserido.Imprima a lista após a exclusão. Volte para o menu.
                else if (opt4 == 2)
                {
                    RemoveItemQueue(myqueue);
                    PrintList("Lista de números", myqueue.ToArray());
                }

                //3 - Caso escolhi 3, fechar o programa.

            } while (opt4 != 3);
        }

        //******************************
        // Exercise 1 - Methods
        //******************************

        static List<int> PopulateList(int n)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Digite o número {i + 1}: ");
                int num = Int32.Parse(Console.ReadLine());
                list.Add(num);
            }

            return list;

        }

        static void SumList(List<int> list)
        {

            Console.WriteLine();
            Console.WriteLine($"Soma Total dos itens: {list.Sum()}");

        }


        static void PrintList(string title, int [] list)
        {
            Console.WriteLine();
            Console.WriteLine(title);
            Console.WriteLine();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        //******************************
        // Exercise 2 - Methods
        //******************************

        static Dictionary<string, string> PopulateDict(int n)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Digite o nome do site {i + 1}: ");
                string nome = Console.ReadLine();

                Console.Write($"Digite a URL do site {i + 1}: ");
                string url = Console.ReadLine();

                Console.WriteLine();

                if (!dict.ContainsKey(nome))
                    dict.Add(nome, url);
                else
                {
                    Console.Write("O nome do site já foi cadastrado!\n");
                    i--;
                }
                    
            }
            return dict;
        }

        static int PrintMenuSite()
        {
            StringBuilder str = new StringBuilder();
            str.Clear();

            str.Append($"\n1 - Achar um site ");
            str.Append($"\n2 - Sair");
            str.Append($"\n");
            Console.WriteLine(str);
            Console.Write("Digite a opção desejada: ");
            return Int32.Parse(Console.ReadLine());
        }

        static void FindSite(Dictionary<string, string> dict)
        {
            Console.Write($"Digite o nome do site: ");
            string nome = Console.ReadLine();

            if (dict.ContainsKey(nome) == true)
                Console.WriteLine($"URL: {dict[nome]}");
            else
                Console.WriteLine("O site não foi encontrado !!!");
        }


        //*************************************
        // Exercise 3 and Exercise 4 - Methods
        //*************************************


        static int PrintMenu()

        {
            StringBuilder str = new StringBuilder();
         
            str.Clear();
            str.Append($"\n1 - Inserir número");
            str.Append($"\n2 - Remover número");
            str.Append($"\n3 - Sair");
            str.Append($"\n");
            Console.WriteLine(str);
            Console.Write("Digite a opção desejada: ");
            return Int32.Parse(Console.ReadLine());

        }

        //*************************************
        // Exercise 3 - Methods
        //*************************************

        static void AddItemStack(Stack<int> stack)
        {
            Console.Write($"Digite um número: ");
            int num = Int32.Parse(Console.ReadLine());
            stack.Push(num);

        }

        static void RemoveItemStack(Stack<int> stack)
        { 
            if (stack.Count > 0)
                stack.Pop();
            else
                Console.WriteLine("Não é possível remover itens. A Lista está vazia !");
        }

        //*************************************
        // Exercise 4 - Methods
        //*************************************

        static void AddItemQueue(Queue<int> queue)
        {
            Console.Write($"Digite um número: ");
            int num = Int32.Parse(Console.ReadLine());
            queue.Enqueue(num);

        }

        static void RemoveItemQueue(Queue<int> queue)
        {
            if (queue.Count > 0)
                queue.Dequeue();
            else
                Console.WriteLine("Não é possível remover itens. A Lista está vazia !");
        }

    }
}