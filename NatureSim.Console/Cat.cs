using System.Collections.Generic;

namespace NatureSim.Console
{
	class Cat : Animal
	{
		public Cat(Map map)
			: base(
				 map,
				"Cat",
				hungerLoss: 3,
				health: 5,
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
