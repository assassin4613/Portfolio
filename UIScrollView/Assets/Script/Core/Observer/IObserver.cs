using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Observer
{
    public interface IObserver
    {
        int ID { get; set; }
        int Priority { get; set; }
        void OnResponse(object obj);
    }
}
