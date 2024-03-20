using System.Reflection.Metadata.Ecma335;
using TaskLINQ.Classes;

namespace TaskLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Prodotto> lis = new List<Prodotto>(){
               new Prodotto("Coltello","Affilato",2.40,"Cucina",1),
               new Prodotto("TV","Grande",500,"Elettrodomestici",3), 
               new Prodotto("PC","Buono",300,"Computer",4), 
               new Prodotto("Penna","Non scrive",0.90,"Cartolibreria",7), 
               new Prodotto("Borraccia","Piccola",3.00,"Cucina",1) 
            };

            var sceltaCategoria = lis.Where(prod => prod.Categoria == "Cucina").Select(p=>new { p.Nome, p.Prezzo });
            foreach (var item in sceltaCategoria )
            {
                Console.WriteLine($"{item.Nome} {item.Prezzo}");
            }
            var prezzoMedio = lis.Average(p => p.Prezzo);
            Console.WriteLine(prezzoMedio);

            var quantitaPerCategoria = from prodotto in lis
                                       group prodotto by prodotto.Categoria into contenitoreGenere
                                       select contenitoreGenere;
            
            
               foreach (var categoria in quantitaPerCategoria)
                {
                Console.WriteLine(categoria.Key + " " + categoria.Sum(p=>p.Quantita));
                }
            var total = from prod in lis
                            where prod.Quantita > 0
                            select new { prod.Prezzo, prod.Quantita };
            Console.WriteLine(total.Sum(p=> p.Prezzo*p.Quantita));


        }
    }
}
