using System;
using System.Linq;

namespace JiebaPrac
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Jiqba!");

            var sourceString = "許當麻緩緩的唱著:那樣的回憶那麼足夠足夠我天天都品嚐著寂寞";

            JiebaNet.Segmenter.ConfigManager.ConfigFileBaseDir = AppDomain.CurrentDomain.BaseDirectory + @"jiebanet_config";


            var segmenter = new JiebaNet.Segmenter.JiebaSegmenter();


            Console.WriteLine("Cut -\r\n");

            var segmentsCut = segmenter.Cut(sourceString);
            Console.WriteLine(string.Join("/", segmentsCut));


            Console.WriteLine("\r\n--------------------------------\r\n");

            var posSeg = new JiebaNet.Segmenter.PosSeg.PosSegmenter(segmenter);


            var tokens = posSeg.Cut(sourceString);
            foreach (var token in tokens) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(token.Word);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("/");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(token.Flag);
            }

            Console.ReadLine();
        }
    }
}
