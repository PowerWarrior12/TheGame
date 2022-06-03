using Assets.GameObjects.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.GameObjects
{
    internal class GameObjectsManager : MonoBehaviour
    {
        [SerializeField]
        private GameObjectsGenerator gameObjectsGenerator;
        private ArrayList gameObjects;

        public ArrayList GetGameObjects()
        {
            return gameObjects;
        }

        private void Start()
        {
            gameObjects = new ArrayList();
        }

        public GameObject CreateBuilding(Vector3 position)
        {
            var gameObject = gameObjectsGenerator.CreateBuildingPrefab(position);
            GetGameObjects().Add(gameObject);
            return gameObject;
        }
    }
}
