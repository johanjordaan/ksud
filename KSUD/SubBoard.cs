using System;
using System.Collections.Generic;

namespace KSUD
{
	public class SubBoard
	{
		private int[] data = new int[9];
		private int[] histogram = new int[10];
		private bool valid = true;
		private bool complete = true;
		public SubBoard() {
			setBoard ("000000000");
		}

		public SubBoard (String subBoardStr)
		{
			setBoard (subBoardStr);
		}

		public SubBoard(SubBoard source) {
			for (int i = 0; i < 9; i++) {
				data[i] = source.data[i];
			}
			for (int i = 0; i < 10; i++) {
				histogram[i] = source.histogram[i];
			}
				
			valid = source.valid;
			complete = source.complete;
		}

		private void setBoard(String subBoardStr) {
			for (int i = 0; i < 9; i++) {
				data[i] = int.Parse (subBoardStr.Substring (i, 1));
			}
			check ();
		}

		private void check() {
			complete = true;
			valid = true;

			for (int i = 0; i < 10; i++) {
				try {
				histogram [i] = 0;
				}catch(Exception e) {
				}
			}


			for (int i=0;i<9;i++) {
				var val = data [i];
				histogram [val] += 1;

				if (val == 0) {
					complete = false;
				}
				if (val < 0 || val > 9) {
					valid = false;
				}

				if (histogram [val] > 1 && val >0) {
					valid = false;
				}
			}
		}

		public int GetCell(int row,int col) {
			return GetCell (row * 3 + col);
		}

		public int GetCell(int index) {
			return data [index];
		}
		public void SetCell (int row,int col,int val) {
			SetCell (row * 3 + col, val);
		}

		public void SetCell(int index,int val) {
			data[index] = val;
			check ();
		}

		public List<int> GetOptions(int row,int col) {
			return GetOptions (row * 3 + col);
		}
		public List<int> GetOptions(int index) {
			var options = new List<int> ();

			if (index >= 9)
				return options;

			if (data [index] != 0)
				return options;

			for (int i = 1; i < 10; i++) {
				if (histogram [i] == 0) {
					options.Add (i);
				}
			}

			return options;
		}

		public int EmptyCells() {
			return histogram [0];
		}

		public bool IsComplete() {
			return complete;
		}
			
		public bool IsValid()
		{
			return valid;
		}

		public override bool Equals (object obj)
		{
			SubBoard source = obj as SubBoard;

			for (int i = 0; i < 9; i++) {
				if (source.data [i] != data [i])
					return false;
			}

			return true;
		}

	}
}

