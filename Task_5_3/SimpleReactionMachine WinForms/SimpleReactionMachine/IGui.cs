namespace SimpleReactionMachine
{
    public interface IGui
    {
        //Connect gui to controller
        //(This method will be called before any other methods)
        void Connect(IController controller);

        //Initialise the gui
        void Init();

        //Called to change the displayed text
        void SetDisplay(string s);
    }
}
