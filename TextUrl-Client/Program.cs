using System;
using RestSharp;
namespace TextUrlConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var parrurl = args[0];
            var usr = parrurl;
            var url = usr;
            if (args[1] == "new")
            {
                var permut = "/new/query?title=" + args[2] + "&message=" + args[3];
                url = usr + permut;
                Console.WriteLine("ID: ");
            }
            else if (args[1] == "get")
            {
                var permut = "/userdef/seperate/" + args[2];
                url = usr + permut;
                Console.WriteLine("Titel: ");
            }
            else if (args[1] == "rm")
            {
                var permut = "/delete/" + args[2];
                url = usr + permut;
                Console.WriteLine("REMOVED ID: " + args[2]);
            }
            else
            {
                Console.WriteLine("OOOPS! Failue to read parameter");
            }
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            string result = System.Text.Encoding.UTF8.GetString(client.DownloadData(request));
            if (args[1] == "new")
            {
                Console.WriteLine(result);
            }else if(args[1] == "get")
            {
                var tokens = result.Split("--|||||||||--");
                Console.WriteLine(tokens[0]);
                Console.WriteLine("");
                Console.WriteLine("Message:");
                Console.WriteLine(tokens[1]);
            }
        }
    }
}
