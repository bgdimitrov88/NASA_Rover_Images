using System.Threading.Tasks;

namespace NASA_Rover_Images.Views
{
    public interface IRoverInfoView
    {
        Task SetRover(string roverName);

        void ShowRoverInfo();

        void HideRoverInfo();
    }
}
