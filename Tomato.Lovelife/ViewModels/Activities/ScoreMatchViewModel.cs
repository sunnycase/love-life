using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tomato.Lovelife.Primitives;
using Tomato.Uwp.Mvvm;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Tomato.Lovelife.ViewModels.Activities
{
    class ScoreMatchViewModel : BindableBase
    {
        public ScoreMatchActivity Activity { get; }

        private TimeSpan _restTime;
        public TimeSpan RestTime
        {
            get { return _restTime; }
            set { SetProperty(ref _restTime, value); }
        }

        private int _wastedLP;
        public int WastedLP
        {
            get { return _wastedLP; }
            set { SetProperty(ref _wastedLP, value); }
        }

        private DifficultyKind _difficulty;
        public DifficultyKind Difficulty
        {
            get { return _difficulty; }
            set { SetProperty(ref _difficulty, value); }
        }

        public RankKind[] AvailableRanks => Constants.Ranks;

        private RankKind _rank;
        public RankKind Rank
        {
            get { return _rank; }
            set { SetProperty(ref _rank, value); }
        }

        public PositionKind[] AvailablePositions => Constants.Positions;

        private PositionKind _position;
        public PositionKind Position
        {
            get { return _position; }
            set { SetProperty(ref _position, value); }
        }

        private int _goalpts;
        public int Goalpts
        {
            get { return _goalpts; }
            set { SetProperty(ref _goalpts, value); }
        }

        private int _nowpts;
        public int Nowpts
        {
            get { return _nowpts; }
            set { SetProperty(ref _nowpts, value); }
        }

        private int _nowLP;
        public int NowLP
        {
            get { return _nowLP; }
            set { SetProperty(ref _nowLP, value); }
        }

        private int _nowLevel;
        public int NowLevel
        {
            get { return _nowLevel; }
            set { SetProperty(ref _nowLevel, value); }
        }

        private int _nowExp;
        public int NowExp
        {
            get { return _nowExp; }
            set { SetProperty(ref _nowExp, value); }
        }

        private ScoreMatchActivityComputeResult _result;
        public ScoreMatchActivityComputeResult Result
        {
            get { return _result; }
            private set { SetProperty(ref _result, value); }
        }

        private readonly Guid _profileId;

        public ScoreMatchViewModel(ScoreMatchActivity activity, Guid profileId)
        {
            _profileId = profileId;
            Activity = activity;
            LoadInput();
        }

        public void Calculate()
        {
            SaveInput();
        }

        private async void SaveInput()
        {
            try
            {
                var file = await OpenInputFile();
                if (file != null)
                    await FileIO.WriteTextAsync(file, JsonConvert.SerializeObject(InputPersistModel.From(this)));
            }
            catch { }
        }

        private async void LoadInput()
        {
            try
            {
                var file = await OpenInputFile();
                if (file != null)
                {
                    var model = JsonConvert.DeserializeObject<InputPersistModel>(await FileIO.ReadTextAsync(file));
                    model.Populate(this);
                }
            }
            catch { }
        }

        private async Task<IStorageFile> OpenInputFile()
        {
            var directory = await (await ApplicationData.Current.RoamingFolder.CreateFolderAsync("Activity", CreationCollisionOption.OpenIfExists))
                .CreateFolderAsync("ScoreMatch", CreationCollisionOption.OpenIfExists);
            return (await directory.CreateFileAsync(_profileId.ToString("N") + ".input", CreationCollisionOption.OpenIfExists)) as StorageFile;
        }

        class InputPersistModel
        {
            public DateTime PersistTime { get; set; }
            public int WastedLP { get; set; }
            public DifficultyKind Difficulty { get; set; }
            public RankKind Rank { get; set; }
            public PositionKind Position { get; set; }
            public int Goalpts { get; set; }
            public int Nowpts { get; set; }
            public int NowLP { get; set; }
            public int NowLevel { get; set; }
            public int NowExp { get; set; }

            public static InputPersistModel From(ScoreMatchViewModel source)
            {
                return new InputPersistModel
                {
                    PersistTime = DateTime.UtcNow,
                    WastedLP = source.WastedLP,
                    Difficulty = source.Difficulty,
                    Rank = source.Rank,
                    Position = source.Position,
                    Goalpts = source.Goalpts,
                    Nowpts = source.Nowpts,
                    NowLP = source.NowLP,
                    NowLevel = source.NowLevel,
                    NowExp = source.NowExp
                };
            }

            public void Populate(ScoreMatchViewModel viewModel)
            {
                viewModel.WastedLP = WastedLP;
                viewModel.Difficulty = Difficulty;
                viewModel.Rank = Rank;
                viewModel.Position = Position;
                viewModel.Goalpts = Goalpts;
                viewModel.Nowpts = Nowpts;
                viewModel.NowLP = NowLP;
                viewModel.NowLevel = NowLevel;
                viewModel.NowExp = NowExp;
            }
        }
    }
}
