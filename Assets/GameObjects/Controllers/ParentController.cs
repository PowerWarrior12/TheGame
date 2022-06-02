using Assets.GameObjects.Interfaces;
using UnityEngine;

namespace Assets.GameObjects.Controllers
{
    internal class ParentController : MonoBehaviour
    {
        [SerializeField]
        private IController workController;
        [SerializeField]
        private IController buildingController;
        [SerializeField]
        private IController defaultController;
        [SerializeField]
        private Camera _camera;

        private void Start()
        {
            workController.PrepareToWork();
        }
        private void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10);
            RaycastHit hitData;
            if (Physics.Raycast(ray, out hitData))
            {
                workController.ObserveMousePosition(hitData.point);
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    workController.Click(hitData);
                    UpdateController(ControllerAction.SIMPLECLICK);
                }
            }
        }

        public void OnMenuClick()
        {
            UpdateController(ControllerAction.MENUCLICK);
        }

        private void UpdateController(ControllerAction controllerAction)
        {
            switch (controllerAction)
            {
                case ControllerAction.MENUCLICK:
                    SwapWorkController(buildingController);
                    break;
                case ControllerAction.SIMPLECLICK:
                    SwapWorkController(defaultController);
                    break;
            }
        }

        private void SwapWorkController(IController newController)
        {
            workController.StopWork();
            workController = newController;
            workController.PrepareToWork();
        }

        enum ControllerAction
        { 
            MENUCLICK, SIMPLECLICK
        }
    }
}
