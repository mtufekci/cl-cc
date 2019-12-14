using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchResultMapper : ISearchResultMapper
    {
        public SearchResults Map(SearchResults searchResult, List<Shirt> results, (Color Color, Size Size) key)
        {
            searchResult.Shirts.AddRange(results);
            searchResult.SizeCounts.First(n => n.Size == key.Size).Count += results.Count;
            searchResult.ColorCounts.First(n => n.Color == key.Color).Count += results.Count;
            return searchResult;
        }
    }
}