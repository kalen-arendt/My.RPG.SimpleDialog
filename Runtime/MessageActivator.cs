using My.Unity.Debugging;

using UnityEngine;

namespace My.RPG.SimpleDialog
{
   public class MessageActivator : BaseDialogActivator
   {
      [Header("Message")]
      [SerializeField] protected Message message;


      private void Awake ()
      {
         message.WarnIfNull(this, $"{nameof(message)} is unassigned on {name}");
      }

      protected override void ActivateDialog ()
      {
         DialogManager.Instance.SetMessage(message);
      }
   }
}