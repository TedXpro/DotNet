using System.Net;

Car c1 = new Car("SlugBug", 10, 100);
// c1.RegisterWithCarEngine(OnCarEngineEvent);
// // c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent2));

// // Car.CarEngineHandler handler = new Car.CarEngineHandler(OnCarEngineEvent2);
// c1.RegisterWithCarEngine(OnCarEngineEvent2);

// c1.AboutToBlow += CarIsAlmostDoomed;
// c1.AboutToBlow += CarAboutToBlow;

c1.AboutToBlow += delegate
{
    Console.WriteLine("Eek! Going to fast!");
};

Car.CarEngineHandler delg = CarExploded;
c1.Exploded += delg;



Console.WriteLine("Speeding up");
for(int i = 0; i < 6; i++){
    c1.Accelerate(20);
}

Console.ReadLine();

// c1.UnRegisterWithCarEngine(OnCarEngineEvent2);

for (int i = 0; i < 6; i++)
{
    c1.Accelerate(20);
}

Console.ReadLine();

static void CarAboutToBlow(string msg){
    Console.WriteLine(msg);
}

static void CarIsAlmostDoomed(string msg){
    Console.WriteLine(msg);
}

static void CarExploded(string msg){
    Console.WriteLine(msg);
}

static void OnCarEngineEvent(string msg){
    Console.WriteLine("\n*** Message From Car Object ***");
    Console.WriteLine("=> {0}", msg);
    Console.WriteLine("******************\n");
}

static void OnCarEngineEvent2(string msg){
    Console.WriteLine("=> {0}", msg.ToUpper());
    Console.WriteLine("####################\n");
}