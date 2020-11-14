using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AutoMapper;
using BoardGameDesigner.Model.Components;
using BoardGameDesigner.Model.Events;
using BoardGameDesigner.Model.Events.CardEvents;
using BoardGameDesigner.ViewModel.Commands;
using BoardGameDesigner.ViewModel.Commands.ProjectMetadata;
using BoardGameDesigner.ViewModel.DataSources;
using BoardGameDesigner.ViewModel.ProjectManagement;

namespace BoardGameDesigner.ViewModel
{
    public class GameDetailsViewModel : BaseViewModel
    {
        public ILoadProjectCommand LoadProjectCommand { get; set; }
        public IPreviewCardCommand PreviewCardCommand { get; set; }
        public ICreateCardCommand CreateCardCommand { get; set; }
        public ISaveCardCommand SaveCardCommand { get; set; }

        public ProjectManagementViewModel ProjectManagementViewModel { get; set; }
        public ProjectSettingsViewModel ProjectSettingsViewModel { get; set; }

        private IDataSource<Card> _cardDataSource;
        private readonly IMapper _mapper;

        public GameDetailsViewModel(ILoadProjectCommand loadProjectCommand, IPreviewCardCommand previewCardCommand, ICreateCardCommand createCardCommand, IDataSource<Card> cardDataSource, ISaveCardCommand saveCardCommand, IMapper mapper, ProjectManagementViewModel projectManagementViewModel, ProjectSettingsViewModel projectSettingsViewModel)
        {
            LoadProjectCommand = loadProjectCommand;
            PreviewCardCommand = previewCardCommand;
            CreateCardCommand = createCardCommand;
            _cardDataSource = cardDataSource;
            SaveCardCommand = saveCardCommand;
            _mapper = mapper;
            ProjectManagementViewModel = projectManagementViewModel;
            ProjectSettingsViewModel = projectSettingsViewModel;
            CardsInFamily = new ObservableCollection<CardViewModel>(new List<CardViewModel>());

            _cardDataSource.ComponentCreated += AddNewCard;
            //_cardDataSource.CollectionChanged += RefreshCards;
        }

        private void AddNewCard(object? sender, GameComponentCreated<Card> e)
        {
            var newItem = _mapper.Map<CardViewModel>(e.CreatedItem);
            CardsInFamily.Add(newItem);
        }

        public string GameData { get; set; }
        private static List<CardFamilyViewModel> CardsFamiliesSource = new List<CardFamilyViewModel>
        {
            new CardFamilyViewModel()
        };

        private static List<CardViewModel> Cards = new List<CardViewModel>();

        private CardFamilyViewModel _selectedCardFamily;

        public ObservableCollection<CardFamilyViewModel> CardFamilies { get; } = new ObservableCollection<CardFamilyViewModel>(CardsFamiliesSource);

        public CardFamilyViewModel SelectedCardFamily
        {
            get => _selectedCardFamily;
            set
            {
                if (value != _selectedCardFamily)
                {
                    _selectedCardFamily = value;
                    OnPropertyChanged();

                    CardsInFamily.Clear();
                    var cards = value.Cards;
                    foreach (var card in cards)
                    {
                        CardsInFamily.Add(card);
                    }

                    if (SelectedFamilyCardChanged != null)
                    {
                        SelectedFamilyCardChanged.Invoke(this, new SelectedCardFamilyChanged());
                    }
                }
            }
        }

        public CardViewModel SelectedCard
        {
            get { return _selectedCard; }
            set
            {
                if (_selectedCard != value)
                {
                    SaveCardCommand.SelectedCardId = value?.CardId;
                    _selectedCard = value;
                    OnPropertyChanged();

                    if (SelectedCardChanged != null)
                    {
                        SelectedCardChanged.Invoke(this, new SelectedCardChanged
                        {
                            NewCardId = value?.CardId
                        });
                    }
                }
            }
        }

        private ObservableCollection<CardViewModel> _insideItems;
        private CardViewModel _selectedCard;

        public ObservableCollection<CardViewModel> CardsInFamily
        {
            get { return _insideItems; }

            private set
            {
                _insideItems = value;
                OnPropertyChanged();
            }
        }

        public event EventHandler<SelectedCardChanged> SelectedCardChanged;
        public event EventHandler<SelectedCardFamilyChanged> SelectedFamilyCardChanged;
    }
}
