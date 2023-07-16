using My.Unity.Patterns;

using UnityEngine;

namespace My.RPG.SimpleDialog
{
   public class DialogManagerFactory : BaseUnityFactory<IDialogManager>
   {
      [SerializeField] DialogUI dialogUI;

      private static IDialogManager instance;

      public override IDialogManager Create ()
      {
         return instance ??= new DialogManagerNew(dialogUI);
      }
   }
}
