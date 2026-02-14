using FinalYearProject.Services.Interfaces;
using FinalYearProject.UI.Components.Interfaces;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components.Web;

namespace FinalYearProject.UI.Components.InterfaceElements.RecordingToolbar
{
    public partial class RecordWidget(
        IAudioRecordingService audioRecordingService,
        IUserDataStorage dataStorage,
        DisplayService displayService)
    {
        public IAudioRecordingService AudioRecordingService { get; } = audioRecordingService;
        public IUserDataStorage DataStorage { get; } = dataStorage;
        public DisplayService DisplayService { get; } = displayService;




        private void StartRecording(MouseEventArgs args)
        {
            var id = DisplayService.CurrentPieceId;

            var filePath = DataStorage.CreateRecordingPath(id, DateTime.Now);

            AudioRecordingService.StartRecording(filePath);
        }

        private void HandleClick(MouseEventArgs args)
        {
            if (DisplayService.IsRecording)
            {
                AudioRecordingService.StopRecording();
                Console.WriteLine("");
            }
            else
            {
                StartRecording(args);
            }

            DisplayService.IsRecording = !DisplayService.IsRecording;
        }
    }
}