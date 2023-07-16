namespace My.RPG.SimpleDialog
{
   public interface IDialogContainer
   {
      int Length { get; }
      IDialogMessage this[int dialogIndex] { get; }
      IDialogMessage[] GetDialog ();
   }
}
