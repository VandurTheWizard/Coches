using UnityEngine;
using UnityEngine.InputSystem;

public class InteractManager : MonoBehaviour
{
    [Header("Interactive Data")]
    public LayerMask interactiveLayer;

    private InteractiveData interactiveData;
    private InteractiveUIManager interactiveUIManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactiveUIManager = FindFirstObjectByType<InteractiveUIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInteractive();
    }

    private void CheckInteractive()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5, interactiveLayer))
        {
            InteractiveData detectedData = hit.collider.GetComponent<InteractiveData>();

            if (detectedData != null)
            {
                interactiveData = detectedData;
                string dataToText = interactiveData.GetAction() + " " + interactiveData.GetInteractiveName();
                interactiveUIManager.ShowData(dataToText);
                return;
            }
        }
        interactiveData = null;
        interactiveUIManager.HideData();
    }

    public void OnInteract(InputAction.CallbackContext context){
        if (context.performed)
        {
            Debug.Log("No se");
            if (interactiveData != null)
            {
                Debug.Log("No se");
                interactiveData.gameObject.GetComponent<InterfaceInteractiveObject>().Use();
            }else{
                Debug.Log("No interactive object detected");
            }
        }
    }

}
