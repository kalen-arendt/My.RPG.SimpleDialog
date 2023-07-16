using System.Collections.Generic;

using UnityEngine;


namespace My.RPG.SimpleDialog
{
   [System.Serializable]
   public class DialogContainer : IDialogContainer
   {
      [SerializeField] private List<DialogMessage> dialog;

      public int Length => dialog.Count;
      public IDialogMessage this[int dialogIndex] => dialog[dialogIndex];
      public IDialogMessage[] GetDialog ()
      {
         return dialog.ToArray();
      }
   }
}
