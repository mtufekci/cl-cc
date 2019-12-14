using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge.Tests.SampleData
{
    public class ShirtIndexerTestDataGenerator : IEnumerable<object[]>
    {
        public ShirtIndexerTestDataGenerator()
        {
            var shirts = GenerateShirtData();
            _data = new List<object[]>
            {
                new []
                {
                    shirts
                }
            };
        }

        private readonly List<object[]> _data;

        List<Shirt> GenerateShirtData()
        {
            var shirts = new List<Shirt>();
            shirts.AddRange(Enumerable.Repeat(new Shirt(Guid.NewGuid(), string.Empty, Size.Medium, Color.Black) , 100).ToList());
            shirts.AddRange(Enumerable.Repeat(new Shirt(Guid.NewGuid(), string.Empty, Size.Small, Color.Red) , 30).ToList());
            shirts.AddRange(Enumerable.Repeat(new Shirt(Guid.NewGuid(), string.Empty, Size.Medium, Color.Blue) , 2).ToList());
            shirts.AddRange(Enumerable.Repeat(new Shirt(Guid.NewGuid(), string.Empty, Size.Large, Color.White) , 5).ToList());
            return shirts;
        }
        

        public IEnumerator<object[]> GetEnumerator()
        {
            
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}