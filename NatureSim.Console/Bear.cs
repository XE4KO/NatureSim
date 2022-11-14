using System.Collections.Generic;
using System;

namespace NatureSim.Console
{
    class Bear : Animal
    {

        public Bear(Map map)
            : base(
                map,
                "Bear",
                5,
                15,
                20,
                2,
                3,
                new[] {
                    Foods.meat,
                    Foods.fish,
                    Foods.berry
                })
        {
        }
    }
}
