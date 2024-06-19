using AnimalCatcher.Components.Enums;
using UnityEngine;

namespace AnimalCatcher.Components
{
    public class YardBorder : MonoBehaviour, IEndYardPositionGetter
    {
        [SerializeField] private Transform despawnObject;

        public Vector3 EndYardPosition => despawnObject.position;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IAnimalStateMachine animalStateMachine))
            {
                animalStateMachine.SwitchState(AnimalStateType.Yard);
                return;
            }
        }
    }   
}