using System;

using My.Unity.Patterns;

using TMPro;

using UnityEngine;
using UnityEngine.InputSystem;

namespace My.RPG.SimpleDialog
{
   public class DialogManagerOld : MonoBehaviourSingleton<DialogManagerOld>
   {
      [Header("Dialog")]
      [SerializeField] protected GameObject dialogPanel;
      [SerializeField] protected TextMeshProUGUI dialogText;

      [Header("Speaker")]
      [SerializeField] protected GameObject speakerPanel;
      [SerializeField] protected TextMeshProUGUI speakerText;

      protected IDialogContainer currentDialog = null;
      protected IMessage overrideMessage = null;

      [Min(0)] protected int msgIndex = 0;
      [Min(0)] protected int lineIndex = 0;

      public bool IsInputActive { get; private set; } = false;
      public bool IsOpen { get; private set; } = false;
      public override DialogManagerOld Singleton => Instance;

      public static DialogManagerOld Instance { get; private set; }

      protected void Awake ()
      {
         Instance = this;
         dialogPanel.SetActive(false);
      }

      protected void OnDestroy () // this will only get called if the entire UI is destroyed
      {
         Instance = null;
      }

      protected void OnSubmit (InputValue _)
      {
         if (IsInputActive)
         {
            if (!IsOpen)
            {
               Open();
            }
            else
            {
               Next();
            }
         }
      }


      #region public Methods

      public void SetDialog (IDialogContainer dialog)
      {
         IsInputActive = true;
         ClearIndices();

         currentDialog = dialog;
         overrideMessage = null;
      }

      public void SetMessage (IMessage message)
      {
         IsInputActive = true;
         ClearIndices();

         currentDialog = null;
         overrideMessage = message;
      }

      public void Open ()
      {
         if (IsInputActive || !IsOpen)
         {
            IsOpen = true;
            dialogPanel.SetActive(true);
            DisplayCurrent();
         }
      }

      public void Deactivate ()
      {
         IsInputActive = false;
         Close();
      }

      #endregion


      #region Next, Close

      private void Next ()
      {
         if (!MoveToNextLine())
         {
            if (!MoveNextMessage())
            {
               Close();
            }
         }
      }

      private void Close ()
      {
         ClearIndices();
         IsOpen = false;
         dialogPanel.SetActive(false);
      }

      private void ClearIndices ()
      {
         msgIndex = 0;
         lineIndex = 0;
      }

      #endregion


      #region Private Message Display Methods
      private bool MoveNextMessage ()
      {
         msgIndex++;
         lineIndex = 0;
         return DisplayCurrent();
      }

      private bool MoveToNextLine ()
      {
         lineIndex++;
         return DisplayCurrentLine();
      }

      private bool DisplayCurrent ()
      {
         DisplayCurrentSpeakerName();
         return DisplayCurrentLine();
      }

      private void DisplayCurrentSpeakerName ()
      {
         if (GetCurrentMessage() is IDialogMessage msg && !string.IsNullOrEmpty(msg.SpeakerName))
         {
            speakerPanel.SetActive(true);
            speakerText.text = msg.SpeakerName;
         }
         else
         {
            speakerText.text = "";
            speakerPanel.SetActive(false);
         }
      }

      private bool DisplayCurrentLine ()
      {
         var line = GetCurrentLine();
         if (line != null)
         {
            dialogText.text = line;
            return true;
         }
         else
         {
            dialogText.text = "";
            return false;
         }
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

      #endregion
   }
}
