using UnityEngine;

namespace AnimalCatcher.Controllers
{
    public interface IFollowCharacterSetter
    {
        public void SetCharacterTransform(Transform transform);
    }
}