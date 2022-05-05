using System.Collections.Generic;

namespace NatureSim.Console
{
	class Cat : Animal
	{
		public Cat()
			: base("Cat", 5, new[] { Foods.mouse, Foods.catFood, Foods.fish })
		{
		}
	}
}
