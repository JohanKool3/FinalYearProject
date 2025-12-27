using FinalYearProject.Audio.Services;

namespace FinalYearProject.UI.Components.Pages
{
    public partial class AudioView(FileAudioService audioService)
    {
        public FileAudioService AudioService { get; } = audioService;


        protected override void OnInitialized()
        {
            AudioService.Load("eminor-test.wav", "AudioFiles");
            base.OnInitialized();
            StateHasChanged();
        }
    }
}