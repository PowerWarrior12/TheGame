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
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (workController.Click()) UpdateController(ControllerAction.SIMPLECLICK);
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                if (workController.ClickUp()) UpdateController(ControllerAction.SIMPLECLICKUP);
            }
            workController.ObserveMousePosition();
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
                case ControllerAction.SIMPLECLICKUP:
                                        SwapWorkController(defaultController);
                    break;
            }
        }

        private void SwapWorkController(IController newController)
        {
            if (workController == newController) return;
            workController.StopWork();
            workController = newController;
            workController.PrepareToWork();
        }

        enum ControllerAction
        { 
            MENUCLICK, SIMPLECLICK, SIMPLECLICKUP
        }
    }
}
