using UnityEngine;

namespace AnimalCatcher.Components
{
    public interface IEndYardPositionGetter
    {
        public Vector3 EndYardPosition { get; }
    }
}