using System.Collections.Generic;

namespace NatureSim.Console
{
	class Bunny : Animal
	{
		public Bunny()
			: base(
				"Bunny", 
				35,
				2,
				3,
				8,
				2,
				3,
				new []
				{
				Foods.berry,
				Foods.carrot,
				Foods.grass,
				Foods.acorn,
				})
		{
		}
	}
}
