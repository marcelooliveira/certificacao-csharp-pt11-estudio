using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
namespace Program01
{
    class Program
    {
        class Pessoa : IComparable
        {
            public string Nome { get; set; }
            public string Cidade { get; set; }

            public int CompareTo(object obj)
            {
                var outro = obj as Pessoa;
                return this.Nome.CompareTo(outro.Nome);
            }
        }

        static void Main(string[] args)
        {
            Pessoa[] pessoas = new Pessoa[] {
                new Pessoa { Nome = "Daniel", Cidade = "Aracaju" },
                new Pessoa { Nome = "Carlos", Cidade ="Londrina" },
                new Pessoa { Nome = "Tiago", Cidade = "Londrina" },
                new Pessoa { Nome = "Fabio", Cidade = "Uberlândia" },
                new Pessoa { Nome = "Breno", Cidade = "Aracaju" },
                new Pessoa { Nome = "Alice", Cidade = "Uberaba" },
                new Pessoa { Nome = "Guilherme", Cidade = "Uberaba" },
                new Pessoa { Nome = "Isaias", Cidade = "Aracaju" },
                new Pessoa { Nome = "Henrique", Cidade = "Aracaju" },
                new Pessoa { Nome = "Eduardo", Cidade = "Aparecida" }
            };
                       
            //Tarefa 1: obter a lista de pessoas de Aracaju 

            var resultado1 = 
                         from pessoa in pessoas
                         where pessoa.Cidade == "Aracaju"
                         select pessoa;

            Imprimir(resultado1);

            //Tarefa 2: obter a lista de pessoas de Aracaju,
            //executando em PARALELO

            var resultado2 = 
                         from pessoa in pessoas.AsParallel()
                         where pessoa.Cidade == "Aracaju"
                         select pessoa;

            Imprimir(resultado2);

            var resultado3 =
             from pessoa in pessoas
                .AsParallel()
                .WithExecutionMode(ParallelExecutionMode.Default)
             where pessoa.Cidade == "Aracaju"
             select pessoa;

            Imprimir(resultado3);


            var resultado4 =
             from pessoa in pessoas
                .AsParallel()
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
             where pessoa.Cidade == "Aracaju"
             select pessoa;

            Imprimir(resultado4);

            //var result = from pessoa in
            //    pessoas
            //    .AsParallel()
            //    .WithDegreeOfParallelism(4)
            //    .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
            //             where pessoa.Cidade == "Aracaju"
            //             select pessoa;

            //var result = from pessoa in
            //                 pessoas.AsParallel().AsOrdered()
            //             where pessoa.Cidade == "Aracaju"
            //             select pessoa;

            //var result = (from pessoa in
            //     pessoas.AsParallel()
            //              where pessoa.Cidade == "Aracaju"
            //              orderby (pessoa.Nome)
            //              select new
            //              {
            //                  pessoa.Nome
            //              }).AsSequential().Take(4);

            //var result = from pessoa in
            //                pessoas.AsParallel()
            //             where pessoa.Cidade == "Aracaju"
            //             select pessoa;
            //result.ForAll(pessoa => Console.WriteLine(pessoa.Nome));



            //try
            //{
            //    var result = from pessoa in
            //                     pessoas.AsParallel()
            //                  where VerificaCidade(pessoa.Cidade)
            //                  select pessoa;

            //    result.ForAll(pessoa => Console.WriteLine(pessoa.Nome));
            //}
            //catch (AggregateException e)
            //{
            //    Console.WriteLine(e.InnerExceptions.Count + " exceções.");
            //}


            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        private static void Imprimir(IEnumerable<Pessoa> result)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var pessoa in result)
                Console.WriteLine(pessoa.Nome);
            stopwatch.Stop();
            Console.WriteLine("Tempo decorrido: {0} segundos", stopwatch.ElapsedMilliseconds / 1000.0);
        }

        public static bool VerificaCidade(string nome)
        {
            if (nome== "")
            {
                throw new ArgumentException(nome);
            }

            return nome == "Aracaju";
        }
    }
}

