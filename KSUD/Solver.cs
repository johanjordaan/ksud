using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace KSUD
{
	public class Solver
	{
		private Board root;
		private List<Board> boards;
		public Solver (String puzzle)
		{
			boards = new List<Board> ();
			root = new Board (puzzle);
			root.Simplify ();
			boards.Add (root);

			BoardsEvaluated = 0;
		}

		public int BoardsEvaluated { get; set; }
		public long TimeTaken { get; set; }
		public Board Solve() 
		{
			var watch = Stopwatch.StartNew();
			BoardsEvaluated = 0;
			while (boards.Count > 0) {
				BoardsEvaluated += 1;
				// Order List
				//
				boards.OrderBy (board => board.EmptyCells()); 

				// Pick top and if it is a solution then return it
				//
				var currentBoard = boards [0];
				if (currentBoard.IsComplete () && currentBoard.IsValid ()) {
					watch.Stop();
					TimeTaken = watch.ElapsedMilliseconds;
					return currentBoard;

				}

				// If is not complete then expand it
				//
				var boardOptions = currentBoard.GetOptions ().OrderBy (x => x.Options.Count);
				if (boardOptions.Count() > 0) {
					foreach (var cellOption in boardOptions) {
						foreach (var val in cellOption.Options) {
							var newBoard = new Board (currentBoard);
							newBoard.SetCell (cellOption.Row, cellOption.Col, val);
							newBoard.Simplify ();
							boards.Add (newBoard);
						}
					}
				} else {

				}

				boards.Remove (currentBoard);
			}
			watch.Stop();
			TimeTaken = watch.ElapsedMilliseconds;
			return root;
		}
	}
}

