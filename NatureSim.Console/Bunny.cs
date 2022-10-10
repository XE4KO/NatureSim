using System.Collections.Generic;

namespace NatureSim.Console
{
	class Bunny : Animal
	{
		public Bunny()
			: base(
				"Bunny", 
				2,
				3,
				2, 
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
