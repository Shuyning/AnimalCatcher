using System;
using AnimalCatcher.Models;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace AnimalCatcher.Controllers
{
    public class ScreenInputHandler : IInitializable, IDisposable, IScreenInputObserver
    {
        private readonly InputSchemeData _inputSchemeData;
        
        public event Action<Vector2> SingleTouchInputHandled;

        [Inject]
        public ScreenInputHandler(InputSchemeData inputSchemeData)
        {
            _inputSchemeData = inputSchemeData;
        }
        
        public void Initialize()
        {
            _inputSchemeData.SingleScreenTouch.action.started += HandleBeganSingleTouchPhase;
            
            _inputSchemeData.SingleScreenTouch.action.Enable();
        }
        
        public void Dispose()
        {
            _inputSchemeData.SingleScreenTouch.action.started -= HandleBeganSingleTouchPhase;
            
            _inputSchemeData.SingleScreenTouch.action.Disable();
        }

        private void HandleBeganSingleTouchPhase(InputAction.CallbackContext context)
        {
            SingleTouchInputHandled?.Invoke(context.ReadValue<Vector2>());
        }
    }   
}