using NaixxGithub.NINA.Fasterflats.Properties;
using Newtonsoft.Json;
using NINA.Core.Model;
using NINA.Core.Utility.Notification;
using NINA.Equipment.Interfaces.ViewModel;
using NINA.Profile.Interfaces;
using NINA.Sequencer.SequenceItem;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace NaixxGithub.NINA.Fasterflats.FasterflatsTestCategory {
    /// <summary>
    /// This Class shows the basic principle on how to add a new Sequence Instruction to the N.I.N.A. sequencer via the plugin interface
    /// For ease of use this class inherits the abstract SequenceItem which already handles most of the running logic, like logging, exception handling etc.
    /// A complete custom implementation by just implementing ISequenceItem is possible too
    /// The following MetaData can be set to drive the initial values
    /// --> Name - The name that will be displayed for the item
    /// --> Description - a brief summary of what the item is doing. It will be displayed as a tooltip on mouseover in the application
    /// --> Icon - a string to the key value of a Geometry inside N.I.N.A.'s geometry resources
    ///
    /// If the item has some preconditions that should be validated, it shall also extend the IValidatable interface and add the validation logic accordingly.
    /// </summary>
    [ExportMetadata("Name", "FasterFlats")]
    [ExportMetadata("Description",
        "On low-end mini PCs, continuously capturing flats every second can heavily load the CPU, especially when stretching and annotating are enabled. In such cases, you can add two instructions to your sequence to temporarily disable auto-stretch and annotation. It works for non light captures only.")]
    [ExportMetadata("Icon", "Plugin_Histogram_SVG")]
    [ExportMetadata("Category", "Lbl_SequenceCategory_FlatDevice")]
    [Export(typeof(ISequenceItem))]
    [JsonObject(MemberSerialization.OptIn)]
    public class FasterflatsInstruction : SequenceItem {
        private IProfileService profileService;
        private IImageControlVM imageControlVm;

        /// <summary>
        /// The constructor marked with [ImportingConstructor] will be used to import and construct the object
        /// General device interfaces can be added to the constructor parameters and will be automatically injected on instantiation by the plugin loader
        /// </summary>
        /// <remarks>
        /// Available interfaces to be injected:
        ///     - IProfileService,
        ///     - ICameraMediator,
        ///     - ITelescopeMediator,
        ///     - IFocuserMediator,
        ///     - IFilterWheelMediator,
        ///     - IGuiderMediator,
        ///     - IRotatorMediator,
        ///     - IFlatDeviceMediator,
        ///     - IWeatherDataMediator,
        ///     - IImagingMediator,
        ///     - IApplicationStatusMediator,
        ///     - INighttimeCalculator,
        ///     - IPlanetariumFactory,
        ///     - IImageHistoryVM,
        ///     - IDeepSkyObjectSearchVM,
        ///     - IDomeMediator,
        ///     - IImageSaveMediator,
        ///     - ISwitchMediator,
        ///     - ISafetyMonitorMediator,
        ///     - IApplicationMediator
        ///     - IApplicationResourceDictionary
        ///     - IFramingAssistantVM
        ///     - IList<IDateTimeProvider>
        /// </remarks>
        [ImportingConstructor]
        public FasterflatsInstruction(IProfileService profileService, IImageControlVM imageControlVm) {
            this.profileService = profileService;
            this.imageControlVm = imageControlVm;
        }

        public FasterflatsInstruction(FasterflatsInstruction copyMe) : this(copyMe.profileService, copyMe.imageControlVm) {
            CopyMetaData(copyMe);
        }

        private bool? _annotateImage;

        [JsonProperty]
        public bool? AnnotateImage {
            get => _annotateImage;
            set {
                _annotateImage = value;
                OnPropertyChanged(); 
            }
        }

        private bool? autoStretch;

        [JsonProperty]
        public bool? AutoStretch {
            get => autoStretch;
            set {
                autoStretch = value;
                if (value == false)
                    DetectStars = false;
                OnPropertyChanged(); 
            }
        }

        private bool? detectStars;

        [JsonProperty]
        public bool? DetectStars {
            get => detectStars;
            set {
                detectStars = value;
                if (value == true)
                    AutoStretch = true;
                OnPropertyChanged(); 
            }
        }

        /// <summary>
        /// The core logic when the sequence item is running resides here
        /// Add whatever action is necessary
        /// </summary>
        /// <param name="progress">The application status progress that can be sent back during execution</param>
        /// <param name="token">When a cancel signal is triggered from outside, this token can be used to register to it or check if it is cancelled</param>
        /// <returns></returns>
        public override Task Execute(IProgress<ApplicationStatus> progress, CancellationToken token) {
            IImageSettings imageSettings = profileService.ActiveProfile.ImageSettings;

            imageSettings.AnnotateImage = AnnotateImage ?? imageSettings.AnnotateImage;
            imageControlVm.AutoStretch = AutoStretch ?? imageControlVm.AutoStretch;
            imageControlVm.DetectStars = DetectStars ?? imageControlVm.DetectStars;

            // Add logic to run the item here
            return Task.CompletedTask;
        }

        /// <summary>
        /// When items are put into the sequence via the factory, the factory will call the clone method. Make sure all the relevant fields are cloned with the object.
        /// </summary>
        /// <returns></returns>
        public override object Clone() {
            return new FasterflatsInstruction(this);
        }

        /// <summary>
        /// This string will be used for logging
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return $"Category: {Category}, Item: {nameof(FasterflatsInstruction)}";
        }
    }
}