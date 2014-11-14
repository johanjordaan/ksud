using NUnit.Framework;
using System;
using KSUD;

namespace SolverTests
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void SolveEasy ()
		{
			var easy = "4,0,0,9,0,7,0,0,0|0,2,3,5,0,6,9,0,7|0,0,0,8,2,4,1,0,0|1,7,0,0,4,0,3,6,0|0,0,0,0,0,0,0,0,0|0,3,4,0,6,0,0,7,2|0,0,6,7,5,3,0,0,0|7,0,1,6,0,2,5,9,0|0,0,0,4,0,1,0,0,6";
			var s = new Solver(easy);

			var b = s.Solve ();
			Assert.IsTrue (b.IsComplete ());
		}

		[Test ()]
		public void SolveNormal ()
		{
			var normal = "0,0,6,0,9,0,0,0,7|8,4,0,7,3,2,1,6,0|0,0,0,1,0,0,0,4,2|4,9,0,0,0,0,7,3,0|0,0,3,0,0,0,2,0,0|0,1,7,0,0,0,0,9,6|9,3,0,0,0,4,0,0,0|0,6,1,3,2,9,0,7,8|7,0,0,0,5,0,9,0,0";
			var s = new Solver(normal);

			var b = s.Solve ();
			Assert.IsTrue (b.IsComplete ());
			var x = b.ToString ();
			var be = s.BoardsEvaluated;
		}

		[Test ()]
		public void SolveHard ()
		{
			var hard = "0,0,0,2,0,0,0,6,3|3,0,0,0,0,5,4,0,1|0,0,1,0,0,3,9,8,0|0,0,0,0,0,0,0,9,0|0,0,0,5,3,8,0,0,0|0,3,0,0,0,0,0,0,0|0,2,6,3,0,0,5,0,0|5,0,3,7,0,0,0,0,8|4,7,0,0,0,1,0,0,0";
			var s = new Solver(hard);

			var b = s.Solve ();
			Assert.IsTrue (b.IsComplete ());
			var x = b.ToString ();
			var be = s.BoardsEvaluated;
		}
	}
}
