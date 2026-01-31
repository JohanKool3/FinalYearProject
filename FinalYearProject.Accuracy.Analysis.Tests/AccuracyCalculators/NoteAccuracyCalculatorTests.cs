using FinalYearProject.Accuracy.Analysis.Services;
using FinalYearProject.Accuracy.Analysis.Models;
using FinalYearProject.Audio.Models;
using FinalYearProject.Shared.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.Accuracy.Analysis.Tests.AccuracyCalculators
{
    public class NoteAccuracyCalculatorTests
    {
        [Fact]
        public void NoteAccuracyCalculator_CalculateAccuracy_Returns1()
        {
            // Arrange
            var tuningScheme = new TuningScheme
            {
                A4 = 440.0
            };

            var calculator = new NoteAccuracyCalculatorService(
                new AccuracySettings
                {
                    RequiredNoteConfidence = 0.1f
                });

            var timeline = new NoteTimeline
            {
                Length = 10.0f,
                DataPointLength = 1.0,
                NoteSlices =
                [
                    new(0, tuningScheme)
                    {
                        NoteConfidences =
                        [
                            new() { Name = "E4", Confidence = 0.8f, FundamentalFrequencyBounds = new(0, 0) }
                        ]
                    }
                ]
            };

            var expectedTab = new ReferenceTabDto
            {
                NoteGroups =
                [
                    new(){
                        StartTime = 0.0f,
                        EndTime = 1.0f,
                        Notes = [new() { Name = "E4" }]
                    }
                ]
            };

            // Act
            var accuracy = calculator.CalculateAccuracy(timeline, expectedTab);

            // Assert
            Assert.Equal(1.0f, accuracy);
        }

        [Fact]
        public void NoteAccuracyCalculator_CalculateAccuracy_Returns0()
        {
            // Arrange
            var tuningScheme = new TuningScheme
            {
                A4 = 440.0
            };
            var calculator = new NoteAccuracyCalculatorService(
                new AccuracySettings
                {
                    RequiredNoteConfidence = 0.1f
                });
            var timeline = new NoteTimeline
            {
                Length = 10.0f,
                DataPointLength = 1.0,
                NoteSlices =
                [
                    new(0, tuningScheme)
                    {
                        NoteConfidences =
                        [
                            new() { Name = "E4", Confidence = 0.8f, FundamentalFrequencyBounds = new(0, 0) }
                        ]
                    }
                ]
            };
            var expectedTab = new ReferenceTabDto
            {
                NoteGroups =
                [
                    new(){
                        StartTime = 0.0f,
                        EndTime = 1.0f,
                        Notes = [new() { Name = "F4" }]
                    }
                ]
            };
            // Act
            var accuracy = calculator.CalculateAccuracy(timeline, expectedTab);
            // Assert
            Assert.Equal(0.0f, accuracy);
        }

        [Fact]
        public void NoteAccuracyCalculator_CalculateAccuracy_ReturnsPoint5()
        {
            // Arrange
            var tuningScheme = new TuningScheme
            {
                A4 = 440.0
            };
            var calculator = new NoteAccuracyCalculatorService(
                new AccuracySettings
                {
                    RequiredNoteConfidence = 0.1f
                });
            var timeline = new NoteTimeline
            {
                Length = 10.0f,
                DataPointLength = 1.0,
                NoteSlices =
                [
                    new(0, tuningScheme)
                    {
                        NoteConfidences =
                        [
                            new() { Name = "E4", Confidence = 0.8f, FundamentalFrequencyBounds = new(0, 0), },
                            new() { Name = "F4", Confidence = 0.8f, FundamentalFrequencyBounds = new(0, 0), },
                            new() { Name = "G4", Confidence = 0.8f, FundamentalFrequencyBounds = new(0, 0), }
                        ]
                    }
                ]
            };
            var expectedTab = new ReferenceTabDto
            {
                NoteGroups =
                [
                    new(){
                        StartTime = 0.0f,
                        EndTime = 1.0f,
                        Notes = [new() { Name = "E4" },
                                 new() { Name = "F4" },]
                    }
                ]
            };
            // Act
            var accuracy = calculator.CalculateAccuracy(timeline, expectedTab);
            // Assert
            Assert.Equal(0.5f, accuracy);
        }
    }
}
