using BankConsole; 

public abstract class Person{

    public abstract string Getname();

    public string GetContry(){
        return "Mexico";
    }
}

public interface IPerson{
    string Getname();

    string GetContry();
}