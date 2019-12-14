using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class ShirtIndexer : IShirtIndexer
    {
        public Dictionary<(Color Color, Size Size), List<Shirt>> IndexShirts(List<Shirt> shirts)
        {
            var indexedShirts = new Dictionary<(Color Color, Size Size), List<Shirt>>();
            foreach (var shirt in shirts)
            {
                var index =
                    indexedShirts.Keys
                        .FirstOrDefault(n => n.Color == shirt.Color && n.Size == shirt.Size);

                if (index.Equals(default))
                {
                    index = (shirt.Color, shirt.Size);
                    indexedShirts[index] = new List<Shirt>();
                }
                indexedShirts[index].Add(shirt);
            }

            return indexedShirts;
        }
        
    }
}