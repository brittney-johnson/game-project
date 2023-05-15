using System.Reflection.Metadata;
using System.Threading.Tasks.Sources;

namespace StarterGame;
//game interface used to get item info
public interface IItem {
    string Name {
        get;
    }

    string LongName {
        get;
    }

    float Weight {
        get;
    }
    
    float Volume {
        get;
    }

    float Value {
        get;
    }

    string Description {
        get;
    }

    bool IsDecorator {
        get;
    }

    void AddDecorator(IItem decorator);
}

//game interface used to store IItemcontainer methods
public interface IItemContainer : IItem {
    void Insert(IItem item);

    IItem Remove(string itemName);
}

public interface INpc
{
    string Name
    {
        set; 
        get;
    }
    
    string Description {
        get;
    }

    Room Location
    {
        set; 
        get;
    }

}


public interface ICloseable {
    bool IsClosed {
        get;
    }

    bool IsOpen {
        get;
    }

    bool Open();
    bool Close();
}

    
public interface ILockable {
    bool IsLocked {
        get;
    }

    bool IsUnlocked {
        get;
    }

    bool Unlock();
    bool Lock();

    bool CanOpen {
        get;
    }

    bool CanClose {
        get;
    }

        

}

