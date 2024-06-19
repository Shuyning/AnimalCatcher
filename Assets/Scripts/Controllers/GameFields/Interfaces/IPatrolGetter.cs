using UnityEngine;

namespace AnimalCatcher.Controllers
{
    public interface IPatrolGetter
    {
        public Vector2[] GetRandomPositionsArray();
    }   
}