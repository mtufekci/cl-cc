using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly IShirtIndexer _shirtIndexer;
        private readonly IIndexHelper _indexHelper;
        private readonly ISearchResultMapper _searchResultMapper;

        //Indexed by (Color:Color, Size:Size) Tuple
        private readonly Dictionary<(Color Color, Size Size), List<Shirt>> _indexedShirts;

        public SearchEngine(List<Shirt> shirts, 
            IShirtIndexer shirtIndexer,
            IIndexHelper indexHelper,
            ISearchResultMapper searchResultMapper)
        {
            _shirtIndexer = shirtIndexer;
            _indexHelper = indexHelper;
            _searchResultMapper = searchResultMapper;
            _indexedShirts = _shirtIndexer.IndexShirts(shirts);
        }

        public SearchResults Search(SearchOptions options)
        {
            // using (Color, Size) tuple as Dictionary indexes.
            // By this the index count can be max 3 Size x 5 Color = 15 size color combination
            // The implementation only touches those indexes
            // Shirts are grouped by those indexes at starts
            var indexes = _indexHelper.GetIndexesBySearchOptions(_indexedShirts, options).ToList();
            var result = GetShirtsByIndexes(indexes);
            return result;
        }

        private SearchResults GetShirtsByIndexes(List<(Color Color, Size Size)> keys)
        {
            var searchResult = new SearchResults
            {
                Shirts = new List<Shirt>(),
                ColorCounts = Color.All.Select(n => new ColorCount {Color = n}).ToList(),
                SizeCounts = Size.All.Select(n => new SizeCount {Size = n}).ToList()
            };

            //result = keys.SelectMany(key => _indexedShirts[key]).ToList(); // is SLOWER to get merges lists.
            keys.ForEach(key=>  searchResult = _searchResultMapper.Map(searchResult, _indexedShirts[key], key));

            return searchResult;
        }
    }
}