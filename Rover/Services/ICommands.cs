namespace Rover.Services
{
    public interface ICommands
    {
        public int Execute(char[] commands);
        public void Init(int x0, int y0, char dir0, int x_max, int y_max);
    }
}