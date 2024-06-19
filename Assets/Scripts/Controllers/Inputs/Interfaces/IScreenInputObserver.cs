using System;
using UnityEngine;

namespace AnimalCatcher.Controllers
{
    public interface IScreenInputObserver
    {
        public event Action<Vector2> SingleTouchInputHandled;
    }
}