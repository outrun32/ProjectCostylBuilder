using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;



public class ButtonTimer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public int timeremain = 5; // tiempo restante
    Button _button;




    
    // Use this for initialization
    void Start () {

        _button = GetComponent<Button>();
   
    }

    void Update()
    { 
 
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        //do your stuff when highlighted
        NotificationCenter.DefaultCenter().PostNotification(this, "EnBoton");
        //print("en boton");
        InvokeRepeating("countDown", 1, 1);//llama al cursor
        

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //do your stuff when highlighted
        NotificationCenter.DefaultCenter().PostNotification(this, "EnNada");
        print("Cancela");
        CancelInvoke("countDown");
        timeremain = 5;
    }

    void countDown()
    {
       
        //print(timeremain);
        
        
        if (timeremain < 0)
        {

            NotificationCenter.DefaultCenter().PostNotification(this, "EnNada");
            _button.onClick.Invoke();
            //reset time
            CancelInvoke("countDown");
            timeremain = 5;
            print("reset time");
            
        }

        timeremain--;
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log(this.gameObject.name + " was selected");
    }





}
