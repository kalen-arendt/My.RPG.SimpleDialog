namespace My.RPG.SimpleDialog
{
   public interface IDialogManager
   {
      bool IsInputActive { get; }

      void Deactivate ();
      void Open ();
      void SetDialog (IDialogContainer dialog);
      void SetMessage (IMessage message);
   }
}