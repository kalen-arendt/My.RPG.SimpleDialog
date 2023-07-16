namespace My.RPG.SimpleDialog
{
   public interface IDialogUI
   {
      bool IsOpen { get; }

      void Close ();
      void DisplayMessageLine (string line);
      void DisplaySpeakerName (IMessage message);
      void HideSpeakerName ();
      void Open ();
      void ShowSpeakerName (string speakerName);
   }
}