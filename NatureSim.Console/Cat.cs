using System.Collections.Generic;

namespace NatureSim.Console
{
	class Cat : Animal
	{
		public Cat()
			: base(
				"Cat",
				50,
				3,
				5,
				10,
				2, 
				3,
				new[] 
				{ 
				Foods.mouse, 
				Foods.fly, 
				Foods.fish 
				})
		{
		}
	}
}
