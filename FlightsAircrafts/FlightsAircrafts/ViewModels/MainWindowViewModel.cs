using Avalonia;
using FlightsAircrafts.Models;
using System;
using System.Collections.Generic;
using static Avalonia.Media.Transformation.TransformOperation;
using System.Collections.ObjectModel;
using System.Linq;
using ReactiveUI;
using Avalonia.Interactivity;
using System.Windows.Input;
using Avalonia.Threading;
using System.Reactive;


namespace FlightsAircrafts.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            SourceAirport1 = airports["Voronezh"].Name;
            SourceAirport2 = airports["Moscow"].Name;
            SourceAirport3 = airports["Stambul"].Name;
            SourceAirport4 = airports["London"].Name;
            SourceAirport5 = airports["Sochi"].Name;
        }

        //public void Reset(string param)
        //{
        //    foreach (var aircraft in aircrafts)
        //    {
        //        aircraft.CurrentDetoriationLevel = AircraftConsts.DetoriationLevel.MEDIUM;
        //        aircraft.Error = AircraftConsts.ErrorCause.None;
        //    }
        //}
        public void BtnGo1(string param)
        {
            var result = aircrafts[0].Takeoff(airports[SourceAirport1]);
            this.RaisePropertyChanged(nameof(IsAircraftReady1));
            if (result)
            {
                aircrafts[0].HeightChanged += HeightChangedListener1;
                //    //Dispatcher.UIThread.Post(async () => await aircrafts[0].Flight(), DispatcherPriority.Background);
                aircrafts[0].Flight();
            }
            else
            {
                this.RaisePropertyChanged(nameof(Status1));
            }
        }

        public void BtnGo2(string param)
        {
            var result = aircrafts[1].Takeoff(airports[SourceAirport2]);
            this.RaisePropertyChanged(nameof(IsAircraftReady2));
            if (result)
            {
                aircrafts[1].HeightChanged += HeightChangedListener2;
                //    //Dispatcher.UIThread.Post(async () => await aircrafts[0].Flight(), DispatcherPriority.Background);
                aircrafts[1].Flight();
            }
            else
            {
                this.RaisePropertyChanged(nameof(Status2));
            }
        }
        public void BtnGo3(string param)
        {
            var result = aircrafts[2].Takeoff(airports[SourceAirport3]);
            this.RaisePropertyChanged(nameof(IsAircraftReady3));
            if (result)
            {
                aircrafts[2].HeightChanged += HeightChangedListener3;
                //    //Dispatcher.UIThread.Post(async () => await aircrafts[0].Flight(), DispatcherPriority.Background);
                aircrafts[2].Flight();
            }
            else
            {
                this.RaisePropertyChanged(nameof(Status3));
            }
        }

        public void BtnGo4(string param)
        {
            var result = aircrafts[3].Takeoff(airports[SourceAirport4]);
            this.RaisePropertyChanged(nameof(IsAircraftReady4));
            if (result)
            {
                aircrafts[3].HeightChanged += HeightChangedListener4;
                //    //Dispatcher.UIThread.Post(async () => await aircrafts[0].Flight(), DispatcherPriority.Background);
                aircrafts[3].Flight();
            }
            else
            {
                this.RaisePropertyChanged(nameof(Status4));
            }
        }

        public void BtnGo5(string param)
        {
            var result = aircrafts[4].Takeoff(airports[SourceAirport5]);
            this.RaisePropertyChanged(nameof(IsAircraftReady5));
            if (result)
            {
                aircrafts[4].HeightChanged += HeightChangedListener5;
                //    //Dispatcher.UIThread.Post(async () => await aircrafts[0].Flight(), DispatcherPriority.Background);
                aircrafts[4].Flight();
            }
            else
            {
                this.RaisePropertyChanged(nameof(Status5));
            }
        }

        private List<AbstractAircraft> aircrafts = [
            new Airplane("Airbus 320", AircraftConsts.DetoriationLevel.LOW, 10000, 500, 100, 80, 10),
            new Airplane("Boing 737", AircraftConsts.DetoriationLevel.LOW, 11000, 700, 120, 90, 10),
            new Airplane("AN 2", AircraftConsts.DetoriationLevel.HIGH, 2000, 300, 150, 80, 10),
            new Helicopter("Mi 8", AircraftConsts.DetoriationLevel.LOW, 4000, 400, 10),
            new Helicopter("Apache", AircraftConsts.DetoriationLevel.LOW, 5000, 600, 10),
            ];
        private Dictionary<string, Airport> airports = new()
        {
            { "Voronezh", new Airport("Voronezh", 90) },
            { "Moscow", new Airport("Moscow", 120) },
            { "Sochi", new Airport("Sochi", 150) },
            { "Stambul", new Airport("Stambul", 150) },
            { "New York", new Airport("New York", 150) },
            { "London", new Airport("London", 150) },
        };
        public string Aircraft1 => aircrafts[0].Name;
        public string Aircraft2 => aircrafts[1].Name;
        public string Aircraft3 => aircrafts[2].Name;
        public string Aircraft4 => aircrafts[3].Name;
        public string Aircraft5 => aircrafts[4].Name;
        public string SourceAirport1 { get; set; }
        public string SourceAirport2 { get; set; }
        public string SourceAirport3 { get; set; }
        public string SourceAirport4 { get; set; }
        public string SourceAirport5 { get; set; }
        public string CurrentHeight1 => aircrafts[0].CurrentHeight.ToString();
        public string CurrentHeight2 => aircrafts[1].CurrentHeight.ToString();
        public string CurrentHeight3 => aircrafts[2].CurrentHeight.ToString();
        public string CurrentHeight4 => aircrafts[3].CurrentHeight.ToString();
        public string CurrentHeight5 => aircrafts[4].CurrentHeight.ToString();
        public List<string> DestinationAirport1 => airports.Select(kv => kv.Value.Name).ToList();
        public List<string> DestinationAirport2 => airports.Select(kv => kv.Value.Name).ToList();
        public List<string> DestinationAirport3 => airports.Select(kv => kv.Value.Name).ToList();
        public List<string> DestinationAirport4 => airports.Select(kv => kv.Value.Name).ToList();
        public List<string> DestinationAirport5 => airports.Select(kv => kv.Value.Name).ToList();
        public string SelectedAirport1 { get; set; } = "Moscow";
        public string SelectedAirport2 { get; set; } = "Sochi";
        public string SelectedAirport3 { get; set; } = "London";
        public string SelectedAirport4 { get; set; } = "Voronezh";
        public string SelectedAirport5 { get; set; } = "New York";

        public bool IsAircraftReady1 {
            get
            {
                return aircrafts[0].CurrentHeight == 0 && aircrafts[0].FlightDirection == AircraftConsts.Direction.None
                    && aircrafts[0].Error == AircraftConsts.ErrorCause.None;

            }
        }

        public bool IsAircraftReady2
        {
            get
            {
                return aircrafts[1].CurrentHeight == 0 && aircrafts[1].FlightDirection == AircraftConsts.Direction.None
                    && aircrafts[1].Error == AircraftConsts.ErrorCause.None;

            }
        }

        public bool IsAircraftReady3
        {
            get
            {
                return aircrafts[2].CurrentHeight == 0 && aircrafts[2].FlightDirection == AircraftConsts.Direction.None
                    && aircrafts[2].Error == AircraftConsts.ErrorCause.None;

            }
        }

        public bool IsAircraftReady4
        {
            get
            {
                return aircrafts[3].CurrentHeight == 0 && aircrafts[3].FlightDirection == AircraftConsts.Direction.None
                    && aircrafts[3].Error == AircraftConsts.ErrorCause.None;

            }
        }

        public bool IsAircraftReady5
        {
            get
            {
                return aircrafts[4].CurrentHeight == 0 && aircrafts[4].FlightDirection == AircraftConsts.Direction.None
                    && aircrafts[4].Error == AircraftConsts.ErrorCause.None;

            }
        }

        public string Status1
        {
            get
            {
                return aircrafts[0].Error switch 
                { 
                    AircraftConsts.ErrorCause.NotEnoughLandingLen => "Too short landing. Crash",
                    AircraftConsts.ErrorCause.NotEnoughTakeoffLen => "Too short runway.",
                    AircraftConsts.ErrorCause.Detoriation => "Too wearied off",
                    _ => "Ready",

                };
            }
        }

        public string Status2
        {
            get
            {
                return aircrafts[1].Error switch
                {
                    AircraftConsts.ErrorCause.NotEnoughLandingLen => "Too short landing. Crash",
                    AircraftConsts.ErrorCause.NotEnoughTakeoffLen => "Too short runway.",
                    AircraftConsts.ErrorCause.Detoriation => "Too wearied off",
                    _ => "Ready",

                };
            }
        }

        public string Status3
        {
            get
            {
                return aircrafts[2].Error switch
                {
                    AircraftConsts.ErrorCause.NotEnoughLandingLen => "Too short landing. Crash",
                    AircraftConsts.ErrorCause.NotEnoughTakeoffLen => "Too short runway.",
                    AircraftConsts.ErrorCause.Detoriation => "Too wearied off",
                    _ => "Ready",

                };
            }
        }

        public string Status4
        {
            get
            {
                return aircrafts[3].Error switch
                {
                    AircraftConsts.ErrorCause.NotEnoughLandingLen => "Too short landing. Crash",
                    AircraftConsts.ErrorCause.NotEnoughTakeoffLen => "Too short runway.",
                    AircraftConsts.ErrorCause.Detoriation => "Too wearied off",
                    _ => "Ready",

                };
            }
        }

        public string Status5
        {
            get
            {
                return aircrafts[4].Error switch
                {
                    AircraftConsts.ErrorCause.NotEnoughLandingLen => "Too short landing. Crash",
                    AircraftConsts.ErrorCause.NotEnoughTakeoffLen => "Too short runway.",
                    AircraftConsts.ErrorCause.Detoriation => "Too wearied off",
                    _ => "Ready",

                };
            }
        }


        public void HeightChangedListener1(object? sender, double args)
        {
            this.RaisePropertyChanged(nameof(CurrentHeight1));
            var ac = sender as AbstractAircraft;
            if (ac.FlightDirection == AircraftConsts.Direction.None)
            {
                var result = ac.Land(airports[SelectedAirport1]);
                if (result)
                {
                    SourceAirport1 = SelectedAirport1;
                    this.RaisePropertyChanged(nameof(SourceAirport1));
                    this.RaisePropertyChanged(nameof(IsAircraftReady1));
                }
                else 
                {
                    this.RaisePropertyChanged(nameof(Status1));
                }
                
            }
        }

        public void HeightChangedListener2(object? sender, double args)
        {
            this.RaisePropertyChanged(nameof(CurrentHeight2));
            var ac = sender as AbstractAircraft;
            if (ac.FlightDirection == AircraftConsts.Direction.None)
            {
                var result = ac.Land(airports[SelectedAirport2]);
                if (result)
                {
                    SourceAirport2 = SelectedAirport2;
                    this.RaisePropertyChanged(nameof(SourceAirport2));
                    this.RaisePropertyChanged(nameof(IsAircraftReady2));
                }
                else
                {
                    this.RaisePropertyChanged(nameof(Status2));
                }

            }
        }

        public void HeightChangedListener3(object? sender, double args)
        {
            this.RaisePropertyChanged(nameof(CurrentHeight3));
            var ac = sender as AbstractAircraft;
            if (ac.FlightDirection == AircraftConsts.Direction.None)
            {
                var result = ac.Land(airports[SelectedAirport3]);
                if (result)
                {
                    SourceAirport3 = SelectedAirport3;
                    this.RaisePropertyChanged(nameof(SourceAirport3));
                    this.RaisePropertyChanged(nameof(IsAircraftReady3));
                }
                else
                {
                    this.RaisePropertyChanged(nameof(Status3));
                }

            }
        }

        public void HeightChangedListener4(object? sender, double args)
        {
            this.RaisePropertyChanged(nameof(CurrentHeight4));
            var ac = sender as AbstractAircraft;
            if (ac.FlightDirection == AircraftConsts.Direction.None)
            {
                var result = ac.Land(airports[SelectedAirport4]);
                if (result)
                {
                    SourceAirport4 = SelectedAirport4;
                    this.RaisePropertyChanged(nameof(SourceAirport4));
                    this.RaisePropertyChanged(nameof(IsAircraftReady4));
                }
                else
                {
                    this.RaisePropertyChanged(nameof(Status4));
                }

            }
        }

        public void HeightChangedListener5(object? sender, double args)
        {
            this.RaisePropertyChanged(nameof(CurrentHeight5));
            var ac = sender as AbstractAircraft;
            if (ac.FlightDirection == AircraftConsts.Direction.None)
            {
                var result = ac.Land(airports[SelectedAirport5]);
                if (result)
                {
                    SourceAirport5 = SelectedAirport5;
                    this.RaisePropertyChanged(nameof(SourceAirport5));
                    this.RaisePropertyChanged(nameof(IsAircraftReady5));
                }
                else
                {
                    this.RaisePropertyChanged(nameof(Status5));
                }

            }
        }

    }
}
