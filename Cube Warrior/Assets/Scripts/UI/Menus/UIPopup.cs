using UnityEngine;

namespace UI.Menus
{
    public abstract class UIPopup : MonoBehaviour
    {
        public virtual void Open()
        {
            if (gameObject.activeSelf)
            {
                return;
            }
            
            gameObject.SetActive(true);

            OnWindowOpened();
        }
        
        public void Close()
        {
            if (!gameObject.activeSelf)
            {
                return;
            }
            
            gameObject.SetActive(false);
        }

        protected abstract void OnWindowOpened();
    }
}