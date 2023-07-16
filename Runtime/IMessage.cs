namespace My.RPG.SimpleDialog
{
   /// <summary>
   /// <list type="table">
   ///	<item>
   ///		<term><see cref="Length"/></term>
   ///		<description>returns the number of lines of text</description>
   ///	</item>
   ///	<item>
   ///		<term><see cref="this[int]"/></term>
   ///		<description>indexer for messages</description>
   ///	</item>
   /// 	<item>
   ///		<term><see cref="GetMessages"/></term>
   ///		<description>returns an array of string messages</description>
   ///	</item>
   /// </list>
   /// </summary>
   public interface IMessage
   {
      /// <summary>
      /// the number of lines of text
      /// </summary>
      public int Length { get; }

      /// <summary>
      /// the message at element <paramref name="msgIndex"/>
      /// </summary>
      /// <param name="msgIndex"></param>
      /// <returns></returns>
      public string this[int msgIndex] { get; }

      /// <summary>
      /// Gets the <see langword="string[]"/> of messages.
      /// </summary>
      /// <returns>The array of string messages</returns>
      public string[] GetMessages ();
   }
}

