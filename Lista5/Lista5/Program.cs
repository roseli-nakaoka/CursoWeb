using System;
using System.Collections.Generic;
using System.Text;

namespace Lista5
{
    class ExercicioLista5
    {
        static void Main(string[] args)
        {
            //# Lógica de Programação - 5

            //### Collection
            //1 - Crie um programa que colete 5 números inseridos pelo usuário e armazene estes números em algum tipo de lista.Imprima a lista nas seguintes formas:
            List<int> numList = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Digite o número {i + 1}: ");
                int num = Int32.Parse(Read());


            }


            


            //1 - Original, na ordem digitada.
    //2 - Ordenada crescente
    //3 - Ordenada decrescente
    //4 - Total de itens.





//2 - Crie um programa que colete 5 nome de site e suas urls inseridos pelo usuário e armazene em algum tipo de lista. O nome do site e a url devem ser requisitados ao usuário em duas perguntas diferentes. Ex. “Digite o nome do site:” < enter > “Digite a url do site” < enter >
//  Após armazenar os dados acima, desenvolva os passos:
    //1 - Crie um menu com duas opções. 1 - Achar um site e 2 Sair.
    //2 - Caso escolhido 1: requisite ao usuário o nome do site.
    //3 - Após digitado, busca na lista e imprima qual a url do site digitado. 
    //4 - Volte ao menu do passo 1 para nova escolha.
    //5 - Caso escolhi 2, fechar o programa.

//3 - Crie um programa que monte um menu com as opções 1 - Inserir número, 2 - Remover número e 3 - sair.
    //1 - Caso escolhido 1: requisite ao usuário um número e armazene.Imprima a lista sempre após a inserção.Volte para o menu.
    //2 - Caso escolhido 2, remova da lista o último número inserido.Imprima a lista após a exclusão. Volte para o menu.
    //3 - Caso escolhi 3, fechar o programa.

//4 - Crie um programa que monte um menu com as opções 1 - Inserir número, 2 - Remover número e 3 - sair.
    //1 - Caso escolhido 1: requisite ao usuário um número e armazene.Imprima a lista sempre após a inserção.Volte para o menu.
    //2 - Caso escolhido 2, remova da lista o primeiro número inserido.Imprima a lista após a exclusão. Volte para o menu.
    //3 - Caso escolhi 3, fechar o programa.
        }
    }
}
