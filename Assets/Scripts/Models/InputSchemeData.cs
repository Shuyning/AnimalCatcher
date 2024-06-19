using UnityEngine;
using UnityEngine.InputSystem;

namespace AnimalCatcher.Models
{
    [CreateAssetMenu(fileName = "InputSchemeConfig ", menuName = "ScriptableObjects/Inputs/InputSchemeData")]
    public class InputSchemeData : ScriptableObject
    {
        [field: SerializeField] public InputActionReference SingleScreenTouch { get; private set; }
    }   
}