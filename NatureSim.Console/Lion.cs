using System.Collections.Generic;

namespace NatureSim.Console
{
	class Lion : Animal
	{
		public Lion(Map map)
			: base(
				 map,
				"Lion",
				5,
				13,
				18,
				3, 
				4,
				new[]
				{
				Foods.mouse,
				Foods.meat,
				Foods.fish
				})
		{
		}
	}
}
