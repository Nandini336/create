using System;
class Program
{
    static void Main()
  {
        //Constructor example
        ConstructorDemo customer = new ConstructorDemo("Harika", "Sandilya");
        customer.PrintFullName();

        //StaticReferenceMembersDemo
        StaticReferenceMembersDemo obj1 = new StaticReferenceMembersDemo(5);
        float area1 = obj1.CircleArea();//pi is static, radius is instance type
        Console.WriteLine("Ares is :"+ area1);

        StaticReferenceMembersDemo obj2 = new StaticReferenceMembersDemo(5);
        float area2 = obj2.CircleArea();
        Console.WriteLine("Ares is :" + area2);

        //Inheritance 
        FullTimeEmployee fullTime = new FullTimeEmployee();
        fullTime.firstName = "Harika";
        fullTime.salary = 1000000;
        PartTimeEmployee partTime = new PartTimeEmployee();
        partTime.firstName = "part time";
        partTime.partTimeSalary = 300000;
        //calling base class method from child class object 
        //((InheritanceDemo)partTime).PrintFullName();
        // creating obj of parent class
        //InheritanceDemo partTime2 = new PartTimeEmployee();
        //partTime2.PrintFullName();

        //PolyMorphism
        PolyMorphismDemo[] polyMorphism = new PolyMorphismDemo[3];
        polyMorphism[0] = new SeniorEmployee();
        polyMorphism[1] = new JuniorEmployee();
        polyMorphism[2] = new PolyMorphismDemo();

        foreach (PolyMorphismDemo item in polyMorphism)
        {
            Console.WriteLine("FIRST AND LAST NAMES:");
        }
    }
}

class ConstructorDemo
{
    string _firstName;
    string _lastName;
    static int i;
    //to initialize these fields we can have a constructor
    //Constructor doesnot have any return type.
    //A default constructor is invoked when we dont create one.
    //Default constructor is taken away when we create our own constructor    
    public ConstructorDemo(string FirstName, string LastName)//Parameterized constructor
    {
        this._firstName = FirstName;
        this._lastName = LastName;       
    }
    //We can create static constructor for instantiating static members but that constructor are not accessible outside the class
    //Static constructors automatically get called
    //It doesnot allow access modifiers
    //Static constructors are called before instance constructors and also before static fields
    //Static contr is called only once for n number of objects but, instance const are called each time an obj is created
    static ConstructorDemo()
    {
       ConstructorDemo.i = 3;
    }
    public ConstructorDemo() : this("harika","sandilya") //default constructor calling parameterized one
    {

    }
    public void PrintFullName()
    {
        Console.WriteLine("Full name = {0}", this._firstName + ""+ this._lastName);
    }

    //Destructor has same name as the class name, they dont take parameters, cannot have return type
    //~Customer() { }
}
class StaticReferenceMembersDemo
{
   static float pi = 3.141f;
    // pi value doesnot change to calculate area, so it can be made as static 
    //such that it is initiated only once and used n number of times, else if it is instance type, then it will be allocated memory evey time an object is invoked for this class
    int radius;
    //since radius value vary from object to object it can be made as instance type
    public StaticReferenceMembersDemo(int Radius)
    {
        this.radius = Radius;
    }
    public float CircleArea()
    {
        //this.pi is used if it is a instance type
        // return this.pi * this.radius * this.radius;

        //StaticReferenceMembersDemo.pi is used if it is static type
        return StaticReferenceMembersDemo.pi * this.radius * this.radius;
    }
}
class InheritanceDemo
{
    //Base classes are instantialted before than child classes and their constructoe is first called and then child const are called
   public string firstName;
    public string LastName;
    public string email;
    public void PrintFullName()
    {
        Console.WriteLine("Employee name" + this.firstName);
    }
}
class FullTimeEmployee : InheritanceDemo
{
    public float salary;
}
class PartTimeEmployee : InheritanceDemo
{
    public float partTimeSalary;    
    public new void PrintFullName()
    {
        //calling base class method as it is
        //Type 1: using base keyword
        base.PrintFullName();
        //Type 2: type casting        
        //((InheritanceDemo)partTime).PrintFullName();
        //Type 3: creating obj of parent class, only parent class ref can point to child class object but not vice versa
        //InheritanceDemo partTime2 = new PartTimeEmployee();
        //partTime2.PrintFullName();
        //Modifying base class method
        Console.WriteLine("Employee name" + this.firstName + "Modified base class method");
    }
}
class PolyMorphismDemo
{
    public string empName;
    public string empID;
    public virtual void PrintEmpDetails()
    {
        Console.WriteLine(this.empID + this.empName);
    }
}
class SeniorEmployee : PolyMorphismDemo
{
    //In method over riding, base class reference points child class object(see main method)
    //hence calls ovverriden base method from child class
    public override void PrintEmpDetails()
    {
        Console.WriteLine(this.empID + this.empName +  "Senior");
    }
}
class JuniorEmployee : PolyMorphismDemo
{
    //In method hiding, since the refrence is of typw base class, the base class methjod will be called and NOT the child class methos
    public override void PrintEmpDetails()
    {
        Console.WriteLine(this.empID + this.empName + "Junior");
    }
}

class OverLoadingDemo
{
    //Over loading is having same method name but different parameters
    //Over loading is based on name, data type and kind (i.e in or out parameters), no.of parameters but not on return type 
    public void add(int a, int b)
    {

    }
    public void add (int a, int b,  out int c)
    {
        c = a + b;
    }
}

class PropertiesDemo
{
    //Bussiness rules like id should be positive, and marks should be read only cannot be achieved with fileds, hence we use properties
    int id;
    string name;
    const int marks = 35;
}




