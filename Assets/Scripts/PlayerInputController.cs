using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputManager _inputManager;

    private TerrainRayCaster _terrainRayCaster;
    private BuildingRayCaster _buildingRayCaster;

    private Vector2 _position;

    private void OnDisable()
    {
        _playerInput.Disable();

        _playerInput.Player.Click.performed -= OnClick;
        _playerInput.Player.GetCordinate.performed -= GetCordinate;
    }

    public void Init(BuildingRayCaster buildingRayCaster, TerrainRayCaster terrainRayCaster)
    {
        _terrainRayCaster = terrainRayCaster;
        _buildingRayCaster = buildingRayCaster;

        _inputManager = new InputManager();
        _playerInput = new PlayerInput();

        Enable();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (_buildingRayCaster.TryPushRay(_position, out IBuil build))
            _inputManager.GiveBuild(build);
        else
            _inputManager.PlaceBuild();
    }

    public void GetCordinate(InputAction.CallbackContext context)
    {
        _position = context.ReadValue<Vector2>();

        if (_terrainRayCaster.TryPushRay(_position, out Vector3 point))
            _inputManager.SetPosition(point);

    }

    private void Enable()
    {
        _playerInput.Enable();

        _playerInput.Player.Click.performed += OnClick;
        _playerInput.Player.GetCordinate.performed += GetCordinate;
    }
}
