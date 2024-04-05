using Extentions;

namespace EnumerableExtentionsUnitTests
{
	[TestFixture]
	public class NegativeTests
	{
		private static readonly object[] SourceList = 
		[
			new List<int>() {},
			Array.Empty<int>()
		];

		[TestCaseSource(nameof(SourceList))]
		public void Shuffle_CollectionIsEmpty<T>(IEnumerable<T> collection)
		{
			var shuffleCollection = collection.Shuffle();
			Assert.That(shuffleCollection.Count(), Is.EqualTo(0));
		}
	}
}
