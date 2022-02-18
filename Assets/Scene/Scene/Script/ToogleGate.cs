using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToogleGate : MonoBehaviour, IGate
{
    List<MyToggle> gateList = new List<MyToggle>();
    int toogleOn;

    public event UnityAction OnOpen;
    [SerializeField] SDReference _SdRef;
    [SerializeField] AudioClip _openGateSd;

    public void DoorState(bool state)
    {
        gameObject.SetActive(state);
    }
    #region OpenEVENT
    private void Start()
    {
        OnOpen += OpeningGate;
    }
    private void OnDestroy()
    {
        OnOpen -= OpeningGate;
    }
    #endregion

    public void AddToogleToList(MyToggle toggle)
    {
        gateList.Add(toggle);
        CheckList();
    }

    public void CheckList()
    {
        if (toogleOn >= gateList.Count) OnOpen.Invoke();
        else DoorState(true);
    }

    public void AddActiveToggle(bool active)
    {
        if (active) toogleOn++;
        else toogleOn--;
        CheckList();
    }

    private void OpeningGate()
    {
        DoorState(false);
        _SdRef.Instance.RandomSoundEffect(_openGateSd);
    }
}
