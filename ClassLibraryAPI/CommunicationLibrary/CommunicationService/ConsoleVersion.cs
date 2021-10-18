using System;

namespace ClassLibrary
{
    class ConsoleVersion
    {
        static void Main(string[] args)
        {
            var teamHub = new TeamMessageHub();


            var LindaRiszk = new Tester("LindaRiszk");
            var Henrik = new Administrator("Henrik");

            var Oskar = new Developer("Oskar");
            var Tesh = new Developer("Tesh");
            var Rickard = new Developer("Rickard");
            var Bini = new Developer("Bini");
            var Raffe = new Developer("Raffe");
            var ServerFredde = new Developer("ServerFredde");
            var MarkupFredde = new Developer("MarkupFredde");
            var Philip = new Developer("Philip");
            var Isac = new Developer("Isac");

            teamHub.RegisterMultiple(LindaRiszk, Henrik, Oskar, Tesh, Rickard, Bini, Raffe,
                                    ServerFredde, MarkupFredde, Philip);

            Henrik.Send("Hej, standupen är klockan 9 imorgon btw. Ps: AW på fredag.");
            ServerFredde.Send("D u n d e r");
            Isac.Send("Yess!");
        }
    }
}
