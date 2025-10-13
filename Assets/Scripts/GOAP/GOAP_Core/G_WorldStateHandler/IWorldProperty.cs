using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWorldProperty  
{ 
    IWorldProperty Clone(); 
    object GetValue(); 
    void SetValue(object v);
}
