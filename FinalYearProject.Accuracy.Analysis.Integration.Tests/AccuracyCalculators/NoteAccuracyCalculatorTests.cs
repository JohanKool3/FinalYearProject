using FinalYearProject.Accuracy.Analysis.AccuracyCalculators;
using FinalYearProject.Accuracy.Analysis.Models;
using FinalYearProject.Audio.AudioAnalysis.FrequencyTimelineConstructors;
using FinalYearProject.Audio.AudioAnalysis.NoteTimelineConstructors;
using FinalYearProject.Audio.AudioAnalysis.Readers;
using FinalYearProject.Audio.AudioAnalysis.Windowers;
using FinalYearProject.Audio.Models;
using FinalYearProject.Audio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.Accuracy.Analysis.Integration.Tests.AccuracyCalculators
{
    public class NoteAccuracyCalculatorTests
    {
        [Fact]
        public void NoteAccuracyCalculator_CMajorSineScale_ReturnsExpectedAccuracy()
        {
            // Arrange
            #region Audio Analysis Pipeline Dependencies

            var tuningScheme = new TuningScheme()
            {
                A4 = 440.0
            };

            var settings = new DetectionSettings()
            {
                NoteDetectionThreshold = 0f,
                HopSize = 2048,
                WindowSize = 4096
            };


            var reader = new WavFileReader();
            var windower = new SimpleWindower();
            var frequencyConstructor = new SimpleFrequencyTimelineConstructor();
            var noteConstructor = new SimpleNoteTimelineConstructor(tuningScheme);

            #endregion

            #region Reference Tab Setup
            
            var referenceTab = new ReferenceTab()
            {
                Bpm = 120,
                NoteGroups = [new() {
                    StartTime = 0.0,
                    EndTime = 0.5,
                    Notes = [new(){
                        Name = "C5"
                    }]
                },
                new() {
                    StartTime = 0.5,
                    EndTime = 1,
                    Notes = [new(){
                        Name = "D5"
                    }]
                },
                new() {
                    StartTime = 1,
                    EndTime = 1.5,
                    Notes = [new(){
                        Name = "E5"
                    }]
                },
                new() {
                    StartTime = 1.5,
                    EndTime = 2,
                    Notes = [new(){
                        Name = "F5"
                    }]
                },
                new() {
                    StartTime = 2,
                    EndTime = 2.5,
                    Notes = [new(){
                        Name = "G5"
                    }]
                },
                new() {
                    StartTime = 2.5,
                    EndTime = 3,
                    Notes = [new(){
                        Name = "A5"
                    }]
                },
                new() {
                    StartTime = 3,
                    EndTime = 3.5,
                    Notes = [new(){
                        Name = "B5"
                    }]
                },
                new() {
                    StartTime = 3.5,
                    EndTime = 4,
                    Notes = [new(){
                        Name = "C6"
                    }]
                },
                ]
            };

            #endregion

            var pipeline = new AudioAnalysisPipelineService
                (reader,
                windower,
                frequencyConstructor,
                noteConstructor,
                tuningScheme,
                settings);

            var accuracySettings = new AccuracySettings()
            {
                RequiredNoteConfidence = 1f
            };

            var noteAccuracyCalculator = new NoteAccuracyCalculator(accuracySettings);


            // Act
            var noteTimeline = pipeline.AnalyzeAudioFile("TestData\\c-major-sine.wav");

            var accuracy = noteAccuracyCalculator.CalculateAccuracy(noteTimeline, referenceTab);

            // Assert
            Assert.NotNull(noteTimeline);
        }
    }
}
