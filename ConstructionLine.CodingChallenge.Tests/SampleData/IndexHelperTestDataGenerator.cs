using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge.Tests.SampleData
{
    public class IndexHelperTestDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                indexedShirts,
                new SearchOptions
                {
                    Colors = new List<Color> {Color.Red}
                },
                1
            },
            new object[]
            {
                indexedShirts,
                new SearchOptions
                {
                    Colors = new List<Color> {Color.Red},
                    Sizes = new List<Size> {Size.Large}
                },
                1
            },
            new object[]
            {
                indexedShirts,
                new SearchOptions
                {
                    Colors = new List<Color> {Color.Blue}
                },
                2
            },
            new object[]
            {
                indexedShirts,
                new SearchOptions
                {
                    Sizes = new List<Size> {Size.Large}
                },
                2
            },
            new object[]
            {
                indexedShirts,
                new SearchOptions
                {
                    Sizes = new List<Size> {Size.Large},
                    Colors = new List<Color> {Color.Yellow}
                },
                0
            }
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        static readonly Dictionary<(Color Color, Size Size), List<Shirt>> indexedShirts =  new Dictionary<(Color Color, Size Size), List<Shirt>>
            {
                {
                    (Color.Black, Size.Medium),
                    Enumerable.Repeat(new Shirt(Guid.NewGuid(), string.Empty, Size.Medium, Color.Black), 1).ToList()
                },
                {
                    (Color.Blue, Size.Small),
                    Enumerable.Repeat(new Shirt(Guid.NewGuid(), string.Empty, Size.Small, Color.Blue), 1).ToList()
                },
                {
                    (Color.Red, Size.Large),
                    Enumerable.Repeat(new Shirt(Guid.NewGuid(), string.Empty, Size.Large, Color.Red), 1).ToList()
                },
                {
                    (Color.Blue, Size.Large),
                    Enumerable.Repeat(new Shirt(Guid.NewGuid(), string.Empty, Size.Large, Color.Blue), 1).ToList()
                }
            };
    }
}