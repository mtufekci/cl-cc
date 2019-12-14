using System.Collections.Generic;

namespace ConstructionLine.CodingChallenge
{
    public interface IIndexHelper
    {
        IEnumerable<(Color Color, Size Size)> GetIndexesBySearchOptions(
            Dictionary<(Color Color, Size Size), List<Shirt>> indexShirts,
            SearchOptions options);
    }
}