using System;
using System.Linq;
namespace Program01
{
    class Program
    {
        class Pessoa
        {
            public string Nome { get; set; }
            public string Cidade { get; set; }
        }
        static void Main(string[] args)
        {
            Pessoa[] pessoas = new Pessoa[] {
                new Pessoa { Nome = "Alice", Cidade = "Uberaba" },
                new Pessoa { Nome = "Breno", Cidade = "Aracaju" },
                new Pessoa { Nome = "Carlos", Cidade ="Londrina" },
                new Pessoa { Nome = "Daniel", Cidade = "Aracaju" },
                new Pessoa { Nome = "Eduardo", Cidade = "Aparecida" },
                new Pessoa { Nome = "Fabio", Cidade = "Uberlândia" },
                new Pessoa { Nome = "Guilherme", Cidade = "Uberaba" },
                new Pessoa { Nome = "Henrique", Cidade = "Aracaju" },
                new Pessoa { Nome = "Isaias", Cidade = "Aracaju" },
                new Pessoa { Nome = "Tiago", Cidade = "Londrina" }
            };

            //var result = from pessoa in pessoas.AsParallel()
            //             where pessoa.Cidade == "Aracaju"
            //             select pessoa;

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

            var result = from pessoa in
                            pessoas.AsParallel()
                         where pessoa.Cidade == "Aracaju"
                         select pessoa;
            result.ForAll(pessoa => Console.WriteLine(pessoa.Nome));


            foreach (var pessoa in result)
                Console.WriteLine(pessoa.Nome);
            Console.WriteLine("Término do processamento. Tecle algo para terminar.");

            try
            {
                var result2 = from pessoa in
                                 pessoas.AsParallel()
                              where VerificaCidade(pessoa.Cidade)
                              select pessoa;

                result2.ForAll(pessoa => Console.WriteLine(pessoa.Nome));
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.InnerExceptions.Count + " exceções.");
            }

            Console.ReadLine();
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

