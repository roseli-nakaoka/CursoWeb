using System;
using System.Text;


namespace Modulo2_Lista1
{
    class MainClass
    {
        public static void Main(string[] args)
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

        public static void MenuPrincipal()
        {
            bool res;
            string[] usuario = new string[2];
            int opt = -1;
            int lastlog = -1;

            StringBuilder menu = new StringBuilder();
            menu.Append("\n1 - Usar conta do Gmail");
            menu.Append("\n2 - Usar conta do Facebook");
            menu.Append("\n3 - Usar conta do Instagram");
            menu.Append("\n4 - Sair");
  
            LoginGmail loggmail = new LoginGmail();
            LoginFacebook logface = new LoginFacebook();
            LoginInstagram loginsta = new LoginInstagram();

            while (opt != 4)
            {
                Console.WriteLine(menu);
                Console.Write("\nDigite a opção desejada: ");
                opt = Int32.Parse(Console.ReadLine());

                switch (opt)
                {
                    case 1:
                        lastlog = opt;
                        usuario = GetUser();
                        res = loggmail.Login(usuario[0], usuario[1], TipoEmail.Gmail);
                        PrintLogin(res, TipoEmail.Gmail);
                        break;

                    case 2:
                        lastlog = opt;
                        usuario = GetUser();
                        res = logface.Login(usuario[0], usuario[1], TipoEmail.Facebook);
                        PrintLogin2(res, TipoEmail.Facebook);
                        break;

                    case 3:
                        lastlog = opt;
                        usuario = GetUser();
                        res = loginsta.Login(usuario[0], usuario[1], TipoEmail.Instagram);
                        PrintLogin(res, TipoEmail.Instagram);
                        break;

                    case 4:
                        switch (lastlog)
                        {
                            case 1:
                                PrintLogout(loggmail.Logout(), TipoEmail.Gmail);
                                break;

                            case 2:
                                PrintLogout(logface.Logout(), TipoEmail.Facebook);
                                break;

                            case 3:
                                PrintLogout(loginsta.Logout(), TipoEmail.Instagram);
                                break;

                            default:
                                break;

                        }
                        break;

                    default:
                        Console.WriteLine("Opção Inválida. Tente novamente");
                        break;
                }
            } 
        }

        private static string[] GetUser()
        {
            string[] user = new string[2];

            Console.Write("\nusuário: ");
            user[0] = Console.ReadLine();
            Console.Write("senha: ");
            user[1] = Console.ReadLine();
            return user;
        }

        private static void PrintLogin(bool res, TipoEmail tipo)
        {
            if (res)
                Console.WriteLine($"Login no {tipo} foi Efetuado");
            else
                Console.WriteLine($"Login no {tipo} Falhou");

        }

        private static void PrintLogin2(bool res, TipoEmail tipo)
        {
            if (res)
                Console.WriteLine($"Autenticação especial - Login no {tipo} foi Efetuado");
            else
                Console.WriteLine($"Autenticação especial - Login no {tipo} Falhou");

        }

        private static void PrintLogout(bool res, TipoEmail tipo)
        {
            if (res)
                Console.WriteLine($"Logout do {tipo} foi Efetuado");
            else
                Console.WriteLine($"Logout do {tipo} Falhou");
          
        }

    }

    public enum TipoEmail
    {
        Gmail = 1,
        Facebook = 2,
        Instagram = 3

    }

    public abstract class SuperLogin
    {
        public abstract bool Login(string usuario, dynamic senha, TipoEmail tipo);

        public abstract bool Logout();

        protected virtual bool Autentica(string usuario, dynamic senha, TipoEmail tipo)
        {
            if (senha is string) senha = Int32.Parse(senha);

            switch (tipo)
            {
                case TipoEmail.Gmail:
                    if (usuario == "Gmail" && senha == 112358)
                        return true;
                    else
                        return false;

                case TipoEmail.Facebook:
                    if (usuario == "Facebook" && senha == 123456)
                        return true;
                    else
                        return false;

                case TipoEmail.Instagram:
                    if (usuario == "Instagram" && senha == 909090)
                        return true;
                    else
                        return false;

                default:
                    Console.WriteLine("Tipo de Email inválido");
                    return false;
            }

        }

    }

    public class LoginGmail : SuperLogin
    {
        public override bool Login(string usuario, dynamic senha, TipoEmail tipo)
        {
            bool result = Autentica(usuario, senha, tipo);

            if (result)
                return true;
            else
                return false;
        }

        public override bool Logout()
        {

            bool result = true;

            if (result)
                return true;
            else
                return false;

        }
    }

    public class LoginFacebook : SuperLogin
    {
        public override bool Login(string usuario, dynamic senha, TipoEmail tipo)
        {
            //bool result = Autentica(usuario, senha, tipo);
            bool result = Autentica(usuario, senha);

            if (result)
                return true;
            else
                return false;

        }

        public override bool Logout()
        {

            bool result = true;

            if (result)
                return true;
            else
                return false;

        }

        protected bool Autentica(string usuario, dynamic senha)
        {
            if (senha is string) senha = Int32.Parse(senha);
            if (usuario == "Facebook2" && senha == 3333)
                return true;
            else
                return false;
        }
    }

    public class LoginInstagram : SuperLogin
    {
        public override bool Login(string usuario, dynamic senha, TipoEmail tipo)
        {
            bool result = Autentica(usuario, senha, tipo);

            if (result)
                return true;
            else
                return false;
        }

        public override bool Logout()
        {

            bool result = true;

            if (result)
                return true;
            else
                return false;

        }
    }


}
