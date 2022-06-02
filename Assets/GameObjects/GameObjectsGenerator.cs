using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.GameObjects
{
    internal class GameObjectsGenerator: MonoBehaviour
    {
        [SerializeField]
        private GameObject buildingPrefab;
        [SerializeField]
        private GameObject characterPrefab;

        public GameObject CreateBuildingPrefab(Vector3 position)
        {
            return GameObject.Instantiate(buildingPrefab, position, Quaternion.identity);
        }

    }
}
