using Paralelismo;
using Paralelismo.Models;
using System.Diagnostics;

string[] ceps = new string[5];
ceps[0] = "05439145";
ceps[1] = "89215194";
ceps[2] = "64216340";
ceps[3] = "59139160";
ceps[4] = "55644790";

var parallelOptions = new ParallelOptions();
parallelOptions.MaxDegreeOfParallelism = 2;

var stopWatch = new Stopwatch();

stopWatch.Start();

var listaCep = new List<string>();

Parallel.ForEach(ceps, parallelOptions, cep =>
{
    listaCep.Add(new ViaCepService().GetCep(cep) + $" Thread: {Thread.CurrentThread.ManagedThreadId}");
});

listaCep.ForEach(Console.WriteLine);

stopWatch.Stop();

Console.WriteLine($"O Tempo de processamento total é de {stopWatch.ElapsedMilliseconds} ms");