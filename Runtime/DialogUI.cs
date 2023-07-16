using System;

using TMPro;

using UnityEngine;

namespace My.RPG.SimpleDialog
{

   [Serializable]
   public class DialogUI : IDialogUI
   {
      [Header("Dialog")]
      [SerializeField] protected GameObject dialogPanel;
      [SerializeField] protected TextMeshProUGUI dialogText;

      [Header("Speaker")]
      [SerializeField] protected GameObject speakerPanel;
      [SerializeField] protected TextMeshProUGUI speakerText;

      public bool IsOpen { get; private set; } = false;

      public void Open ()
      {
         dialogPanel.SetActive(IsOpen = true);
      }

      public void Close ()
      {
         dialogPanel.SetActive(IsOpen = false);
      }

      public void ShowSpeakerName (string speakerName)
      {
         speakerText.text = speakerName;
         speakerPanel.SetActive(true);
      }

      public void HideSpeakerName ()
      {
         speakerPanel.SetActive(true);
         speakerText.text = "";
      }

      public void DisplaySpeakerName (IMessage message)
      {
         if (message is IDialogMessage dialog && !string.IsNullOrEmpty(dialog.SpeakerName))
         {
            speakerPanel.SetActive(true);
            speakerText.text = dialog.SpeakerName;
         }
         else
         {
            speakerText.text = "";
            speakerPanel.SetActive(false);
         }
      }

      public void DisplayMessageLine (string line)
      {
         dialogText.text = line ?? "";
      }
   }

   //public class DialogManager : MonoBehaviourSingleton<DialogManager>
   //{
   //   [Header("Dialog")]
   //   [SerializeField] protected GameObject dialogPanel;
   //   [SerializeField] protected TextMeshProUGUI dialogText;

   //   [Header("Speaker")]
   //   [SerializeField] protected GameObject speakerPanel;
   //   [SerializeField] protected TextMeshProUGUI speakerText;

   //   protected IDialogContainer currentDialog = null;
   //   protected IMessage overrideMessage = null;

   //   [Min(0)] protected int msgIndex = 0;
   //   [Min(0)] protected int lineIndex = 0;

   //   public bool IsInputActive { get; private set; } = false;
   //   public bool IsOpen { get; private set; } = false;
   //   public override DialogManager Singleton => Instance;

   //   public static DialogManager Instance { get; private set; }

   //   protected void Awake ()
   //   {
   //      Instance = this;
   //      dialogPanel.SetActive(false);
   //   }

   //   protected void OnDestroy () // this will only get called if the entire UI is destroyed
   //   {
   //      Instance = null;
   //   }

   //   protected void OnSubmit (InputValue value)
   //   {
   //      if (IsInputActive)
   //      {
   //         if (!IsOpen)
   //         {
   //            Open();
   //         }
   //         else
   //         {
   //            Next();
   //         }
   //      }
   //   }


   //   #region public Methods

   //   public void SetDialog (IDialogContainer dialog)
   //   {
   //      IsInputActive = true;
   //      ClearIndices();

   //      currentDialog = dialog;
   //      overrideMessage = null;
   //   }

   //   public void SetMessage (IMessage message)
   //   {
   //      IsInputActive = true;
   //      ClearIndices();

   //      currentDialog = null;
   //      overrideMessage = message;
   //   }

   //   public void Open ()
   //   {
   //      if (IsInputActive || !IsOpen)
   //      {
   //         IsOpen = true;
   //         dialogPanel.SetActive(true);
   //         DisplayCurrent();
   //      }
   //   }

   //   public void Deactivate ()
   //   {
   //      IsInputActive = false;
   //      Close();
   //   }

   //   #endregion


   //   #region Next, Close

   //   private void Next ()
   //   {
   //      if (!MoveToNextLine())
   //      {
   //         if (!MoveNextMessage())
   //         {
   //            Close();
   //         }
   //      }
   //   }

   //   private void Close ()
   //   {
   //      ClearIndices();
   //      IsOpen = false;
   //      dialogPanel.SetActive(false);
   //   }

   //   private void ClearIndices ()
   //   {
   //      msgIndex = 0;
   //      lineIndex = 0;
   //   }

   //   #endregion


   //   #region Private Message Display Methods
   //   private bool MoveNextMessage ()
   //   {
   //      msgIndex++;
   //      lineIndex = 0;
   //      return DisplayCurrent();
   //   }

   //   private bool MoveToNextLine ()
   //   {
   //      lineIndex++;
   //      return DisplayCurrentLine();
   //   }

   //   private bool DisplayCurrent ()
   //   {
   //      DisplayCurrentSpeakerName();
   //      return DisplayCurrentLine();
   //   }

   //   private void DisplayCurrentSpeakerName ()
   //   {
   //      if (GetCurrentMessage() is IDialogMessage msg && !string.IsNullOrEmpty(msg.SpeakerName))
   //      {
   //         speakerPanel.SetActive(true);
   //         speakerText.text = msg.SpeakerName;
   //      }
   //      else
   //      {
   //         speakerText.text = "";
   //         speakerPanel.SetActive(false);
   //      }
   //   }

   //   private bool DisplayCurrentLine ()
   //   {
   //      var line = GetCurrentLine();
   //      if (line != null)
   //      {
   //         dialogText.text = line;
   //         return true;
   //      }
   //      else
   //      {
   //         dialogText.text = "";
   //         return false;
   //      }
   //   }

   //   private string GetCurrentLine ()
   //   {
   //      IMessage msg = GetCurrentMessage();
   //      return msg != null && lineIndex < msg.Length
   //       ? msg[lineIndex]
   //       : null;
   //   }

   //   private IMessage GetCurrentMessage ()
   //   {
   //      return overrideMessage ?? (
   //         currentDialog != null && msgIndex < currentDialog.Length
   //            ? currentDialog[msgIndex]
   //            : null
   //      );
   //   }

   //   #endregion
   //}
}
