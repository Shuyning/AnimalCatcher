using UnityEngine;
using Zenject;

namespace AnimalCatcher.Components
{
    public class Character : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<Object, Character> { }
    }   
}