using My.Core.Extentions.Strings;
using My.Unity.Extensions;

using UnityEngine;

namespace My.RPG.SimpleDialog
{
   [RequireComponent(typeof(Collider2D))]
   public abstract class BaseDialogActivator : MonoBehaviour
   {
      [Header("Interaction")]
      [SerializeField] private string activationTag = "";
      [SerializeField] private bool autoActivate = true;
      [SerializeField] private GameObject actionIcon = null;

      public const string DEFAULT_ACTIVATION_TAG = "Player";

      public string ActivationTag => activationTag.CoalesceEmpty(DEFAULT_ACTIVATION_TAG);

      private void Start ()
      {
         SetIconActive(false);
      }

      protected abstract void ActivateDialog ();

      private void OnTriggerEnter2D (Collider2D other)
      {
         if (other.CompareTag(ActivationTag))
         {
            SetIconActive(true);
            ActivateDialog();

            if (autoActivate)
            {
               DialogManager.Instance.Open();
            }
         }
      }

      private void OnTriggerExit2D (Collider2D other)
      {
         if (other.CompareTag(ActivationTag))
         {
            SetIconActive(false);


            if(DialogManager.Instance != null)
            {
               DialogManager.Instance.Deactivate();
            }
            else
            {
               Debug.LogError("DialogManager.Instance is null.");
            }
         }
      }

      protected void SetIconActive (bool active)
      {
         actionIcon.IfNotNull(x => x.SetActive(active));
      }
   }
}