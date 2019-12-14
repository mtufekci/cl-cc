using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class IndexHelper : IIndexHelper
    {
        public IEnumerable<(Color Color, Size Size)> GetIndexesBySearchOptions(
            Dictionary<(Color Color, Size Size), List<Shirt>> indexShirts,
            SearchOptions options)
        {
            var keys = options.Colors.Any()
                ? indexShirts.Keys.Where(n => options.Colors.Any(color=> n.Color == color))
                : indexShirts.Keys;

            keys = options.Sizes.Any() 
                ? keys.Where(n => options.Sizes.Any(size => n.Size == size)) 
                : keys;
            return keys;
        }
    }
}