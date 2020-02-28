using System;

public class DIRequestScope:IDIScope{
    public Guid InstanceID {get; private set;}
    public DIRequestScope(){
        this.InstanceID = Guid.NewGuid();
        System.Console.WriteLine(this.GetType().Name+":" + this.InstanceID);
    }
    public override string ToString(){
        return this.GetType().Name+":" + this.InstanceID;
    }
}