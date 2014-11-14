using NUnit.Framework;
using System;
using System.Linq;
using KSUD;

namespace BoardTests
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void IsComplete ()
		{
			var b = new Board ("4,0,0,9,0,7,0,0,0|0,2,3,5,0,6,9,0,7|0,0,0,8,2,4,1,0,0|1,7,0,0,4,0,3,6,0|0,0,0,0,0,0,0,0,0|0,3,4,0,6,0,0,7,2|0,0,6,7,5,3,0,0,0|7,0,1,6,0,2,5,9,0|0,0,0,4,0,1,0,0,6");
			Assert.IsFalse (b.IsComplete ());
		}


		[Test ()]
		public void IsValid ()
		{
			var b = new Board ("4,0,0,9,0,7,0,0,0|0,2,3,5,0,6,9,0,7|0,0,0,8,2,4,1,0,0|1,7,0,0,4,0,3,6,0|0,0,0,0,0,0,0,0,0|0,3,4,0,6,0,0,7,2|0,0,6,7,5,3,0,0,0|7,0,1,6,0,2,5,9,0|0,0,0,4,0,1,0,0,6");
			Assert.IsTrue (b.IsValid ());

			b = new Board ("4,4,0,9,0,7,0,0,0|0,2,3,5,0,6,9,0,7|0,0,0,8,2,4,1,0,0|1,7,0,0,4,0,3,6,0|0,0,0,0,0,0,0,0,0|0,3,4,0,6,0,0,7,2|0,0,6,7,5,3,0,0,0|7,0,1,6,0,2,5,9,0|0,0,0,4,0,1,0,0,6");
			Assert.IsFalse (b.IsValid ());
		}

		[Test ()]
		public void SetCell ()
		{
			var b = new Board ("4,0,0,9,0,7,0,0,0|0,2,3,5,0,6,9,0,7|0,0,0,8,2,4,1,0,0|1,7,0,0,4,0,3,6,0|0,0,0,0,0,0,0,0,0|0,3,4,0,6,0,0,7,2|0,0,6,7,5,3,0,0,0|7,0,1,6,0,2,5,9,0|0,0,0,4,0,1,0,0,6");
			b.SetCell (0, 1, 4);
			Assert.IsFalse (b.IsValid ());

		}

		[Test ()]
		public void GetOptions ()
		{
			var b = new Board ("4,0,0,9,0,7,0,0,0|0,2,3,5,0,6,9,0,7|0,0,0,8,2,4,1,0,0|1,7,0,0,4,0,3,6,0|0,0,0,0,0,0,0,0,0|0,3,4,0,6,0,0,7,2|0,0,6,7,5,3,0,0,0|7,0,1,6,0,2,5,9,0|0,0,0,4,0,1,0,0,6");
			var options = b.GetOptions ();
			Assert.AreEqual (b.EmptyCells (), options.Count);
		}

		[Test ()]
		public void ToString ()
		{
			var easy = "4,0,0,9,0,7,0,0,0|0,2,3,5,0,6,9,0,7|0,0,0,8,2,4,1,0,0|1,7,0,0,4,0,3,6,0|0,0,0,0,0,0,0,0,0|0,3,4,0,6,0,0,7,2|0,0,6,7,5,3,0,0,0|7,0,1,6,0,2,5,9,0|0,0,0,4,0,1,0,0,6";
			var b = new Board (easy);
			Assert.AreEqual(easy,b.ToString ());
		}

		[Test ()]
		public void Simplify ()
		{
			var b = new Board ("4,0,0,9,0,7,0,0,0|0,2,3,5,0,6,9,0,7|0,0,0,8,2,4,1,0,0|1,7,0,0,4,0,3,6,0|0,0,0,0,0,0,0,0,0|0,3,4,0,6,0,0,7,2|0,0,6,7,5,3,0,0,0|7,0,1,6,0,2,5,9,0|0,0,0,4,0,1,0,0,6");
			b.Simplify ();
			Assert.IsTrue (b.IsValid ());
			Assert.IsTrue (b.IsComplete ());
		}

		[Test ()]
		public void Simplify2 ()
		{
			var b = new Board ("0,0,6,0,9,0,0,0,7|8,4,0,7,3,2,1,6,0|0,0,0,1,0,0,0,4,2|4,9,0,0,0,0,7,3,0|0,0,3,0,0,0,2,0,0|0,1,7,0,0,0,0,9,6|9,3,0,0,0,4,0,0,0|0,6,1,3,2,9,0,7,8|7,0,0,0,5,0,9,0,0");
			var b4 = b.EmptyCells ();
			b.Simplify ();
			Assert.IsTrue (b.IsValid ());
			Assert.IsFalse (b.IsComplete ());
			var after = b.EmptyCells (); 

			var x = b.GetOptions ().Where ((o) => o.Options.Count == 2).ToList();

		}

		[Test ()]
		public void Clone ()
		{
			var b = new Board ("0,0,6,0,9,0,0,0,7|8,4,0,7,3,2,1,6,0|0,0,0,1,0,0,0,4,2|4,9,0,0,0,0,7,3,0|0,0,3,0,0,0,2,0,0|0,1,7,0,0,0,0,9,6|9,3,0,0,0,4,0,0,0|0,6,1,3,2,9,0,7,8|7,0,0,0,5,0,9,0,0");
			var clone = new Board (b);

			Assert.IsTrue (b.Equals(clone));

			b.SetCell (0,0,1);
			Assert.IsFalse (b.Equals(clone));
		}

	}
}

