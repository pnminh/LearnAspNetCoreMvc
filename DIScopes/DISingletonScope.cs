using System;

public class DITransientScope:IDIScope{
    public Guid InstanceID {get; private set;}
    public DITransientScope(){
        this.InstanceID = Guid.NewGuid();
        System.Console.WriteLine(this.GetType().Name+":" + this.InstanceID);
    }
    public override string ToString(){
        return this.GetType().Name+":" + this.InstanceID;
    }
}