 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chain.Service.Client
{
    public abstract class ClientBotBase : IClient
    {
        public ElementType elementType { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}

