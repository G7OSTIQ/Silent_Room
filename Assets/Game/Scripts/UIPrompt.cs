using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Scripts
{
    
    [RequireComponent(typeof(PanelRenderer))]
    public class UIPrompt : MonoBehaviour
    {
        [SerializeField] private PlayerInteraction playerInteraction;
        
        private PanelRenderer panelRenderer;
        private Label UiLabel;

        private void Awake()
        {
            panelRenderer = GetComponent<PanelRenderer>();
            
            panelRenderer.RegisterUIReloadCallback(OnUIReload);
        }

        //When player is near an object it will detect and updates the player interaction
        private void OnEnable()
        {
            playerInteraction.TargetChanged += OnTargetChanged;
        }
        
        private void OnDisable()
        {
            playerInteraction.TargetChanged -= OnTargetChanged;
        }

        private void OnDestroy()
        {
            panelRenderer.UnregisterUIReloadCallback(OnUIReload);
        }


        private void OnUIReload(PanelRenderer panel, VisualElement root, int version) // remember the white are var here
        {
            UiLabel = root.Q<Label>("PromptLabel"); //calls the promptlabel from the uss code

            //Hides when the player isn't looking at anything
            Hide();
        }

        private void OnTargetChanged(IInteractable target) //Calls the bell when the player is looking at something new (or nothing)
        {
            if (target != null)
                Show();
            else
            {
                Hide();
            }
            
        }

        private void Show()
        {
            if(UiLabel == null)
                return;
            
            UiLabel.style.display = DisplayStyle.Flex; // make is show
        }
        
        private void Hide()
        {
            if(UiLabel == null)
                return;
            
            UiLabel.style.display = DisplayStyle.None; // make is hide
        }
        
        
        
    }
}