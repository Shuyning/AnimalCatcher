using UnityEngine;

namespace AnimalCatcher.Models
{
    [CreateAssetMenu(fileName = "AnimalSpawnConfig ", menuName = "ScriptableObjects/AnimalSpawnConfig")]
    public class AnimalSpawnConfig : ScriptableObject
    {
        [field: SerializeField] public int MaxActiveAnimalAmount { get; private set; }
        [field: Header("Time Interval")]
        [field: SerializeField, Range(0.01f, 10f)] public float MinSpawnTime { get; private set; } = 0.25f;
        [field: SerializeField, Range(0.01f, 10f)] public float MaxSpawnTime { get; private set; } = 3f;
    }   
}