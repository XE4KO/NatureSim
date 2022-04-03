
namespace NatureSim.Console
{
    class Bear : Animal
    { 
        public Bear()
        {
            base.health = 15;
            base.animalType = "Bear";
            base.diet = new string[3];
            base.diet[0] = "meat";
            base.diet[1] = "fish";
            base.diet[2] = "berry";
        }
    }
}
