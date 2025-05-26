 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chain.Service.Client
{
    public abstract class ClientBotBase : IClient
    {
        public ClientBotBase(ElementType elementType)
        {
            this.elementType = elementType;
        }

        public ElementType elementType { get; set; }

    }
}

