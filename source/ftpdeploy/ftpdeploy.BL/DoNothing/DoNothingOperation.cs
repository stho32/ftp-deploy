using ftpdeploy.BL.Interfaces;

namespace ftpdeploy.BL.DoNothing;

///<summary>
/// in case of wrong parameters
///</summary>
public class DoNothingOperation : IOperation
{
    public void Execute()
    {
    }
}

