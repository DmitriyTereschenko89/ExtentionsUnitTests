using Extentions;

namespace EnumerableExtentionsUnitTests
{
	[TestFixture]
	public class PositiveTests
	{
		private static readonly object[] SourceList =
		[
			new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
			new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
			new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
			new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" },
			new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a' },
			new HashSet<double> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
		];

		private bool IsShuffle<T>(IEnumerable<T> collection, IEnumerable<T> shuffleCollection)
		{
			int notShufflePosition = 0;
			var collectionList = collection.ToList();
			var shuffleCollectionList = shuffleCollection.ToList();
			for (int i = 0; i < collectionList.Count; ++i)
			{
				if (!collectionList[i].Equals(shuffleCollectionList[i]))
				{
					++notShufflePosition;
				}
			}
			return notShufflePosition > 0; 
		}

		[TestCaseSource(nameof(SourceList))]
		public void Shuffle_Arrays<T>(IEnumerable<T> collection)
		{
			var shuffleCollection = collection.Shuffle();
			Assert.That(IsShuffle(collection, shuffleCollection), Is.EqualTo(true));
		}

		[TestCaseSource(nameof(SourceList))]
		public void Shuffle_Collections<T>(IEnumerable<T> collection)
		{
			var shuffleCollection = collection.ShuffleUsingLinq();
			Assert.That(IsShuffle(collection, shuffleCollection), Is.EqualTo(true));
		}
	}
}
