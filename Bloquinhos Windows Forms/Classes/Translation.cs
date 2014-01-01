using System.IO;

namespace BloquinhosWin.Classes
{
    static class Translation
    {
        private static string _actualLanguage;

        public static void Load()
        {
            if (!File.Exists(@"language.dat")){ File.WriteAllText(@"language.dat", @"en");}
            _actualLanguage = File.ReadAllText(@"language.dat");
        }

        public static string EnterName()
        {
            switch (_actualLanguage)
            {
                case "en":
                    return "Enter with your name:";
                case "pt":
                    return "Entre com seu nome:";
            }
            return null;
        }

        public static string Accept()
        {
            switch (_actualLanguage)
            {
                case "en":
                    return "Accept";
                case "pt":
                    return "Aceitar";
            }
            return null;
        }

        public static string HighScores()
        {
            switch (_actualLanguage)
            {
                case "en":
                    return "High scores";
                case "pt":
                    return "Recordes";
            }
            return null;
        }

        public static string Close()
        {
            switch (_actualLanguage)
            {
                case "en":
                    return "Close";
                case "pt":
                    return "Fechar";
            }
            return null;
        }

        public static string Level()
        {
            switch (_actualLanguage)
            {
                case "en":
                    return "Level";
                case "pt":
                    return "Nível";
            }
            return null;
        }

        public static string Score()
        {
            switch (_actualLanguage)
            {
                case "en":
                    return "Score";
                case "pt":
                    return "Pontos";
            }
            return null;
        }

        public static string ChoosedItem()
        {
            switch (_actualLanguage)
            {
                case "en":
                    return "Choosed Item";
                case "pt":
                    return "Item Escolhido";
            }
            return null;
        }

        public static string Speed()
        {
            switch (_actualLanguage)
            {
                case "en":
                    return "Speed";
                case "pt":
                    return "Velocidade";
            }
            return null;
        }

        public static string NewGame()
        {
            switch (_actualLanguage)
            {
                case "en":
                    return "New game";
                case "pt":
                    return "Novo jogo";
            }
            return null;
        }

        public static string Pause()
        {
            switch (_actualLanguage)
            {
                case "en":
                    return "Pause";
                case "pt":
                    return "Pausar";
            }
            return null;
        }

        public static string Time()
        {
            switch (_actualLanguage)
            {
                case "en":
                    return "Time";
                case "pt":
                    return "Tempo";
            }
            return null;
        }

        public static string NextLife()
        {
            switch (_actualLanguage)
            {
                case "en":
                    return "Next Life";
                case "pt":
                    return "Próxima Vida";
            }
            return null;
        }

        public static string Continue()
        {
            switch (_actualLanguage)
            {
                case "en":
                    return "Continue";
                case "pt":
                    return "Continuar";
            }
            return null;
        }

        public static string Restart()
        {
            switch (_actualLanguage)
            {
                case "en":
                    return "Please, restart the game";
                case "pt":
                    return "Por favor, reinicie o jogo";
            }
            return null;
        }

        public static string IntroRegister()
        {
            switch (_actualLanguage)
            {
                case "en":
                    return "Your game is not registered. To play fully, enter with the serial at the field bellow:";
                case "pt":
                    return "Seu jogo não está registrado. Para jogar completamente, entre com o serial no campo abaixo:";
            }
            return null;
        }

        public static string Validate()
        {
            switch (_actualLanguage)
            {
                case "en":
                    return "Validate";
                case "pt":
                    return "Validar";
            }
            return null;
        }

        public static string Registered()
        {
            switch (_actualLanguage)
            {
                case "en":
                    return "Thanks for registering! Enjoy the game, and visite www.pysi.com.br for more information or support.";
                case "pt":
                    return "Obrigado por registrar! Divirta-se, e visite www.pysi.com.br para mais informações ou suporte.";
            }
            return null;
        }

        public static string InvalidKey()
        {
            switch (_actualLanguage)
            {
                case "en":
                    return "Invalid code";
                case "pt":
                    return "Serial inválido";
            }
            return null;   
        }
    }
}
