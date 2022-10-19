using System.Collections.Generic;

namespace NatureSim.Console
{
	class Wolf : Animal
	{
		public Wolf()
			: base(
				"Wolf", 
				5,
				13,
				2, 
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
