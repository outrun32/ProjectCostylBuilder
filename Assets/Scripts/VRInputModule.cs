using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;
public class VRInputModule : BaseInputModule
{
    public Camera camera;
    public SteamVR_Input_Sources targetSouce;
    public ISteamVR_Action_Boolean ClickAction;
    private GameObject currentObject = null;
    private PointerEventData Data = null;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        Data = new PointerEventData(eventSystem);
    }
    public override void Process()
    {
        Data.Reset();
        Data.position = new Vector2(camera.pixelWidth / 2, camera.pixelHeight / 2);
        eventSystem.RaycastAll(Data, m_RaycastResultCache);
        currentObject = Data.pointerCurrentRaycast.gameObject;
        m_RaycastResultCache.Clear();
        HandlePointerExitAndEnter(Data, currentObject);
        if (ClickAction.stateDown)
            ProcessPress(Data);
        if (ClickAction.stateUp)
            Processrelease(Data);
    
    }
    public PointerEventData GetData()
    {
        return Data;
    }
    private void ProcessPress(PointerEventData data)
    {
        data.pointerCurrentRaycast = data.pointerCurrentRaycast;
        GameObject newPointerPress = ExecuteEvents.ExecuteHierarchy(currentObject, data, ExecuteEvents.pointerDownHandler);
        if (newPointerPress == null)
            newPointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(currentObject);
        data.pressPosition = data.position;
        data.pointerPress = newPointerPress;
        data.rawPointerPress = currentObject;
    }
    private void Processrelease(PointerEventData data)
    {
        ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerUpHandler);
        GameObject pointerUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(currentObject);
        if (data.pointerPress == pointerUpHandler)
        {
            ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerUpHandler);
        }
        eventSystem.SetSelectedGameObject(null);
        data.pressPosition = Vector2.zero;
        data.pointerPress = null;
        data.rawPointerPress = null;
    }
}
