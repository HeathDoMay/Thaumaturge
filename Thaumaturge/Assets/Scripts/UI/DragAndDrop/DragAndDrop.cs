using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class DragAndDrop : EditorWindow
{
    [MenuItem("Window/UI Toolkit/DragAndDrop")]
    public static void ShowExample()
    {
        DragAndDrop wnd = GetWindow<DragAndDrop>();
        wnd.titleContent = new GUIContent("Drag And Drop");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI Toolkit/DragAndDrop/DragAndDrop.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/UI Toolkit/DragAndDrop/DragAndDrop.uss");

        DragAndDropManipulator manipulator = new(rootVisualElement.Q<VisualElement>("Object"));
    }
}