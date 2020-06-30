using IronPython.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace c_sharpProject1
{
	class Program
	{
		static void Main(string[] args)
		{

			Console.WriteLine("Execute python IronPython...");
			Option2_IronPython();

			Console.ReadKey();
		}

		static void Option2_IronPython()
		{
			// 1) Create engine
			var engine = Python.CreateEngine();

			// 2) Provide script and arguments
			var script = @"C:\Users\Anannya\source\repos\c-sharpProject1\c-sharpProject1\bin\Debug\netcoreapp3.1\ab.py";
			var source = engine.CreateScriptSourceFromFile(script);

			var argv = new List<string>();
			argv.Add("");

			engine.GetSysModule().SetVariable("argv", argv);

			// 3) Output redirect
			var eIO = engine.Runtime.IO;

			using (var errors = new MemoryStream())
			{
				eIO.SetErrorOutput(errors, Encoding.Default);

				var results = new MemoryStream();
				eIO.SetOutput(results, Encoding.Default);

				// 4) Execute script
				var scope = engine.CreateScope();
				source.Execute(scope);

				// 5) Display output
				string str(byte[] x) => Encoding.Default.GetString(x);

				Console.WriteLine("ERRORS:");
				Console.WriteLine(str(errors.ToArray()));
				Console.WriteLine();
				Console.WriteLine("Results:");
				Console.WriteLine(str(results.ToArray()));
			}

		}
	}
}
