using LayerMap;
using System;
using System.Threading;

namespace ConfigBuilder {
    class Program {
        static void Main(string[] args) {
            string[] art = {
                "             h         h               d  t ",
                "             h         h               d  t ",
                " aa  ss  ccc hhh  u  u hhh   aa rrr  ddd ttt",
                "a a  s  c    h  h u  u h  h a a r   d  d  t ",
                "aaa ss   ccc h  h  uuu h  h aaa r    ddd  tt"
            };

            string path = Configuration.DEFAULT_SERIALIZATION_FILENAME;
            Console.WriteLine($"Saved config file to {path}.");
            new Configuration().Save(Configuration.DEFAULT_SERIALIZATION_FILENAME);
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (string s in art) {
                Console.WriteLine(s);
                Thread.Sleep(250);
            }
            Thread.Sleep(1000);
        }
    }
}
