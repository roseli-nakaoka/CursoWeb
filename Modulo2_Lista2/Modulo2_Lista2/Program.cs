using System;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace Modulo2_Lista2
{
    class Program
    {
        // ****************************
        // Class Program - Main Program
        // ****************************

        static void Main()
        {
            try
            {
                MenuPrincipal();
            }
            catch(Exception e)
            {
                Console.WriteLine("\nErro encontrado!\nMESSAGE: " + e.Message + "\nTASK: " + e.StackTrace);

            }
        }

        // **************************************************************
        // Class Program - MenuPrincipal(): Show the autentication menu 
        // **************************************************************

        static void MenuPrincipal()
        {

            Settings _settings = new Settings();
            using (StreamReader file = File.OpenText("settings.json"))
            {
                _settings = JsonConvert.DeserializeObject<Settings>(file.ReadToEnd());

            }

            StringBuilder menu = new StringBuilder();

            menu.Append("\nAUTENTICAÇÃO\n");
            menu.Append("\n1 - Configurar Usuário / Senha");
            menu.Append("\n2 - Logar");
            menu.Append("\n3 - Limpar Base");
            menu.Append("\n4 - Sair\n");

            int opt = -1;

            while (opt != 4)
            {
                Console.WriteLine(menu);
                Console.Write("Digite a opção desejada: ");
                opt = Int32.Parse(Console.ReadLine());
                switch (opt)
                {
                    case 1:

                        Console.Write("Entre com o usuário: ");
                        string usuario = Console.ReadLine();
                        Console.Write("Entre com a senha: ");
                        string senha = Console.ReadLine();

                        string encsenha = Criptografia.Criptografar(SHA512.Create(), senha);
                        CadastrarSenha(_settings, usuario, encsenha);
                        break;

                    case 2:
                        Console.Write("Entre com o usuário: ");
                        string usuario1 = Console.ReadLine();
                        Console.Write("Entre com a senha: ");
                        string senha1 = Console.ReadLine();

                        Logar(_settings, usuario1, senha1);

                       
                        break;
                    case 3:

                        LimparBase(_settings);
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Opção Inválida. Tente novamente.");
                        break;
                }
            }

        }

        // **************************************************************
        // Class Program - CadastrarSenha():  Register the user name and
        //                 password in the file defined at Settings
        // **************************************************************


        static void CadastrarSenha(Settings s, string usuario, string senha)
        {
            bool res;

            ArquivosEPastas.CriarPasta(s);


            res = ArquivosEPastas.CriarEscreverArquivo(s, usuario, senha);

            if (res)
            {
                Console.WriteLine("Usuário e senha cadastrados com sucesso!");
            }
            else
            {
                Console.WriteLine("Usuário já está cadastrado.");
            }

        }

        // **************************************************************
        // Class Program - Logar(): Test the user login
        // **************************************************************


        static void Logar(Settings s, string usuario, string senha)
        {
            Dictionary<string,string> cadastro = ArquivosEPastas.LerArquivos(s, usuario, senha);

            bool achou = false;
            bool res;

            foreach (var item in cadastro)
            {
                if (usuario == item.Key)
                {
                    res = Criptografia.Validar(SHA512.Create(), senha, cadastro[usuario]);
                    if (res)
                        Console.WriteLine("Senha válida");
                    else
                        Console.WriteLine("Senha inválida");
                    achou = true;
                    break;
                }

            }

            if (!achou) Console.WriteLine("Usuário não está cadadastrado!");

        }

        // **************************************************************
        // Class Program - LimparBase(): Remove the folder and the file
        //                 where the registered usernames and passwords are
        //                 stored
        // **************************************************************


        static void LimparBase(Settings s)
        {

            bool res = ArquivosEPastas.DeletarPasta(s);
            if(res)
                Console.WriteLine("A base foi limpa com sucesso!");
            else
                Console.WriteLine("O diretório não existe!");
        }
    }

    // **************************************************************
    // Class Settings - Store the properties read from json configuration
    //                  file 
    // **************************************************************


    class Settings

    {
        public string Caminho { get; set; }
        public string Pasta { get; set; }
        public string Arquivo { get; set; }

    }

    // **************************************************************
    // Static Class ArquivosEPastas - Include Methods related to
    //                                folder and file manipulations
    // **************************************************************


    static class ArquivosEPastas
    {

        // **************************************************************
        // Static Class ArquivosEPastas - CriarPasta(): Generate a new folder
        //                                as defined in Settings
        // **************************************************************

        public static bool CriarPasta(Settings s)
        {
 
            if (!Directory.Exists(s.Caminho + s.Pasta))
            {
                Directory.CreateDirectory(s.Caminho + s.Pasta);
                return true;
            }
            else
                return false;

        }

        // **************************************************************
        // Static Class ArquivosEPastas - DeletarPasta(): Delete the folder
        //                                and the file as defined in Settings
        // **************************************************************

        public static bool DeletarPasta(Settings s)
        {
            string path = s.Caminho + s.Pasta;

            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
                return true;
            }
            else
                return false;
        }

        // **************************************************************
        // Static Class ArquivosEPastas - CriarEscreverArquivo(): Generate
        //                                the new file defined in Settings
        //                                and add or append the new item
        // **************************************************************


        public static bool CriarEscreverArquivo(Settings t, string u, string s)
        {
            string pathfile = t.Caminho + t.Pasta + t.Arquivo;

            if (!File.Exists(pathfile))
            {
                using (StreamWriter sw = File.CreateText(pathfile))
                {
                    sw.WriteLine($"{u}%SENHA%{s}");
                }
                return true;
            }
            else
            {
                Dictionary<string, string> cadastro = ArquivosEPastas.LerArquivos(t, u, s);
                foreach (var item in cadastro)
                {
                    if (u == item.Key)
                        return false;              
                }

                using (StreamWriter sw = File.AppendText(pathfile))
                {
                    sw.WriteLine($"{u}%SENHA%{s}");
                }
                return true;
            }
        }

        // **************************************************************
        // Static Class ArquivosEPastas - LerArquivos(): Read the text file
        //                                defined in Settings and store it
        //                                in a dictionary.
        // **************************************************************


        public static Dictionary<string,string> LerArquivos(Settings s, string usuario, string senha)
        {
            Dictionary<string, string> userpwd = new Dictionary<string, string>();
            string pathfile = s.Caminho + s.Pasta + s.Arquivo;

            if (File.Exists(pathfile))
            {
                using (StreamReader sr = File.OpenText(pathfile))
                {
                   
                    string line = "";

                    while ((line = sr.ReadLine()) != null)
                    {

                        string[] partes = line.Split("%SENHA%");
                        userpwd.Add(partes[0], partes[1]);

                    }
                    return userpwd;
                }
            }
            else
            {
                return userpwd;
            }

        }

    }

    // **************************************************************
    // Static Class Criptografia - Include Methods related to encoding
    //                             and Validation
    // **************************************************************


    static class Criptografia
    {
        // **************************************************************
        // Static Class Criptografia - Criptografar() : Encode the password
        // **************************************************************

        public static string Criptografar(HashAlgorithm _algoritmo, string senha)
        {
            var encodedValue = Encoding.UTF8.GetBytes(senha);
            var encryptedPassword = _algoritmo.ComputeHash(encodedValue);

            var sb = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                sb.Append(caracter.ToString("X2"));
            }

            return sb.ToString();

        }

        // **************************************************************
        // Static Class Criptografia - Validar() : Validate the password
        // **************************************************************


        public static bool Validar(HashAlgorithm _algoritmo, string senhaDigitada, string senhaCadastrada)
        {
            if (string.IsNullOrEmpty(senhaCadastrada))
                throw new NullReferenceException("Cadastre uma senha.");

            var encryptedPassword = _algoritmo.ComputeHash(Encoding.UTF8.GetBytes(senhaDigitada));

            var sb = new StringBuilder();
            foreach (var caractere in encryptedPassword)
            {
                sb.Append(caractere.ToString("X2"));
            }

            return sb.ToString() == senhaCadastrada;
        }
    }
}