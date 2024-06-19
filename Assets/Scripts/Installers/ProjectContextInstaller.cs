using AnimalCatcher.Controllers;
using AnimalCatcher.Models;
using UnityEngine;
using Zenject;

namespace AnimalCatcher.Installers
{
    public class ProjectContextInstaller : MonoInstaller
    {
        [SerializeField] private InputSchemeData inputSchemeData;
        
        public override void InstallBindings()
        {
            InstallInput();
        }

        private void InstallInput()
        {
            Container.BindInterfacesTo<ScreenInputHandler>().AsSingle().WithArguments(inputSchemeData);
        }
    }
}