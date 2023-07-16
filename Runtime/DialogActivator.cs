using My.Unity.Debugging;

using UnityEngine;

namespace My.RPG.SimpleDialog
{
   public class DialogActivator : BaseDialogActivator
   {
      [Header("Dialog")]
      [SerializeField] private DialogSO dialogSO;


      private void Awake ()
      {
         dialogSO.WarnIfNull(this, $"{nameof(dialogSO)} is unassigned on {name}");
      }

      protected override void ActivateDialog ()
      {
         DialogManager.Instance.SetDialog(dialogSO);
      }
   }
}