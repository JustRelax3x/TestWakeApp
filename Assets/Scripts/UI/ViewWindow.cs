using UnityEngine;

public abstract class ViewWindow : MonoBehaviour
{
    [SerializeField]
    protected GameObject _root;

    public virtual void Open()
    {
        _root.SetActive(true);
    }

    public virtual void Close()
    {
        _root.SetActive(false);
    }
}