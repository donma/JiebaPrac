using System;
using System.Linq;

namespace JiebaPrac
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Jiqba!");

            JiebaNet.Segmenter.ConfigManager.ConfigFileBaseDir = AppDomain.CurrentDomain.BaseDirectory + @"jiebanet_config";


            var segmenter = new JiebaNet.Segmenter.JiebaSegmenter();

            var segments = segmenter.CutForSearch("許當麻緩緩的唱著:那樣的回憶那麼足夠足夠我天天都品嚐著寂寞");
            Console.WriteLine(string.Join(" /  ", segments));

            Console.WriteLine("--------------------------------");

            var posSeg = new JiebaNet.Segmenter.PosSeg.PosSegmenter(segmenter);


            var s = "許當麻緩緩的唱著:那樣的回憶那麼足夠足夠我天天都品嚐著寂寞";

            var tokens = posSeg.Cut(s);

            Console.WriteLine(string.Join(" ", tokens.Select(token => token.Word+"/"+token.Flag)));
        }
    }
}
