using System.Collections.Generic;
using System;

namespace NatureSim.Console
{
	class Bear : Animal
	{

		public Bear()
			: base(
				"Bear",
				90,
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
