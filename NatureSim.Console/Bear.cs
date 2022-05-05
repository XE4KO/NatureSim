using System.Collections.Generic;

namespace NatureSim.Console
{
	class Bear : Animal
	{
		public Bear()
			: base(
				"Bear",
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
