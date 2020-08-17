// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""eac0bd27-3c42-485c-ae1f-218163a597d5"",
            ""actions"": [
                {
                    ""name"": ""Player1Move"",
                    ""type"": ""Value"",
                    ""id"": ""784e0f93-0e62-49d2-b403-e9680db74c14"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Player1Jump"",
                    ""type"": ""Button"",
                    ""id"": ""46fb241a-2882-48e7-8852-d35f9939ec43"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Player2Move"",
                    ""type"": ""Value"",
                    ""id"": ""e53a7bb7-854e-41b1-af8f-a1ad97723ab7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Player2Jump"",
                    ""type"": ""Button"",
                    ""id"": ""3f074e4a-2935-462f-9b71-c02c20a23bb7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""29f59cf9-d068-4180-8a66-3e5f3fbd63e9"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Player1Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d68453f-a1fa-4e15-b6c9-05ed512768f1"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player1Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51e3918f-4c13-496c-a155-6cc1ff9583d9"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Player2Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12049b2b-e115-450f-9708-24c10d7be6b6"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player2Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_Player1Move = m_GamePlay.FindAction("Player1Move", throwIfNotFound: true);
        m_GamePlay_Player1Jump = m_GamePlay.FindAction("Player1Jump", throwIfNotFound: true);
        m_GamePlay_Player2Move = m_GamePlay.FindAction("Player2Move", throwIfNotFound: true);
        m_GamePlay_Player2Jump = m_GamePlay.FindAction("Player2Jump", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_Player1Move;
    private readonly InputAction m_GamePlay_Player1Jump;
    private readonly InputAction m_GamePlay_Player2Move;
    private readonly InputAction m_GamePlay_Player2Jump;
    public struct GamePlayActions
    {
        private @PlayerControls m_Wrapper;
        public GamePlayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Player1Move => m_Wrapper.m_GamePlay_Player1Move;
        public InputAction @Player1Jump => m_Wrapper.m_GamePlay_Player1Jump;
        public InputAction @Player2Move => m_Wrapper.m_GamePlay_Player2Move;
        public InputAction @Player2Jump => m_Wrapper.m_GamePlay_Player2Jump;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @Player1Move.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPlayer1Move;
                @Player1Move.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPlayer1Move;
                @Player1Move.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPlayer1Move;
                @Player1Jump.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPlayer1Jump;
                @Player1Jump.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPlayer1Jump;
                @Player1Jump.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPlayer1Jump;
                @Player2Move.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPlayer2Move;
                @Player2Move.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPlayer2Move;
                @Player2Move.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPlayer2Move;
                @Player2Jump.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPlayer2Jump;
                @Player2Jump.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPlayer2Jump;
                @Player2Jump.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPlayer2Jump;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Player1Move.started += instance.OnPlayer1Move;
                @Player1Move.performed += instance.OnPlayer1Move;
                @Player1Move.canceled += instance.OnPlayer1Move;
                @Player1Jump.started += instance.OnPlayer1Jump;
                @Player1Jump.performed += instance.OnPlayer1Jump;
                @Player1Jump.canceled += instance.OnPlayer1Jump;
                @Player2Move.started += instance.OnPlayer2Move;
                @Player2Move.performed += instance.OnPlayer2Move;
                @Player2Move.canceled += instance.OnPlayer2Move;
                @Player2Jump.started += instance.OnPlayer2Jump;
                @Player2Jump.performed += instance.OnPlayer2Jump;
                @Player2Jump.canceled += instance.OnPlayer2Jump;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    public interface IGamePlayActions
    {
        void OnPlayer1Move(InputAction.CallbackContext context);
        void OnPlayer1Jump(InputAction.CallbackContext context);
        void OnPlayer2Move(InputAction.CallbackContext context);
        void OnPlayer2Jump(InputAction.CallbackContext context);
    }
}
