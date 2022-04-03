
namespace NatureSim.Console
{
    class Bunny : Animal
    {
        public Bunny()
        {
            base.health = 3;
            base.animalType = "Bunny";
            base.diet = new string[6];
            base.diet[0] = "berry";
            base.diet[1] = "carrot";
            base.diet[2] = "grass";
            base.diet[3] = "cabage";
            base.diet[4] = "acorn";
            base.diet[5] = "almond";
        }
    }
}
