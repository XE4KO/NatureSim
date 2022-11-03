using System.Collections.Generic;

namespace NatureSim.Console
{
	class Wolf : Animal
	{
		public Wolf()
			: base(
				"Wolf", 
				75,
				5,
				13,
				18,
				2, 
				3,
				new[] 
				{ 
				Foods.meat, 
				Foods.fish, 
				Foods.fly 
				})
		{
		}
	}
}
