namespace DO;
[Serializable]
public class  DalIdNotFound : Exception
{

    public DalIdNotFound(string Message): base(Message)  {    }
    
}

[Serializable]
public class  DalIdAlreadyExist : Exception
{
    public DalIdAlreadyExist(string Message): base(Message){    }
    
}


