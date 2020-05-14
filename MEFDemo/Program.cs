using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using BankInterface;
namespace MEFDemo
{
    class Program
    {
        [ImportMany(AllowRecomposition = true)]
        public IEnumerable<Lazy<ICard, IMetaData>> cards { get; set; }

        static void Main(string[] args)
        {
            
            Program pro = new Program();
            pro.Compose();
            foreach (var c in pro.cards)
            {
                if (c.Metadata.CardType == "BankOfChina")
                {
                    Console.WriteLine("Here is a card of Bank Of China ");
                    Console.WriteLine(c.Value.GetCountInfo());
                }
                if (c.Metadata.CardType == "NongHang")
                {
                    Console.WriteLine("Here is a card of Nong Ye Yin Hang ");
                    Console.WriteLine(c.Value.GetCountInfo());
                }
            }
            Console.Read();
        }

        private void Compose()
        {
            var catalog = new DirectoryCatalog("Cards");
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            
        }
    }
}
