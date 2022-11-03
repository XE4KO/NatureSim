using System.Collections.Generic;

namespace NatureSim.Console
{
	class Lion : Animal
	{
		public Lion()
			: base(
				"Lion",
				75,
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
