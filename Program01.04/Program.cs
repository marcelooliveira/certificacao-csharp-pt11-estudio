using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
namespace Program01
{
    class Program
    {
        public class Filme
        {
            public string Titulo { get; set; }
            public decimal Faturamento { get; set; }
            public decimal Orcamento { get; set; }
            public string Distribuidor { get; set; }
            public string Genero { get; set; }
            public string Diretor { get; set; }
        }

        class ItemResumo : IComparable
        {
            public string Item { get; set; }
            public decimal Faturamento { get; set; }
            public decimal Orcamento { get; set; }

            public int CompareTo(object obj)
            {
                ItemResumo outro = obj as ItemResumo;
                return Item.CompareTo(outro.Item);
            }
        }

        static void Main(string[] args)
        {

            List<Filme> filmes = JsonConvert.DeserializeObject<List<Filme>>(File.ReadAllText("filmes.json"));

            //Tarefa 1: obter a lista de filmes de Aventura 
            var resultado1 =
            from filme in filmes
            where filme.Genero == "Adventure"
            select new ItemResumo
            {
                Item = filme.Titulo,
                Faturamento = filme.Faturamento,
                Orcamento = filme.Orcamento
            };
            GeraRelatorio("Tarefa 1: obter a lista de filmes de Aventura ", resultado1);

            //Tarefa 2: obter a lista de filmes de Aventura,
            //executando em PARALELO
            var resultado2 =
            from filme in filmes.AsParallel()
            where filme.Genero == "Adventure"
            select new ItemResumo
            {
                Item = filme.Titulo,
                Faturamento = filme.Faturamento,
                Orcamento = filme.Orcamento
            };

            GeraRelatorio("Tarefa 2: obter a lista de filmes de Aventura, executando em PARALELO", 
                resultado2);

            //Tarefa 3: obter a lista de filmes de Aventura,
            //executando em PARALELO com modo de execução default

            var resultado3 =
             from filme in filmes
                .AsParallel()
                .WithExecutionMode(ParallelExecutionMode.Default)
             where filme.Genero == "Adventure"
             select new ItemResumo
             {
                 Item = filme.Titulo,
                 Faturamento = filme.Faturamento,
                 Orcamento = filme.Orcamento
             };

            GeraRelatorio("Tarefa 3: obter a lista de filmes de Aventura, executando em PARALELO com modo de execução default",
                resultado3);

            //Tarefa 4: obter a lista de filmes de Aventura,
            //executando em PARALELO forçando paralelismo

            var resultado4 =
             from filme in filmes
                .AsParallel()
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
             where filme.Genero == "Adventure"
             select new ItemResumo
             {
                 Item = filme.Titulo,
                 Faturamento = filme.Faturamento,
                 Orcamento = filme.Orcamento
             };

            GeraRelatorio("obter a lista de filmes de Aventura, executando em PARALELO forçando paralelismo", 
                resultado4);

            //Tarefa 5: obter a lista de filmes de Aventura,
            //executando em PARALELO forçando paralelismo
            //e com grau de paralelismo = 4

            var resultado5 =
             from filme in filmes
                .AsParallel()
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                .WithDegreeOfParallelism(4)
             where filme.Genero == "Adventure"
             select new ItemResumo
             {
                 Item = filme.Titulo,
                 Faturamento = filme.Faturamento,
                 Orcamento = filme.Orcamento
             };

            GeraRelatorio("obter a lista de filmes de Aventura, executando em PARALELO forçando paralelismo e com grau de paralelismo = 4", resultado5);
            
            //Tarefa 6: obter a lista de filmes de Aventura,
            //executando em PARALELO e preservando a ordem

            var resultado6 = 
                from filme in filmes
                    .AsParallel()
                    .AsOrdered()
                where filme.Genero == "Adventure"
                select new ItemResumo
                {
                    Item = filme.Titulo,
                    Faturamento = filme.Faturamento,
                    Orcamento = filme.Orcamento
                };

            GeraRelatorio("Tarefa 6: obter a lista de filmes de Aventura, executando em PARALELO e preservando a ordem", 
                resultado6);


            //Tarefa 7: obter os 4 filmes de Aventura de maior faturamento,
            //executando em PARALELO

            var resultado7 =
                (from filme in filmes
                    .AsParallel()
                orderby filme.Faturamento descending
                where filme.Genero == "Adventure"
                select new ItemResumo
                {
                    Item = filme.Titulo,
                    Faturamento = filme.Faturamento,
                    Orcamento = filme.Orcamento
                }).AsSequential().Take(4);

            GeraRelatorio("Tarefa 7: obter os 4 filmes de Aventura de maior faturamento, executando em PARALELO", resultado7);


            //Tarefa 8: Imprimir somente os títulos dos filmes,
            //de aventura, consultando em PARALELO e usando uma
            //ação em PARALELO

            var resultado8 =
                         from filme in
                            filmes
                            .AsParallel()
                         where filme.Genero == "Adventure"
                         select filme;

            resultado8.ForAll(filme => Console.WriteLine(filme.Titulo));

            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        private static void GeraRelatorio(string tituloRelatorio, IEnumerable<ItemResumo> result)
        {
            Console.WriteLine("Relatório: {0}", tituloRelatorio);

            Console.WriteLine("{0,-30} {1,20:N2} {2,20:N2} {3,20:N2} {4,10:P}",
                    "Item",
                    "Faturamento",
                    "Orcamento",
                    "Lucro",
                    "LucroPorcentagem");
            Console.WriteLine("{0,-30} {1,20:N2} {2,20:N2} {3,20:N2} {4,10:P}",
                    new string('=', 30),
                    new string('=', 20),
                    new string('=', 20),
                    new string('=', 20),
                    new string('=', 10));
            foreach (var item in result)
            {
                var lucro = item.Faturamento - item.Orcamento;
                var lucroPorcentagem = (item.Faturamento - item.Orcamento) / item.Orcamento;

                Console.WriteLine("{0,-30} {1,20:N2} {2,20:N2} {3,20:N2} {4,10:P}",
                    item.Item,
                    item.Faturamento,
                    item.Orcamento,
                    lucro,
                    lucroPorcentagem);
            }
            Console.WriteLine();
            Console.WriteLine("FIM DO RELATÓRIO: {0}", tituloRelatorio);

            Console.WriteLine("[Tecle algo para continuar]");
            Console.ReadLine();
        }
    }
}

