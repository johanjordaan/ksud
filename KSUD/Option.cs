using System;
using System.Collections.Generic;

namespace KSUD
{
	public class Option 
	{
		public int Row { get; set; }
		public int Col { get; set; }
		public List<int> Options { get; set; }

		public override string ToString ()
		{
			return string.Format ("[Option: Row={0}, Col={1}, Options={2}]", Row, Col, Options);
		}
			
	}
}

