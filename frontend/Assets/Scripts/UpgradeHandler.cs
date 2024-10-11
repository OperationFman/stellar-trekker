using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UpgradeHandler : MonoBehaviour
{
    private UIDocument _document;

    private List<Button> _menuButtons = new();
    
    private Label _foo;
    
    private int count = 2000;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();
        
        _foo = _document.rootVisualElement.Q<Label>("AlloyResourceCount");
        
        Debug.Log(_foo);

        _menuButtons = _document.rootVisualElement.Query<Button>().ToList();

        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].RegisterCallback<ClickEvent>(UpgradeResource);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].UnregisterCallback<ClickEvent>(UpgradeResource);
        }

    }


    private void UpgradeResource(ClickEvent evt)
    {
        count++;
        
        _foo.text = count.ToString();
        
        Debug.Log("You pressed the button");
    }
}
