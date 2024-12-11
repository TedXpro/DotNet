public class Car{
    public int CurrSpeed { get; set; }
    public int MaxSpeed { get; set; } = 100;
    
    public string Name{ get; set; }

    public bool _isCarDead;

    public Car(){

    }

    public Car(string name, int currSpeed, int maxSpeed){
        Name = name;
        MaxSpeed = maxSpeed;
        CurrSpeed = currSpeed;
    }

    public delegate void CarEngineHandler (string msgForCaller) ;
    // private CarEngineHandler _listOfHandlers;
    public event CarEngineHandler Exploded;
    public event CarEngineHandler AboutToBlow;

    // public void RegisterWithCarEngine(CarEngineHandler methodToCall){
    //     _listOfHandlers += methodToCall;
    // }

    // public void UnRegisterWithCarEngine(CarEngineHandler methodToRemove){
    //     _listOfHandlers -= methodToRemove;
    // }

    public void Accelerate(int delta){
        if(_isCarDead){
            Exploded?.Invoke("Sorry, this car is dead...");
        } else {
            CurrSpeed += delta;
            if(10 == (MaxSpeed - CurrSpeed)){
                AboutToBlow?.Invoke("Careful buddy! Gonna blow! CurrSpeed is " + CurrSpeed);
            }
            if(CurrSpeed >= MaxSpeed){
                _isCarDead = true;
            } else {
                Console.WriteLine("Current Speed = {0}", CurrSpeed);
            }
        }
    }

}