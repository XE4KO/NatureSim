using System.Collections.Generic;
using System;

namespace NatureSim.Console
{
	class Bear : Animal
	{

		public Bear()
			: base(
				"Bear",
				5,
				15,
				2,
				new[] {
					Foods.meat,
					Foods.fish,
					Foods.berry
				})
		{
		}
	}
}
