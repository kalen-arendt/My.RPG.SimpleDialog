using UnityEngine;

namespace My.RPG.SimpleDialog
{
   /// <summary>
   /// <see cref="Message"/> Decorator - has a speakerName
   /// </summary>
   [System.Serializable]
   public class DialogMessage : IDialogMessage, IMessage
   {
      [SerializeField] private string speakerName;
      [SerializeField] private Message message;

      public string SpeakerName => speakerName;


      public string this[int i] => message[i];
      public int Length => message.Length;
      public string[] GetMessages ()
      {
         return message.GetMessages();
      }
   }
}

