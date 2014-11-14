using NUnit.Framework;
using System;
using KSUD;

namespace SubBoardTests
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void IsComplete ()
		{
			var sb = new SubBoard ("123456789");
			Assert.IsTrue (sb.IsComplete ());

			sb = new SubBoard ("023456789");
			Assert.IsFalse (sb.IsComplete ());
		}


		[Test ()]
		public void IsValid ()
		{
			var sb = new SubBoard ("123456789");
			Assert.IsTrue (sb.IsValid ());

			sb = new SubBoard ("113456789");
			Assert.IsFalse (sb.IsValid ());

		}

		[Test ()]
		public void SetCell ()
		{
			var sb = new SubBoard ("123456709");
			sb.SetCell (2, 1, 8);
			Assert.IsTrue (sb.IsValid());
			Assert.IsTrue (sb.IsComplete());

			sb = new SubBoard ("123456709");
			sb.SetCell (2, 1, 7);
			Assert.IsFalse (sb.IsValid());
			Assert.IsTrue (sb.IsComplete());

			sb = new SubBoard ("123456709");
			sb.SetCell (7, 7);
			Assert.IsFalse (sb.IsValid());
			Assert.IsTrue (sb.IsComplete());


		}

		[Test ()]
		public void GetOptions ()
		{
			var sb = new SubBoard ("123456709");
			var options = sb.GetOptions (2, 1);
			Assert.AreEqual (1, options.Count);

			sb = new SubBoard ("123456709");
			options = sb.GetOptions (7);
			Assert.AreEqual (1, options.Count);

			sb = new SubBoard ("023456709");
			options = sb.GetOptions (0);
			Assert.AreEqual (2, options.Count);

		}

		[Test ()]
		public void EmptyCells ()
		{
			var sb = new SubBoard ("123456709");
			Assert.AreEqual (1, sb.EmptyCells ());
		}

		[Test ()]
		public void Clone ()
		{
			var sb = new SubBoard ("123456709");
			var clone = new SubBoard (sb);

			Assert.IsTrue (sb.Equals(clone));

			sb.SetCell (7, 8);
			Assert.IsFalse (sb.Equals(clone));

		}
	}
}
