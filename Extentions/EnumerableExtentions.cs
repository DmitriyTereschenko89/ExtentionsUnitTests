namespace Extentions
{
	public static class EnumerableExtentions
	{
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> collection)
		{
			if (collection is null)
			{
				throw new ArgumentNullException(nameof(collection));
			}

			var shuffleCollection = collection.ToList();
			var generator = new Random();
			int n = shuffleCollection.Count;
			for (int idx = 0; idx < n; ++idx)
			{
				int shuffleIdx = generator.Next(idx, n);
				(shuffleCollection[idx], shuffleCollection[shuffleIdx]) = (shuffleCollection[shuffleIdx], shuffleCollection[idx]);
			}
			return shuffleCollection;
		}
	}
}
