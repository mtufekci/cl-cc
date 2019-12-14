using System.Collections.Generic;

namespace ConstructionLine.CodingChallenge
{
    public interface IShirtIndexer
    {
        Dictionary<(Color Color, Size Size), List<Shirt>> IndexShirts(List<Shirt> shirts);
    }
}