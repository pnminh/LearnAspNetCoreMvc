using System;

public class DISingletonScope:IDIScope{
    public Guid InstanceID {get; private set;}
    public DISingletonScope(){
        this.InstanceID = Guid.NewGuid();
        System.Console.WriteLine(this.GetType().Name+":" + this.InstanceID);
    }
    public override string ToString(){
        return this.GetType().Name+":" + this.InstanceID;
    }
}