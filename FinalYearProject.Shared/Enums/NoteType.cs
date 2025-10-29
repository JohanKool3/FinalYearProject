namespace FinalYearProject.Shared.Enums
{
    /// <summary>
    /// Defines the Type of note that is being displayed
    /// </summary>
    public enum NoteType
    {
        /// <summary>
        /// Note that is Not Grouped with any other
        /// </summary>
        Separated,

        /// <summary>
        /// Note that is Grouped with others
        /// </summary>
        Grouped,

        /// <summary>
        /// A Rest from playing
        /// </summary>
        Rest,

        /// <summary>
        /// Defines a quick before note
        /// </summary>
        Grace
    }
}
