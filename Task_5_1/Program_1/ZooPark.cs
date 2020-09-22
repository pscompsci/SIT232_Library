using System;

namespace Task01
{
    class ZooPark
    {
        static void Main(string[] args)
        {
            Animal williamWolf = new Animal("William the Wolf", "Meat", "Dog Village", 50.6, 9, "Grey");
            Animal tonyTiger = new Animal("Tony the Tiger", "Meat", "Cat Land", 110, 6, "Orange and White");
            Animal edgarEagle = new Animal("Edgar the Eagle", "Fish", "Bird Mania", 20, 15, "Black");

            williamWolf.makeWolfNoise();
            edgarEagle.makeEagleNoise();


            edgarEagle.makeWolfNoise();
        }
    }
}
