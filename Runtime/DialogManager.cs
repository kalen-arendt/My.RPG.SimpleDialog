using My.Core.Patterns;

using UnityEngine;
using UnityEngine.InputSystem;

namespace My.RPG.SimpleDialog
{
   public class DialogManager : MonoBehaviour, IDialogManager, ISingleton<DialogManager, IDialogManager>
   {
      [SerializeField] private DialogUI dialogUI;

      protected IDialogContainer currentDialog = null;
      protected IMessage overrideMessage = null;

      [Min(0)] protected int msgIndex = 0;
      [Min(0)] protected int lineIndex = 0;

      public bool IsInputActive { get; private set; } = false;
      public IDialogManager Singleton => Instance;

      public static IDialogManager Instance { get; private set; }

      protected void Awake ()
      {
         if (Instance == null)
         {
            Instance = this;
            dialogUI.Close();
         }
      }

      protected void OnDestroy () // this will only get called if the entire UI is destroyed
      {
         if (this == Instance)
         {
            Instance = null;
         }
      }

      protected void OnSubmit (InputValue value)
      {
         if (IsInputActive)
         {
            if (!dialogUI.IsOpen)
            {
               Open();
            }
            else
            {
               Next();
            }
         }
      }

      public void SetDialog (IDialogContainer dialog)
      {
         IsInputActive = true;
         ClearMetaData();

         currentDialog = dialog;
         overrideMessage = null;
      }

      public void SetMessage (IMessage message)
      {
         IsInputActive = true;
         ClearMetaData();

         currentDialog = null;
         overrideMessage = message;
      }

      public void Open ()
      {
         if (IsInputActive || !dialogUI.IsOpen)
         {
            dialogUI.Open();
            dialogUI.DisplaySpeakerName(GetCurrentMessage());
            dialogUI.DisplayMessageLine(GetCurrentLine());
         }
      }

      public void Deactivate ()
      {
         IsInputActive = false;
         Close();
      }

      private void Next ()
      {
         lineIndex++;
         string line = GetCurrentLine();

         if (line != null)
         {
            dialogUI.DisplayMessageLine(line);
         }
         else
         {
            msgIndex++;
            lineIndex = 0;

            MoveNextMessage();
         }
      }

      private void MoveNextMessage ()
      {
         string line = GetCurrentLine();
         if (line != null)
         {
            dialogUI.DisplaySpeakerName(GetCurrentMessage());
            dialogUI.DisplayMessageLine(line);
         }
         else
         {
            Close();
         }
      }

      private void Close ()
      {
         ClearMetaData();
         dialogUI.Close();
      }

      private void ClearMetaData ()
      {
         msgIndex = 0;
         lineIndex = 0;
      }

      private string GetCurrentLine ()
      {
         IMessage msg = GetCurrentMessage();
         return msg != null && lineIndex < msg.Length
          ? msg[lineIndex]
          : null;
      }

      private IMessage GetCurrentMessage ()
      {
         return overrideMessage ?? (
            currentDialog != null && msgIndex < currentDialog.Length
               ? currentDialog[msgIndex]
               : null
         );
      }
   }
}
