using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSUD
{
	public class Board
	{
		private SubBoard[] quadrants = new SubBoard[9];
		private SubBoard[] rows = new SubBoard[9];
		private SubBoard[] cols = new SubBoard[9];
		private bool valid = true;
		private bool complete = true;

		public Board (String boardStr)
		{
			for (int i = 0; i < 9; i++) {
				quadrants [i] = new SubBoard ();
				rows [i] = new SubBoard ();
				cols [i] = new SubBoard ();
			}

			boardStr = boardStr.Replace ("|", "").Replace(",","");
			for (int row = 0, i = 0; row < 9; row++) {
				for (int col = 0; col < 9; col++,i++) {
					var val = int.Parse (boardStr [i].ToString ());
					rows [row].SetCell (col, val);
					cols [col].SetCell (row, val);
					quadrants [(row / 3) * 3 + (col / 3)].SetCell (row % 3, col % 3, val);
				}
			}

			check ();
		}

		public Board(Board source) {
			for (int i = 0; i < 9; i++) {
				quadrants [i] = new SubBoard (source.quadrants[i]);
				rows [i] = new SubBoard (source.rows[i]);
				cols [i] = new SubBoard (source.cols[i]);
			}
			valid = source.valid;
			complete = source.complete;
		}

		private void check() {
			valid = true;
			complete = true;
		
			for(int i=0;i<9;i++) {
				if (!rows [i].IsValid() || !cols [i].IsValid() || !quadrants [i].IsValid()) {
					valid = false;
				}
				if (!rows [i].IsComplete() || !cols [i].IsComplete() || !quadrants [i].IsComplete()) {
					complete = false;
				}
			}
		}


		public void SetCell(int row,int col,int val) {
			rows [row].SetCell (col,val);
			cols [col].SetCell (row, val);
			quadrants [(row / 3) * 3 + (col / 3)].SetCell (row % 3, col % 3, val);
			check ();
		}
			
		public int EmptyCells() {
			int count = 0;

			foreach (var subBoard in rows) {
				count += subBoard.EmptyCells ();
			}

			return count;
		}

		public List<Option> GetOptions() {
			var options = new List<Option> ();

			for (int row = 0; row < 9; row++) {
				for (int col = 0; col < 9; col++) {
					var r = rows [row].GetOptions (col);
					var c = cols [col].GetOptions (row);
					var q = quadrants [(row / 3) * 3 + (col / 3)].GetOptions (((row % 3) * 3) + (col % 3));

					var validOptions = new List<int> ();
					for (int v = 1; v < 10; v++) {
						if (r.Contains (v) && c.Contains (v) && q.Contains (v)) {
							validOptions.Add (v);	
						}
					}
					if (validOptions.Count > 0) {
						options.Add (new Option (){ Row = row, Col = col, Options = validOptions });
					}
				}
			}

			return options;
		}
			
		public void Simplify() {
			bool quit = false;
			while (!quit) {
				var options = GetOptions ().Where ((z) => z.Options.Count == 1).ToList ();
	
				foreach (var option in options) {
					SetCell (option.Row, option.Col, option.Options [0]);
				}

				if (options.Count == 0) {
					quit = true;
				}
			}
		}

		public bool IsComplete() {
			return complete;
		}

		public bool IsValid()
		{
			return valid;
		}

		public override string ToString ()
		{	
			var x = new StringBuilder ();
			foreach (var row in rows) {
				for (int col = 0; col < 9; col++) {
					x.Append (row.GetCell(col));
					if (col == 8) {
						x.Append ("|");
					} else {
						x.Append (",");
					}
				}
			}
			x.Remove (x.Length - 1, 1);
			return x.ToString ();
		}

		public override bool Equals (object obj)
		{
			Board source = obj as Board;

			for (int i = 0; i < 9; i++) {
				if (!quadrants [i].Equals (source.quadrants [i]))
					return false;
			}
			
			return true;
		}

	}
}

