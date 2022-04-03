
namespace NatureSim.Console
{
    class Wolf : Animal
    {
        public Wolf()
        {
            base.health = 10;
            base.animalType = "Wolf";
            base.diet = new string[4];
            base.diet[0] = "meat";
            base.diet[1] = "fish";
            base.diet[2] = "giraffe";
            base.diet[3] = "elephant";
        }
    }
}
