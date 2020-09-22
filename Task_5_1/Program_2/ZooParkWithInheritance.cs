using System;

namespace Task02
{
    class ZooPark
    {
        static void Main(string[] args)
        {
            //Animal williamWolf = new Animal("William the Wolf", "Meat", "Dog Village", 50.6, 9, "Grey");
            //Animal tonyTiger = new Animal("Tony the Tiger", "Meat", "Cat Land", 110, 6, "Orange and White");
            //Animal edgarEagle = new Animal("Edgar the Eagle", "Fish", "Bird Mania", 20, 15, "Black");

            Tiger tonyTiger = new Tiger("Tony the Tiger", "Meat", "Cat Land", 110, 6,
                "Orange and White", "Siberian", "White");
            Wolf williamWolf = new Wolf("William the Wolf", "Meat", "Dog Village", 50.6, 9, "Grey");
            Eagle edgarEagle = new Eagle("Edgar the Eagle", "Fish", "Bird Mania", 20, 15,
                "Black", "Harpy", 98.5);

            Animal baseAnimal = new Animal("Animal Name", "Animal Diet", "Animal Location",
                0.0, 0, "Animal Colour");

            baseAnimal.eat();
            tonyTiger.eat();
            williamWolf.eat();
            edgarEagle.eat();

            baseAnimal.sleep();
            tonyTiger.sleep();
            williamWolf.sleep();
            edgarEagle.sleep();

            baseAnimal.makeNoise();
            tonyTiger.makeNoise();
            williamWolf.makeNoise();
            edgarEagle.makeNoise();

            baseAnimal.buildHome();
            tonyTiger.buildHome();
            williamWolf.buildHome();
            edgarEagle.buildHome();

            edgarEagle.layEgg();
            edgarEagle.fly();

            Lion leoLion = new Lion("Leo the Lion", "Meat", "Lion's Pride", 145, 3, "Sandy", "African");
            Penguin percyPenguin = new Penguin("Percy the Penguin", "Fish", "Antarctic Experience",
                12, 2, "Black and White", "Emperor", 20);

            leoLion.eat();
            leoLion.makeNoise();
            leoLion.buildHome();
            leoLion.sleep();

            percyPenguin.eat();
            percyPenguin.buildHome();
            percyPenguin.layEgg();
            percyPenguin.makeNoise();
            percyPenguin.fly();

            Wolf walterWolf = new Wolf("Walter the Wolf", "Meat", "Dog Village", 45.5, 5, "Brown");

            williamWolf.makeNoise();
            walterWolf.makeNoise();
            williamWolf.buildHome();
            walterWolf.sleep();
        }
    }
}
