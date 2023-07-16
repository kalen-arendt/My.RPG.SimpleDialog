using UnityEngine;

namespace My.RPG.SimpleDialog
{
   /// <summary>
   /// a <see langword="string[]"/> of messages
   /// </summary>
   [System.Serializable]
   public class Message : IMessage
   {
      [TextArea(2, 4)]
      [SerializeField] private string[] messageLines;

      public int Length => messageLines.Length;
      public string this[int msgIndex] => messageLines[msgIndex];
      public string[] GetMessages ()
      {
         return messageLines;
      }
   }
}

