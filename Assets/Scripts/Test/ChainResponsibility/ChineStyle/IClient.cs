using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chain.Service.Client
{
    public interface IClient
    {
        ElementType elementType { get; set; }
    }
    public enum ElementType
    {
       Freez,
       Ellectro,
       Fire,
       None
    }
}

