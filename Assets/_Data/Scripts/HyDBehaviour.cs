using UnityEngine;

public class HyDBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
    }

    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void Start()
    {
        //For overide
    }

    protected virtual void LoadComponents()
    {
        //For overide
    }
}
