using System.Collections.Generic;

namespace ConstructionLine.CodingChallenge
{
    public interface ISearchResultMapper
    {
        SearchResults Map(
            SearchResults searchResult,
            List<Shirt> results,
            (Color Color, Size Size) key);
    }
}