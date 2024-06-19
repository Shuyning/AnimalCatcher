using AnimalCatcher.Components;
using AnimalCatcher.Controllers;
using AnimalCatcher.Models;
using Components;
using UnityEngine;
using Zenject;

namespace AnimalCatcher.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        [Header("Configs")] 
        [SerializeField] private FollowCharacterConfig followCharacterConfig;
        
        [Header("Factories Components")] 
        [SerializeField] private Character characterPrefab;

        [Header("Animal Pool")] 
        [SerializeField] private AnimalSpawnConfig animalSpawnConfig;
        [SerializeField] private AnimalPool animalPrefab;
        [SerializeField] private int defaultAnimalCount = 7;
        [SerializeField] private Transform animalSpawnObject;
        
        public override void InstallBindings()
        {
            InstallPools();
            InstallSceneComponents();
            InstallFactories();
            InstallSceneControllers();
        }

        private void InstallSceneComponents()
        {
            Container.BindInterfacesTo<CameraComponent>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<GameAreaPositionController>().FromComponentInHierarchy().AsSingle();
        }

        private void InstallFactories()
        {
            Container.BindFactory<Object, Character, Character.Factory>().FromFactory<PrefabFactory<Character>>();
            Container.BindInterfacesAndSelfTo<CharacterSpawner>().AsSingle().WithArguments(characterPrefab);
        }

        private void InstallSceneControllers()
        {
            Container.Bind<IEndYardPositionGetter>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<ScoreCounter>().AsSingle();
            Container.BindInterfacesTo<FollowCharacterController>().AsSingle().WithArguments(followCharacterConfig);
        }

        private void InstallPools()
        {
            Container.BindMemoryPool<AnimalPool, AnimalPool.Pool>().WithInitialSize(defaultAnimalCount).
                FromComponentInNewPrefab(animalPrefab).UnderTransform(transform);

            Container.BindInterfacesTo<AnimalSpawnController>().AsSingle().WithArguments(animalSpawnObject, animalSpawnConfig);
        }
    }   
}