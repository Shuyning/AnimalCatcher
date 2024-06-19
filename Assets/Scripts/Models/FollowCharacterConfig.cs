using UnityEngine;

namespace AnimalCatcher.Models
{
    [CreateAssetMenu(fileName = "FollowCharacterConfig", menuName = "ScriptableObjects/FollowCharacterConfig")]
    public class FollowCharacterConfig : ScriptableObject
    {
        [field: SerializeField] public int MaxFollowTarget { get; private set; } = 5;
    }
}