using System.Collections.Generic;

namespace NatureSim.Console
{
    class Wolf : Animal
    {
        public Wolf(Map map)
            : base(
                map,
                "Wolf",
                5,
                13,
                18,
                2,
                3,
                new[] {
                    Foods.meat,
                    Foods.fish,
                    Foods.fly 
                })
        {
        }
    }
}
